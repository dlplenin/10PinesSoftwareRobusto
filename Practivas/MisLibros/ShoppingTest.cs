using Practicas.MisLibros;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Practivas.test.MisLibros
{
    public class ShoppingTest
    {
        private List<object> Catalog()
        {
            return new List<object>() { ValidBook(), AnotherValidBook() };
        }

        [Fact]
        public void ComienzoConCarritoVacio()
        {
            var cart = EmptyCart();

            Assert.True(cart.IsEmpty());
        }

        [Fact]
        public void AgregarLibroACarrito()
        {
            var cart = EmptyCart();
            var book = ValidBook();

            cart.Add(book);

            Assert.True(cart.Contains(book));
        }

        [Fact]
        public void AgregarMasDeUnLibroACarrito()
        {
            var cart = EmptyCart();
            var book = ValidBook();
            var anotherBook = AnotherValidBook();

            cart.Add(book);
            cart.Add(anotherBook);

            Assert.True(cart.Contains(book));
            Assert.True(cart.Contains(anotherBook));
        }

        [Fact]
        public void AgregarMasDeUnEjemplarDelMismoLibroAlCarrito()
        {
            var cart = EmptyCart();
            var book = ValidBook();

            cart.AddWithQuantity(book, 3);

            Assert.Equal(3, cart.HowManyOf(book));
        }

        [Fact]
        public void AgregarMasDeUnEjemplarDeDiferentesLibrosAlCarrito()
        {
            var cart = EmptyCart();
            var book = ValidBook();
            var anotherBook = AnotherValidBook();

            cart.AddWithQuantity(book, 3);
            cart.Add(anotherBook);

            Assert.Equal(1, cart.HowManyOf(anotherBook));
            Assert.Equal(3, cart.HowManyOf(book));
        }

        [Fact]
        public void SiAgregoLibroQueNoExisteEnCatalogo_Excepcion()
        {
            var cart = EmptyCart();
            var book = NotInCatalogBook();

            var excepcion = Assert.Throws<InvalidOperationException>(() => cart.Add(book));
            Assert.Equal("El libro no está en el catálogo", excepcion.Message);
        }

        private object NotInCatalogBook()
        {
            return "Fuera de catálogo";
        }

        private Cart EmptyCart()
        {
            return new Cart(Catalog());
        }

        private object ValidBook()
        {
            return "Libro 1";
        }

        private object AnotherValidBook()
        {
            return "Libro 2";
        }
    }
}
