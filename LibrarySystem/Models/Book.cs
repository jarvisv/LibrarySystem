using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LibrarySystem.Models
{
    [DataContract]
    public class Book : Media
    {
        public enum AvailabilityStatus
        {
            AVAILABLE = 0,
            UNAVAILABLE = 1
        };

        [Required]
        [StringLength(20)]
        [DataMember]
        public string ISBN { get; set; }

        [Required]
        [StringLength(100)]
        [DataMember]
        public string Title { get; set; }

        [Required]
        [DataMember]
        public string Keywords { get; set; }

        [Required]
        [DataMember]
        public DateTime PublishedYear { get; set; }

        [Required]
        [StringLength(100)]
        [DataMember]
        public string Author { get; set; }

        [Required]
        [DataMember]
        public AvailabilityStatus Availability { get; set; }

        public override MediaType Type { get; set; }
    }
}