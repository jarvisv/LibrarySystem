using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace LibrarySystem.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().Property(t => t.DueDate).IsOptional();
            modelBuilder.Entity<Transaction>().Property(t => t.TransactionDate).IsOptional();
            base.OnModelCreating(modelBuilder);
        }
    }
}