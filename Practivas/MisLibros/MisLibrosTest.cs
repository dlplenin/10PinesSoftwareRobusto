using Practicas.MisLibros;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Practivas.test.MisLibros
{
    public class MisLibrosTest
    {
        [Fact]
        public void ComienzoConCarritoVacio()
        {
            var cart = EmptyCart();

            Assert.Empty(cart);
        }

        [Fact]
        public void AgregarLibroACarrito()
        {
            var cart = EmptyCart();
            var book = ValidBook();
            cart.Add(book);

            Assert.Contains(book, cart);
        }

        [Fact]
        public void AgregarMasDeUnLibroACarrito()
        {
            var cart = EmptyCart();
            var book = ValidBook();
            var anotherBook = AnotherValidBook();
            cart.Add(book);
            cart.Add(anotherBook);

            Assert.Contains(book, cart);
            Assert.Contains(anotherBook, cart);
        }

        private List<object> EmptyCart() {
            return new List<object>();
        }

        private object ValidBook()
        {
            return "ISBN-001";
        }

        private object AnotherValidBook()
        {
            return "ISBN-002";
        }
    }
}
