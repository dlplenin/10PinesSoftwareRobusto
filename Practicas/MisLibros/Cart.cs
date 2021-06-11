﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicas.MisLibros
{
    public class Cart
    {
        private List<object> Items { get; set; } = new List<object>();
        private readonly Dictionary<string, decimal> Catalog;


        public Cart(Dictionary<string, decimal> catalog)
        {
            Catalog = catalog;
        }

        public void Add(object book)
        {
            AddWithQuantity(book, 1);
        }

        public void AddWithQuantity(object book, int quantity)
        {
            AssertValidQuantity(quantity);

            AssertValidInCatalog(book);

            for (int i = 0; i < quantity; i++)
                Items.Add(book);
        }

        private void AssertValidInCatalog(object book)
        {
            if (!Catalog.ContainsKey(book.ToString()))
                throw new InvalidOperationException("El libro no está en el catálogo");
        }

        private static void AssertValidQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new InvalidOperationException("Cantidad debe ser mayor a 0");
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

        public int Count()
        {
            return Items.Count;
        }
    }
}
