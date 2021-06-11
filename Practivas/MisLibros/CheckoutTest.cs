using Xunit;
using Practicas.MisLibros;
using System.Collections.Generic;
using System;

namespace Practivas.test.MisLibros
{
    public class CheckoutTest
    {
        private readonly TastFactory factory;
        private const string CART_MUST_NOT_BE_EMPTY = "Carro esta vacio";
        private const string CREDIT_CARD_IS_EXPIRED = "Tarjeta de crédito expirada";
        private const string CREDIT_CARD_INVALID = "Tarjeta de crédito inválida";

        public CheckoutTest(){
            this.factory = new TastFactory();
        }

        [Fact]
        public void CarroVacioNoPuedeHacerCheckout()
        {
            Cart cart = factory.EmptyCart();

            var excepcion = Assert.Throws<InvalidOperationException>(() => new Cashier(cart, factory.ValidCreditCard()));
            Assert.Equal(CART_MUST_NOT_BE_EMPTY, excepcion.Message);
        }

        [Fact]
        public void TarjetaVencidaNoPuedeHacerCheckout()
        {
            Cart cart = factory.EmptyCart();
            var book = factory.ValidBook();

            cart.Add(book);

            var excepcion = Assert.Throws<InvalidOperationException>(() => new Cashier(cart, factory.ExpiredCreditCard()));
            Assert.Equal(CREDIT_CARD_IS_EXPIRED, excepcion.Message);
        }

        [Fact]
        public void TarjetaInvalidaNoPuedeHacerCheckout()
        {
            Cart cart = factory.EmptyCart();
            var book = factory.ValidBook();

            cart.Add(book);

            var excepcion = Assert.Throws<FormatException>(() => new Cashier(cart, factory.InvalidFormatCreditCard()));
            Assert.Equal(CREDIT_CARD_INVALID, excepcion.Message);
        }

        //[Fact]
        //public void CalcularTotalACobrar()
        //{
        //    Cart cart = factory.EmptyCart();
        //    var book = factory.ValidBook();

        //    cart.AddWithQuantity(book, 2);

        //    var cashier = new Cashier(cart, factory.ValidCreditCard());

        //    decimal total = cashier.Checkout();

        //    Assert.Equal(20, total);
        //}
    }
}