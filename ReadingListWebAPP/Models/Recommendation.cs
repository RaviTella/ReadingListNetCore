using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Readinglist.Models
{
    public class Recommendation
    {
        public Recommendation(string iD, string isbn, string title, string author, string description, string imageURL)
        {
            ID = iD;
            Isbn = isbn;
            Title = title;
            Author = author;
            Description = description;
            ImageURL = imageURL;
        }

        public virtual string ID { get; set; }
        public virtual string Isbn { get; set; }
        public virtual string Title { get; set; }
        public virtual string Author { get; set; }
        public virtual string Description { get; set; }
        public virtual string ImageURL { get; set; }



    }
}