using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystem.Models
{
    //The transaction model represents the act of a book (or any other borrowable) being borrowed.
    //Each transaction is associated with one book and one member. In this design, if a member borrows
    //multiple books at the same time multiple transaction records would be created.
    public class Transaction
    {
        public enum TransactionStatus
        {
            TRANSACTION_ACTIVE = 0,
            TRANSACTION_CLOSED = 1
        };

        public Transaction()
        {
            DueDate = DateTime.Now;
            TransactionDate = DateTime.Now;
        }

        [Key]
        [Required]
        public int id { get; set; }

        public virtual Member Borrower { get; set; }
        public string BorrowerId { get; set; }

        public virtual Book Borrowabe { get; set; }
        public int BorrowableId { get; set; }

        //each transaction will also have the transaction date and the due date by when the borrowed item needs to be returned
        public DateTime? TransactionDate { get; set; }
        public DateTime? DueDate { get; set; }

        [Required]
        public TransactionStatus Status { get; set; }
    }
}