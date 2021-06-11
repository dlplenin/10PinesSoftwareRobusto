using System.Collections.Generic;
using Practicas.MisLibros;

namespace Practivas.test.MisLibros
{
    public class TastFactory
    {
        public object AnotherValidBook()
        {
            return "Libro 2";
        }

        public List<object> Catalog()
        {
            return new List<object>() { ValidBook(), AnotherValidBook() };
        }

        public Cart EmptyCart()
        {
            return new Cart(Catalog());
        }

        public object NotInCatalogBook()
        {
            return "Fuera de catálogo";
        }

        public object ValidBook()
        {
            return "Libro 1";
        }

        public string InvalidCreditCard()
        {
            return "2050/01";
        }

        public string ValidCreditCard()
        {
            return "01/2021";
        }
    }
}