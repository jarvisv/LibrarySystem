using LibrarySystem.Data;
using LibrarySystem.Models;

namespace LibrarySystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private void SeedMembersTable(LibraryContext context)
        {
            context.Members.AddOrUpdate(
                m => m.MemberId,
                new Member
                {
                    MemberId = "MEM-FR-0001",
                    FirstName = "Nelson",
                    LastName = "Mandela",
                    Phone = "111-111-1111",
                    Email = "nelson.mandela@mandela.com",
                    Status = Member.MemberStatus.ACTIVE,
                    OutstandingPenalty = 0.0,
                    BorrowedBooksCount = 0
                },
                new Member
                {
                    MemberId = "MEM-FR-0002",
                    FirstName = "Mohandas",
                    LastName = "Gandhi",
                    Phone = "222-222-2222",
                    Email = "mohandas.gandhi@gandhi.com",
                    Status = Member.MemberStatus.ACTIVE,
                    OutstandingPenalty = 0.0,
                    BorrowedBooksCount = 0
                },
                new Member
                {
                    MemberId = "MEM-FR-0003",
                    FirstName = "Mother",
                    LastName = "Teresa",
                    Phone = "333-333-3333",
                    Email = "mother.teresa@teresa.com",
                    Status = Member.MemberStatus.ACTIVE,
                    OutstandingPenalty = 0.0,
                    BorrowedBooksCount = 0
                },
                new Member
                {
                    MemberId = "MEM-FR-0004",
                    FirstName = "Hellen",
                    LastName = "Keller",
                    Phone = "444-444-4444",
                    Email = "hellen.keller@keller.com",
                    Status = Member.MemberStatus.ACTIVE,
                    OutstandingPenalty = 0.0,
                    BorrowedBooksCount = 0
                },
                new Member
                {
                    MemberId = "MEM-FR-0005",
                    FirstName = "Abraham",
                    LastName = "Lincoln",
                    Phone = "555-555-5555",
                    Email = "abraham.lincoln@lincoln.com",
                    Status = Member.MemberStatus.ACTIVE,
                    OutstandingPenalty = 0.0,
                    BorrowedBooksCount = 0
                },
                new Member
                {
                    MemberId = "MEM-FR-0006",
                    FirstName = "Rahul",
                    LastName = "Dravid",
                    Phone = "666-666-6666",
                    Email = "rahul.dravid@dravid.com",
                    Status = Member.MemberStatus.ACTIVE,
                    OutstandingPenalty = 0.0,
                    BorrowedBooksCount = 0
                },
                new Member
                {
                    MemberId = "MEM-FR-0007",
                    FirstName = "Albert",
                    LastName = "Einstein",
                    Phone = "777-777-7777",
                    Email = "albert.einstein@einstein.com",
                    Status = Member.MemberStatus.ACTIVE,
                    OutstandingPenalty = 0.0,
                    BorrowedBooksCount = 0
                },
                new Member
                {
                    MemberId = "MEM-FR-0008",
                    FirstName = "Nikola",
                    LastName = "Tesla",
                    Phone = "888-888-8888",
                    Email = "nikola.tesla@tesla.com",
                    Status = Member.MemberStatus.ACTIVE,
                    OutstandingPenalty = 0.0,
                    BorrowedBooksCount = 0
                },
                new Member
                {
                    MemberId = "MEM-FR-0009",
                    FirstName = "Leonardo",
                    LastName = "DaVinci",
                    Phone = "999-999-9999",
                    Email = "leo.davinci@davinci.com",
                    Status = Member.MemberStatus.ACTIVE,
                    OutstandingPenalty = 0.0,
                    BorrowedBooksCount = 0
                });
        }

        private void SeedBooksTable(LibraryContext context)
        {
            context.Books.AddOrUpdate(
                b => b.Id,
                 new Book
                 {
                     Id = 1,
                     ISBN = "0000000001",
                     Title = "Salem's Lot",
                     Author = "Stephen King",
                     Keywords = "Vampires, Fiction, Thriller",
                     PublishedYear = Convert.ToDateTime("01/01/1975"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 //2nd copy of Stephen's King
                 new Book
                 {
                     Id = 2,
                     ISBN = "0000000001",
                     Title = "Salem's Lot",
                     Author = "Stephen King",
                     Keywords = "Vampires, Fiction, Thriller",
                     PublishedYear = Convert.ToDateTime("01/01/1975"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 //3rd copy of Stephen's King
                 new Book
                 {
                     Id = 3,
                     ISBN = "0000000001",
                     Title = "Salem's Lot",
                     Author = "Stephen King",
                     Keywords = "Vampires, Fiction, Thriller",
                     PublishedYear = Convert.ToDateTime("01/01/1975"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 4,
                     ISBN = "0000000002",
                     Title = "Elon Musk",
                     Author = "Ashlee Vance",
                     Keywords = "Biography",
                     PublishedYear = Convert.ToDateTime("01/01/2011"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 5,
                     ISBN = "0000000003",
                     Title = "The story of my experiments with truth",
                     Author = "Mohandas Gandhi",
                     Keywords = "Biography",
                     PublishedYear = Convert.ToDateTime("01/01/1945"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 6,
                     ISBN = "0000000004",
                     Title = "The Alchemist",
                     Author = "Paulo Coelho",
                     Keywords = "Inspiration",
                     PublishedYear = Convert.ToDateTime("01/01/2003"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 7,
                     ISBN = "000000005",
                     Title = "The Last Lecture",
                     Author = "Randy Pausch",
                     Keywords = "Motivation, Inspiration",
                     PublishedYear = Convert.ToDateTime("01/01/1975"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 8,
                     ISBN = "0000000006",
                     Title = "For one more day",
                     Author = "Mitch Albom",
                     Keywords = "Inspiration",
                     PublishedYear = Convert.ToDateTime("01/01/2006"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 9,
                     ISBN = "0000000007",
                     Title = "Eat, Pray, Love",
                     Author = "Elizabeth Gilbert",
                     Keywords = "Inspiration, Motivation",
                     PublishedYear = Convert.ToDateTime("01/01/2006"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 10,
                     ISBN = "0000000008",
                     Title = "The time keeper",
                     Author = "Mitch Albom",
                     Keywords = "Inspiration",
                     PublishedYear = Convert.ToDateTime("01/01/2012"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 11,
                     ISBN = "0000000009",
                     Title = "Last Man Standing",
                     Author = "David Baldacci",
                     Keywords = "Thriller, Action",
                     PublishedYear = Convert.ToDateTime("01/01/2005"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 12,
                     ISBN = "0000000010",
                     Title = "Desperation",
                     Author = "Stephen King",
                     Keywords = "Thriller",
                     PublishedYear = Convert.ToDateTime("01/01/1985"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 13,
                     ISBN = "0000000011",
                     Title = "I am Malala",
                     Author = "Malala Yousafzai",
                     Keywords = "Biography",
                     PublishedYear = Convert.ToDateTime("01/01/2013"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 14,
                     ISBN = "0000000012",
                     Title = "Ender's Game",
                     Author = "Orson Scott",
                     Keywords = "Science Fiction",
                     PublishedYear = Convert.ToDateTime("01/01/1985"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 15,
                     ISBN = "0000000013",
                     Title = "Catching Fire",
                     Author = "Suzanne Collins",
                     Keywords = "Science Fiction",
                     PublishedYear = Convert.ToDateTime("01/01/2009"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 16,
                     ISBN = "0000000014",
                     Title = "The Martian",
                     Author = "Andy Weir",
                     Keywords = "Science Fiction",
                     PublishedYear = Convert.ToDateTime("01/01/2011"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 17,
                     ISBN = "0000000015",
                     Title = "Ready Player One",
                     Author = "Ernest Cline",
                     Keywords = "Science Fiction",
                     PublishedYear = Convert.ToDateTime("01/01/2011"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 18,
                     ISBN = "0000000016",
                     Title = "The Stranger",
                     Author = "Albert Camus",
                     Keywords = "Philosophy",
                     PublishedYear = Convert.ToDateTime("01/01/1942"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 19,
                     ISBN = "0000000017",
                     Title = "The art of happiness",
                     Author = "Dalai Lama",
                     Keywords = "Spirituality",
                     PublishedYear = Convert.ToDateTime("01/01/1998"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 },
                 new Book
                 {
                     Id = 20,
                     ISBN = "0000000018",
                     Title = "The snow leopard",
                     Author = "Peter Matthiessen",
                     Keywords = "Spirituality",
                     PublishedYear = Convert.ToDateTime("01/01/1978"),
                     Type = Media.MediaType.MEDIA_TYPE_BOOK,
                     Availability = Book.AvailabilityStatus.AVAILABLE
                 }
         );
        }
        protected override void Seed(LibraryContext context)
        {
            SeedBooksTable(context);
            SeedMembersTable(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
