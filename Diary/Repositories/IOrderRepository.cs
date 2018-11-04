using System.Linq;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.Repositories
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}