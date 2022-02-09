using MyBoard.Data.Interfaces;
using MyBoard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Data.Repository
{
    public class OrdersRepository : IAllOrder
    {
        private readonly AppDBContext appDBContext;
        private readonly ProductCart productCart;

        public OrdersRepository(AppDBContext appDBContext, ProductCart productCart)
        {
            this.appDBContext = appDBContext;
            this.productCart = productCart;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContext.Order.Add(order);

            var items = productCart.listCartItem;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    productId = el.product.id,
                    orderId = order.id,
                    price = el.product.price
                };
                appDBContext.OrderDetail.Add(orderDetail);
            }
            appDBContext.SaveChanges();
        }
    }
}
