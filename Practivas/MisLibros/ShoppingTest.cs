using System;
using Xunit;

namespace Practivas.test.MisLibros
{
    public class ShoppingTest
    {
        private readonly TastFactory factory;

        public ShoppingTest(){
            this.factory = new TastFactory();
        }

        private const string BOOK_NOT_IN_CATALOG = "El libro no está en el catálogo";
        private const string QUANTITY_MUST_GT_ZERO = "Cantidad debe ser mayor a 0";

        [Fact]
        public void AgregarLibroACarrito()
        {
            var cart = factory.EmptyCart();
            var book = factory.ValidBook();

            cart.Add(book);

            Assert.True(cart.Contains(book));
        }

        [Fact]
        public void AgregarMasDeUnEjemplarDeDiferentesLibrosAlCarrito()
        {
            var cart = factory.EmptyCart();
            var book = factory.ValidBook();
            var anotherBook = factory.AnotherValidBook();

            cart.AddWithQuantity(book, 3);
            cart.Add(anotherBook);

            Assert.Equal(1, cart.HowManyOf(anotherBook));
            Assert.Equal(3, cart.HowManyOf(book));
            Assert.Equal(4, cart.Count());
        }

        [Fact]
        public void AgregarMasDeUnEjemplarDelMismoLibroAlCarrito()
        {
            var cart = factory.EmptyCart();
            var book = factory.ValidBook();

            cart.AddWithQuantity(book, 3);

            Assert.Equal(3, cart.HowManyOf(book));
        }

        [Fact]
        public void AgregarMasDeUnLibroACarrito()
        {
            var cart = factory.EmptyCart();
            var book = factory.ValidBook();
            var anotherBook = factory.AnotherValidBook();

            cart.Add(book);
            cart.Add(anotherBook);

            Assert.True(cart.Contains(book));
            Assert.True(cart.Contains(anotherBook));
        }

        [Fact]
        public void ComienzoConCarritoVacio()
        {
            var cart = factory.EmptyCart();

            Assert.True(cart.IsEmpty());
        }

        [Fact]
        public void DebeAgregarSoloCantidadesMayoresaCero()
        {
            var cart = factory.EmptyCart();
            var book = factory.ValidBook();

            var excepcion = Assert.Throws<InvalidOperationException>(() => cart.AddWithQuantity(book, 0));
            Assert.Equal(QUANTITY_MUST_GT_ZERO, excepcion.Message);
        }

        [Fact]
        public void SiAgregoLibroQueNoExisteEnCatalogo_Excepcion()
        {
            var cart = factory.EmptyCart();
            var book = factory.NotInCatalogBook();

            var excepcion = Assert.Throws<InvalidOperationException>(() => cart.AddWithQuantity(book, 1));
            Assert.Equal(BOOK_NOT_IN_CATALOG, excepcion.Message);
        }

        [Fact]
        public void ObtengoElTotalApagar()
        {
            var cart = factory.EmptyCart();
            var book = factory.ValidBook();

            cart.AddWithQuantity(book, 2);

            var totalAmount = cart.TotalAmount();
            Assert.Equal(30, totalAmount);
        }
    }
}
