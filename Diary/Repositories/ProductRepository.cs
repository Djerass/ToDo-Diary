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
        public void SaveProduct(Product product) {
            if (product.ProductID == 0) {
               _db.Products.Add(product);
            } else {
                Product dbEntry = _db.Products
                    .FirstOrDefault(p => p.ProductID == product.ProductID);
                if (dbEntry != null) {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            _db.SaveChanges();
        }
        public Product DeleteProduct(int productID) {
            Product dbEntry = _db.Products
                .FirstOrDefault(p => p.ProductID == productID);
            if (dbEntry != null) {
                _db.Products.Remove(dbEntry);
                _db.SaveChanges();
            }
            return dbEntry;
        }

    }
}