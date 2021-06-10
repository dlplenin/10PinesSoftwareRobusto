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
            Cart cart = EmptyCart();

            var excepcion = Assert.Throws<InvalidOperationException>(() => new Cashier(cart));
            Assert.Equal(CART_MUST_NOT_BE_EMPTY, excepcion.Message);
        }

        private static Cart EmptyCart()
        {
            return new Cart(new List<object>());
        }
    }
}