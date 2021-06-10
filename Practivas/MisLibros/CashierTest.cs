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
            Cart cart = new Cart(new List<object>());
            
            //When
            Cashier cashier = new Cashier(cart);
            
            //Then
            var excepcion = Assert.Throws<InvalidOperationException>(() => cashier.Checkout());
            Assert.Equal(CART_MUST_NOT_BE_EMPTY, excepcion.Message);
        }
    }
}