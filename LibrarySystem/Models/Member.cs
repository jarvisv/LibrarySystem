using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LibrarySystem.Models
{
    [DataContract]
    public class Member
    {
        public enum MemberStatus
        {
            ACTIVE = 0,
            SUSPENDED = 1,
            DEACTIVATED = 2
        };

        [Required]
        [StringLength(40)]
        [DataMember]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40)]
        [DataMember]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        [DataMember]
        public string Phone { get; set; }

        [Required]
        [StringLength(80)]
        [DataMember]
        public string Email { get; set; }

        [Required]
        [DataMember]
        public string MemberId { get; set; }

        [Required]
        [DataMember]
        public MemberStatus Status { get; set; }

        [Required]
        [DataMember]
        public double OutstandingPenalty { get; set; }

        [Required]
        [DataMember]
        public int BorrowedBooksCount { get; set; }
    }
}