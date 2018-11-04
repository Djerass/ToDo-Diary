using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.Repositories
{
    public class EFOrderRepository:IOrderRepository
    {
        private ToDoContext context;
        public EFOrderRepository(ToDoContext ctx) {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);
        public void SaveOrder(Order order) {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0) {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
