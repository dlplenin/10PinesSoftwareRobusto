using System;
using System.Globalization;
using System.Linq;

namespace Practicas.MisLibros
{
    public class Cashier
    {
        private const string CART_MUST_NOT_BE_EMPTY = "Carro esta vacio";
        private const string CREDIT_CARD_IS_EXPIRED = "Tarjeta de crédito expirada";
        private const string CREDIT_CARD_INVALID = "Tarjeta de crédito inválida";

        private readonly Cart cart;

        public Cashier(Cart cart, string creditCardExpiration)
        {
            if (cart.IsEmpty())
                throw new InvalidOperationException(CART_MUST_NOT_BE_EMPTY);

            AssertValidCard(creditCardExpiration);

            this.cart = cart;
        }

        private static void AssertValidCard(string validThru)
        {
            // creditCardExpiration => 06/2022
            try
            {
                DateTime date = DateTime.ParseExact($"01/{validThru}", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var expiration = date.AddMonths(1);

                if (DateTime.Now >= expiration)
                    throw new InvalidOperationException(CREDIT_CARD_IS_EXPIRED);
            }
            catch (FormatException)
            {
                throw new FormatException(CREDIT_CARD_INVALID);
            }
        }

        public decimal Checkout()
        {
            return cart.TotalAmount();
        }
    }
}