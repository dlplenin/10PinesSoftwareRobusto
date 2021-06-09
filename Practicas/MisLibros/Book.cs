using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicas.MisLibros
{
    public class Book
    {
        private readonly string bookIsbn;

        public Book(string bookIsbn)
        {
            this.bookIsbn = bookIsbn;
        }
    }
}
