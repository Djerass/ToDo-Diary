using System.Linq;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ToDoContext _db;

        public ProductRepository(ToDoContext db)
        {
            _db = db;
        }

        public IQueryable<Product> GetAll() => _db.Products;

    }
}