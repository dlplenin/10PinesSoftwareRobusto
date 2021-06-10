using Xunit;
using Practicas.MisLibros;
using System.Collections.Generic;
using System;

namespace Practivas.test.MisLibros
{
    public class CashierTest
    {
        private const string CART_MUST_NOT_BE_EMPTY = "Carro esta vacio";

        [Fact]
        public void CarroVacioNoPuedeHacerCheckout()
        {
            //Given

            //When

            //Then
            var excepcion = Assert.Throws<InvalidOperationException>(() => CashierWithEmpotyCart());
            Assert.Equal(CART_MUST_NOT_BE_EMPTY, excepcion.Message);
        }

        private static Cashier CashierWithEmpotyCart()
        {
            Cart cart = new Cart(new List<object>());
            return new Cashier(cart);
        }
    }
}