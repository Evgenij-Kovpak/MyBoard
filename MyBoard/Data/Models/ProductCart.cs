using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Data.Models
{
    public class ProductCart
    {
        private readonly AppDBContext appDBContext;
        private IEnumerable<AppDBContext> context;

        public ProductCart(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public ProductCart(IEnumerable<AppDBContext> context)
        {
            this.context = context;
        }

        public string CartId { get; set; }
        public List<CartItem> listCartItem { get; set; }

        public static ProductCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ProductCart(context) { CartId = cartId };
        }
        public void AddToCart(Product product)
        {
             appDBContext.CartItem.Add(new CartItem { 
            cartId = CartId,
            product = product,
            price = product.price
            });

            appDBContext.SaveChanges();
        }

        public List<CartItem> getCartItems()
        {
            return appDBContext.CartItem.Where(c => c.cartId == CartId).Include(s => s.product).ToList();
        }
    }
}
