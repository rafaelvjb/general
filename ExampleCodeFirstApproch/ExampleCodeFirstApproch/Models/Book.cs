using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleCodeFirstApproch.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}