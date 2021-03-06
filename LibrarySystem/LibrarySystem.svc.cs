﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LibrarySystem.Data; //LibraryContext;
using LibrarySystem.Models;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Collections.Specialized;
using System.Web;

//Design Notes:
//I have used a code first approach to go from model to database. First up, the project structure:
//All of the models in this system - book, member, transaction - can be found under the "Models" subfolder
//The "Data" subfolder contains the LibraryContext - our extension for the DbContext object
//The contents of the folder under "Migrations" are all auto-generated by entity framework and the package manager
//commands I ran to create and update the database
//ILibrarySystem.cs defines the top level interface and represents the functionality of the LibrarySystem.
//For example, the public API available to get books by author, get member details, checking out a book etc
//are all part of this interface. LibrarySystem.svc.cs provides the implementation for all of this and can be
//thought of as the entry point for stepping through the code.

//In the implementation of all these methods, I have used LINQ to entity to interact with the DB including:
//fetching content from DB
//Updating items in DB
//and adding items to DB

//The system is designed with the assumption that the "checkouts" and "returns" are performed by authorized users
//or at least that the API and this app is only available to "trusted" people. In other words, there is no authentication
//built in and neither is there any mechanism to keep track of staff members. This could of course be done with
//no changes needed to core functional logic. Perhaps some kind of book keeping (such as adding the staff member who'
//performed a particular transaction) may need to be added. I have NOT paid too much attention to this.

//THINGS NOT IMPLEMENTED:
//1. Although I have defined a base class for all media (books, dvd etc) the current implementation only has
//support to transact on books

//2. I am not using any HTTP headers to communicate errors back. For ex: all responses returned from this
//service would return a 200 for a successful request - even if the response itself is actually an error. I need
//to dig more to understand what the best practices here is.

//3. As stated above, there is no built-in authentication mechanism. Ideally, we would want to also keep a "Staff" 
//table in addition to the "members" table.

//4. A library itself could have multiple branches and we can add more use cases to transfer book from branch to
//branch or request a book from a different branch etc. None of this is implemented in this version.

//LIMITATIONS:
//1. There are APIs available to look for books using both the title and author but these have to be 
//exact matches
//2. I have not implemented an API to fetch books by published date, ISBN etc. But these are relatively
//straightforward to add and does not need any complicated code
//3. There is a column in the member table to keep track of Outstanding Penalty owed by the member. 
//Potentially there could be logic to prevent members from borrowing new books when they have any
//outstanding penalty but I have not implemented this logic yet.

//TESTING:
//To test all this, I used the Postman client application on Chrome. I have created a collection with
//the REST calls needed and these can be very easily modified to use different values and try out various
//transactions. This collection can be found here:
//https://www.getpostman.com/collections/47765ea579fe0274b8cb


namespace LibrarySystem
{
    public class LibrarySystem : ILibrarySystem
    {
        public List<Book> GetBooksByTitle(string title)
        {
            using (var context = new LibraryContext())
            {
                var booksByAuthorQuery = context.Books.Where(b => b.Title.Equals(title));
                List<Book> books = booksByAuthorQuery.ToList();
                return books;
            }
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            //We will use LINQ to Entities to query our DB
            using (var context = new LibraryContext())
            {
                var booksByAuthorQuery = context.Books.Where(b => b.Author.Equals(author));
                List<Book> books = booksByAuthorQuery.ToList();
                return books;
            }
        }

        public Member GetUser(string id)
        {
            using (var context = new LibraryContext())
            {
                var getUserDetailsQuery = context.Members.Where(m => m.MemberId == id);
                Member member = getUserDetailsQuery.FirstOrDefault();
                return member;
            }
        }

