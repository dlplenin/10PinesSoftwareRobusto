using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicas.MisLibros
{
    public class Cart
    {
        private List<object> Items { get; set; } = new List<object>();
        private readonly List<object> Catalog;

        public Cart(List<object> catalog)
        {
            Catalog = catalog;
        }

        public void Add(object book)
        {
            AddWithQuantity(book, 1);
        }

        public void AddWithQuantity(object book, int quantity)
        {
            if (quantity <= 0)
                throw new InvalidOperationException("Cantidad debe ser mayor a 0");
                
            if (!Catalog.Contains(book))
                throw new InvalidOperationException("El libro no está en el catálogo");

            for (int i = 0; i < quantity; i++)
                Items.Add(book);
        }

        public bool IsEmpty()
        {
            return !Items.Any();
        }

        public bool Contains(object book)
        {
            return Items.Contains(book);
        }

        public int HowManyOf(object book)
        {
            return Items.Count(x => x.Equals(book));
        }
    }
}
