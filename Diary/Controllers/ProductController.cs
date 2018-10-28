using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoDiaryWeb.Repositories;
using ToDoDiaryWeb.ViewModels;

namespace ToDoDiaryWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _db;

        public int PageSize = 4;
        // GET

        public ProductController(IProductRepository db)
        {
            _db = db;
            
        }

       

        public IActionResult Index(string currentCategory,int currentPage=1)
        {
            return View(new ListofProductViewModel()
                {
                    Products = _db.GetAll().Where(p=>currentCategory==null||p.Category==currentCategory)
                        .OrderBy(p => p.ProductID)
                        .Skip((currentPage - 1) * PageSize)
                        .Take(PageSize),
                    PageInfo = new PageInfo()
                        {CurrentPage = currentPage, TotalItems = currentCategory==null ?_db.GetAll().Count():_db.GetAll().Count(x => x.Category==currentCategory), ItemPerPage = PageSize},
                    CurrentCategory = currentCategory,
                    Categories = _db.GetAll().Select(p => p.Category).Distinct().OrderBy(x=>x)
                });

        }

      
    }
}