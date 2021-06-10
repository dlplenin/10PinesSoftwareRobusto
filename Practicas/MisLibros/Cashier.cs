using System;

namespace Practicas.MisLibros
{
    public class Cashier
    {
        private Cart cart;

        public Cashier(Cart cart)
        {
            this.cart = cart;
        }

        public void Checkout()
        {
            throw new InvalidOperationException("Carro esta vacio");
        }
    }
}