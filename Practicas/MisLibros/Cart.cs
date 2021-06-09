using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicas.MisLibros
{
    public class Cart
    {
        private List<Book> Items { get; set; } = new List<Book>();

        public void AddBook(Book libro)
        {
            Items.Add(libro);
        }

        public int GetItemsCount()
        {
            return Items.Count;
        }
    }
}
