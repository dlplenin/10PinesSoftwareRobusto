using Xunit;
using Practicas.MisLibros;
using System.Collections.Generic;
using System;

namespace Practivas.test.MisLibros
{
    public class CashierTest
    {

        private TastFactory factory;
        private const string CART_MUST_NOT_BE_EMPTY = "Carro esta vacio";

        public CashierTest(){
            this.factory = new TastFactory();
        }


        [Fact]
        public void CarroVacioNoPuedeHacerCheckout()
        {
            Cart cart = factory.EmptyCart();

            var excepcion = Assert.Throws<InvalidOperationException>(() => new Cashier(cart));
            Assert.Equal(CART_MUST_NOT_BE_EMPTY, excepcion.Message);
        }

    }
}