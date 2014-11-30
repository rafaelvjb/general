using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleCodeFirstApproch.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string Address { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}