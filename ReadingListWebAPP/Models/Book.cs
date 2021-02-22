using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Readinglist.Models
{
    public class Book
    {
        public virtual long ID { get; set; }
        public virtual string Reader { get; set; }
        public virtual string Isbn { get; set; }
        public virtual string Title { get; set; }
        public virtual string Author { get; set; }
        public virtual string Description { get; set; }


    }
}