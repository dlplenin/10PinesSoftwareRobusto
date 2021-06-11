using Practicas.MisLibros;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Practivas.test.MisLibros
{
    public class ShoppingTest : TastFactory
    {

        private const string BOOK_NOT_IN_CATALOG = "El libro no está en el catálogo";
        private const string QUANTITY_MUST_GT_ZERO = "Cantidad debe ser mayor a 0";

        [Fact]
        public void AgregarLibroACarrito()
        {
            var cart = EmptyCart();
            var book = ValidBook();

            cart.Add(book);

            Assert.True(cart.Contains(book));
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
            Assert.Equal(4, cart.Count());
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
        public void ComienzoConCarritoVacio()
        {
            var cart = EmptyCart();

            Assert.True(cart.IsEmpty());
        }

        [Fact]
        public void DebeAgregarSoloCantidadesMayoresaCero()
        {
            var cart = EmptyCart();
            var book = ValidBook();

            var excepcion = Assert.Throws<InvalidOperationException>(() => cart.AddWithQuantity(book, 0));
            Assert.Equal(QUANTITY_MUST_GT_ZERO, excepcion.Message);
        }

        [Fact]
        public void SiAgregoLibroQueNoExisteEnCatalogo_Excepcion()
        {
            var cart = EmptyCart();
            var book = NotInCatalogBook();

            var excepcion = Assert.Throws<InvalidOperationException>(() => cart.AddWithQuantity(book, 1));
            Assert.Equal(BOOK_NOT_IN_CATALOG, excepcion.Message);
        }

    }
}
