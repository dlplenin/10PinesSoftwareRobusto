using Practicas.MisLibros;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Practivas.test.MisLibros
{
    public class TusLibrosApplicationTest
    {
        private readonly TastFactory factory;
        private readonly TusLibrosApplication application;

        public TusLibrosApplicationTest()
        {
            this.factory = new TastFactory();
            this.application = new TusLibrosApplication(factory.Catalog(), factory.Clients());
        }

        [Fact]
        public void SiUsuarioValidoYPasswordInvalidoNoSePuedeCrearCarrito()
        {
            string clientId = factory.ValidUser();
            string password = factory.InValidPassword();

            var excepcion = Assert.Throws<InvalidOperationException>(() => application.CreateCart(clientId, password));
            Assert.Equal(TusLibrosApplication.CREDENCIALES_INVALIDAS, excepcion.Message);
        }

        [Fact]
        public void SiUsuarioInValidoYPasswordValidoNoSePuedeCrearCarrito()
        {
            string clientId = factory.InValidUser();
            string password = factory.ValidPassword();

            var excepcion = Assert.Throws<InvalidOperationException>(() => application.CreateCart(clientId, password));
            Assert.Equal(TusLibrosApplication.CREDENCIALES_INVALIDAS, excepcion.Message);
        }

        [Fact]
        public void ConCredencialesValidasSePuedeCrearCarrito()
        {
            string clientId = factory.ValidUser();
            string password = factory.ValidPassword();

            string idCart = application.CreateCart(clientId, password);

            Assert.NotEmpty(idCart);
        }

        [Fact]
        public void AgregarItemsConCantidadPositivaACarrito()
        {
            string idCart = ValidApplicationCart();
            var validBook = factory.ValidBook();

            application.AddToCart(idCart, validBook, 1);

            //Assert.True(addToCartResponse);
        }

        private string ValidApplicationCart()
        {
            string clientId = factory.ValidUser();
            string password = factory.ValidPassword();
            return application.CreateCart(clientId, password);
        }

        [Fact]
        public void NoPermiteAgregarItemsConCantidadNegativaACarrito()
        {
            string idCart = ValidApplicationCart();
            var validBook = factory.ValidBook();

            var excepcion = Assert.Throws<InvalidOperationException>(() => application.AddToCart(idCart, validBook, -1));
            Assert.Equal(TusLibrosApplication.CANTIDAD_LIBROS_NEGATIVA, excepcion.Message);
        }

        [Fact]
        public void ListarCarrito()
        {
            string idCart = ValidApplicationCart();
            var validBook = factory.ValidBook();

            application.AddToCart(idCart, validBook, 2);

            Dictionary<string, int> list = application.ListCart(idCart);

            Assert.NotEmpty(list);

            Assert.Equal(2, list.GetValueOrDefault(validBook.ToString()));
        }
    }
}
