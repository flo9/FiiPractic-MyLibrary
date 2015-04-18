using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Core.Models
{
     [DataContract]
    public class Lending
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public Book Book { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public DateTime LendingDate { get; set; }
        [DataMember]
        public DateTime ReturnDate { get; set; }
    }
}
