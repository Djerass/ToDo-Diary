using Microsoft.AspNetCore.Mvc;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.Component
{
    public class CartSummaryViewComponent:ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService) {
            cart = cartService;
        }
        public IViewComponentResult Invoke() {
           return  View(cart);
        }
    }
}