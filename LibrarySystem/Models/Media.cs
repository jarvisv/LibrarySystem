using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LibrarySystem.Models
{
    //Media is the base model class for everything in the library and basically represents items that can be borrowed (book,
    //DVD, AudioCD etc and items that are reference only such as Encyclopedia, Archive newspapers etc that cannot be checked
    //out from the library.
    //Every media item has a unique id - this could be the barcode for example and can be used during checkout. Business
    //logic at a higher layer can prevent reference items from being checkout out by members.
    [DataContract]
    public abstract class Media
    {
        public enum MediaType{
            MEDIA_TYPE_BOOK,
            MEDIA_TYPE_DVD,
            MEDIA_TYPE_AUDIOCD,
            MEDIA_TYPE_REFERENCE,
            MEDIA_TYPE_OTHER
        };

        public enum MediaAvailabilityStatus
        {
            MEDIA_AVAILABLE,
            MEDIA_UNAVAILABLE
        };

        [Required]
        public virtual MediaType Type { get; set; }

        [Required]
        [DataMember]
        public virtual MediaAvailabilityStatus Status { get; set; }

        [Key]
        [Required]
        [DataMember]
        public int Id { get; set; }
    }
}