        public string Checkout(Stream input)
        {
            string inputParams = new StreamReader(input).ReadToEnd();
            NameValueCollection inputCollection = HttpUtility.ParseQueryString(inputParams);

            string bookId = inputCollection["bookId"];
            string memberId = inputCollection["memberId"];

            System.Diagnostics.Debug.WriteLine("Attempting checkout:\n");
            System.Diagnostics.Debug.WriteLine("Book Id = " + bookId + "\n");
            System.Diagnostics.Debug.WriteLine("Member Id = " + memberId + "\n");
            //validate that member status is valid and that the book id is valid and the book is available
            using (var context = new LibraryContext())
            {
                var getBookQuery = context.Books.Where(b => b.Id.ToString().Equals(bookId));
                Book book = getBookQuery.SingleOrDefault();
                if (null == book)
                {
                    //Should return error indicating the book id is not valid
                    return "Could locate book with id: " + bookId;
                }

                if (book.Availability != Book.AvailabilityStatus.AVAILABLE)
                {
                    //Its a valid book but its not available. Return an error
                    return "The book titled: " + book.Title + " is not available to borrow";
                }
                
                var getMemberQuery = context.Members.Where(m => m.MemberId.Equals(memberId));
                Member member = getMemberQuery.SingleOrDefault();
                if (null == member)
                {
                    //not a valid member id. Return an error
                    return "Could locate Member with id: " + memberId;
                }

                if (member.Status != Member.MemberStatus.ACTIVE)
                {
                    //Member's status is not ACTIVE. Return an error indicating member is not eligible to borrow 
                    return "The Member : " + member.MemberId + " is not eligible to borrow a book";
                }

                //If everything else checks out then:
                //1. Mark the book as UNAVAILABLE in the books table
                //2. Add the book id and the member id along with due date into the transaction table

                context.Transactions.Add(new Transaction
                {
                    id = 1,
                    BorrowerId = member.MemberId,
                    BorrowableId = book.Id,
                    TransactionDate = Convert.ToDateTime(DateTime.Now),
                    DueDate = Convert.ToDateTime(DateTime.Now.AddDays(30)),
                    Borrowabe = book,
                    Borrower = member,
                    Status = Transaction.TransactionStatus.TRANSACTION_ACTIVE

                });

                book.Availability = Book.AvailabilityStatus.UNAVAILABLE;
                member.BorrowedBooksCount++;
                context.SaveChanges();
                return "Transaction successful!";
            }
        }

        public string Restock(Stream input)
        {
            string inputParams = new StreamReader(input).ReadToEnd();
            NameValueCollection inputCollection = HttpUtility.ParseQueryString(inputParams);

            string bookId = inputCollection["bookId"];
            string memberId = inputCollection["memberId"];

            System.Diagnostics.Debug.WriteLine("Attempting to return a book:\n");
            System.Diagnostics.Debug.WriteLine("Book Id = " + bookId + "\n");
            System.Diagnostics.Debug.WriteLine("Member Id = " + memberId + "\n");
            //validate that member status is valid and that the book id is valid and the book is available
            using (var context = new LibraryContext())
            {
                var getTransactionQuery = context.Transactions.Where
                    (t => t.BorrowableId.ToString().Equals(bookId) && t.BorrowerId.Equals(memberId)
                            && t.Status == Transaction.TransactionStatus.TRANSACTION_ACTIVE);

                Transaction transaction = getTransactionQuery.SingleOrDefault();
                if (null == transaction)
                {
                    return "Could not locate this transaction :-(";
                }

                Book bookToReturn = transaction.Borrowabe;
                Member memberReturningBook = transaction.Borrower;
                //Decrement BorrowedItemCount on member table
                //Update Book status to available
                //Mark transaction as "INACTIVE"
                bookToReturn.Availability = Book.AvailabilityStatus.AVAILABLE;
                memberReturningBook.BorrowedBooksCount--;
                transaction.Status = Transaction.TransactionStatus.TRANSACTION_CLOSED;
                context.SaveChanges();
                return "Return successful!";
            }
        }
    }
}
