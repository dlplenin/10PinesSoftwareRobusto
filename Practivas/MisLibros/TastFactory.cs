using System.Collections.Generic;
using Practicas.MisLibros;

namespace Practivas.test.MisLibros
{
    public class TastFactory
    {
        public Dictionary<string, string> Clients()
        {
            return new Dictionary<string, string>
            {
                { ValidUser(), ValidPassword() }
            };
        }

        public string ValidPassword()
        {
            return "password1";
        }

        public string ValidUser()
        {
            return "user1";
        }

        public string InValidPassword()
        {
            return "password2";
        }

        public string InValidUser()
        {
            return "user2";
        }

        public object AnotherValidBook()
        {
            return "Libro 2";
        }

        public Dictionary<string, decimal> Catalog()
        {
            return new Dictionary<string, decimal> 
            {
                { ValidBook().ToString(), 15M },
                { AnotherValidBook().ToString(), 5M }
            };
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

        public string InvalidFormatCreditCard()
        {
            return "2050/01";
        }

        public string ValidCreditCard()
        {
            return "01/2025";
        }

        public string ExpiredCreditCard()
        {
            return "01/2020";
        }


        public Dictionary<int, string> Users()
        {
            return new Dictionary<int, string>
            {
                { 1, "123" },
                { 2, "456" }
            };
        }
    }
}