using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithClasses
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public ICollection<Libro> Libri { get; set; } = new List<Libro>();
        
    }
}
