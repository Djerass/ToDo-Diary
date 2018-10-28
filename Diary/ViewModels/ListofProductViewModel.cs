using System.Collections.Generic;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.ViewModels
{
    public class ListofProductViewModel
    {
        public PageInfo PageInfo { get; set; }
        public IEnumerable<Product> Products{get; set; }
        public string CurrentCategory { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}