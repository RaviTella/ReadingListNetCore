using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Readinglist.Models;

namespace ReadingList.Models
{
    public class ReadingListDB : DbContext
    {
        public ReadingListDB (DbContextOptions<ReadingListDB> options)
            : base(options)
        {
        }

        public DbSet<Readinglist.Models.Book> Books { get; set; }
    }
}
