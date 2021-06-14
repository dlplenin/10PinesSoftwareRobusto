using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicas.MisLibros
{
    public class TusLibrosApplication
    {
        private Dictionary<string, decimal> catalog;
        private Dictionary<string, string> clients;
        private Dictionary<string, Cart> carts = new Dictionary<string, Cart>();

        public const string CREDENCIALES_INVALIDAS = "Credenciales inválidas";
        public const string CANTIDAD_LIBROS_NEGATIVA = "La cantidad de libros no puede ser negativa";

        public TusLibrosApplication(Dictionary<string, decimal> catalog, Dictionary<string, string> clients)
        {
            this.catalog = catalog;
            this.clients = clients;
        }

        public string CreateCart(string clientId, string password)
        {
            var saved_password = clients.GetValueOrDefault(clientId);
            if (saved_password != password)
                throw new InvalidOperationException(CREDENCIALES_INVALIDAS);

            var guid = Guid.NewGuid().ToString();
            carts.Add(guid, new Cart(catalog));

            return guid;
        }

        public void AddToCart(string idCart, object bookIsbn, int bookQuantity)
        {
            // id cd carrito v

            if (bookQuantity < 1)
                throw new InvalidOperationException(CANTIDAD_LIBROS_NEGATIVA);

            var cart = carts.GetValueOrDefault(idCart);
            cart.AddWithQuantity(bookIsbn, bookQuantity);
        }

        public Dictionary<string, int> ListCart(string idCart)
        {
            var cart = carts.GetValueOrDefault(idCart);
            return cart.ListItems();
        }
    }
}
