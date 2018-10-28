using System.Collections.Generic;
using System.Linq;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.Repositories
{
    
        public interface IProductRepository
        {
            IQueryable<Product> GetAll();
        }
    
  
}