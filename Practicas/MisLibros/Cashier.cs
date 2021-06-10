using System;

namespace Practicas.MisLibros
{
    public class Cashier
    {
        private const string CART_MUST_NOT_BE_EMPTY = "Carro esta vacio";

        private Cart cart;

        public Cashier(Cart cart)
        {
            if (cart.IsEmpty())
                throw new InvalidOperationException(CART_MUST_NOT_BE_EMPTY);

            this.cart = cart;
        }

        public void Checkout()
        {
            throw new InvalidOperationException("Carro esta vacio");
        }
    }
}