using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoDiaryWeb.Models;
using ToDoDiaryWeb.Repositories;

namespace ToDoDiaryWeb.Controllers
{
    public class OrderController : Controller
    {
        // GET
        private IOrderRepository repository;
        private Cart cart;
        
        public OrderController(IOrderRepository repoService, Cart cartService) {
            repository = repoService;
            cart = cartService;
        }
        public ViewResult List() =>
            View(repository.Orders.Where(o => !o.Shipped));
        
        [HttpPost]
        public IActionResult MarkShipped(int orderID) {
            Order order = repository.Orders
                .FirstOrDefault(o => o.OrderID == orderID);
            if (order != null) {
                order.Shipped = true;
                repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }
        
        public IActionResult Checkout()=>View(new Order());
        
        
        [HttpPost]
        public IActionResult Checkout(Order order) {
            if (cart.Lines.Count() == 0) {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid) {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            } else {
                return View(order);
            }
        }
        public ViewResult Completed() {
            cart.Clear();
            return View();
        }
    }
}