using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyLibrary.Core.Models
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Isbn { get; set; }
        [DataMember]
        public DateTime PubDate { get; set; }
        [DataMember]
        public string Genre { get; set; }

        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public int AvailableCount { get; set; }
    }
}