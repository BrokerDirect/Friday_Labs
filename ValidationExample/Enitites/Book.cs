using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationExample.Enitites
{
    internal record Book
    {
        public string Title { get; set; }
        public string Blurb { get; set; }   
        public DateTime ReleaseDate { get; set; }

        public Author Author { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
