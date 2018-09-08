using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.Controllers
{
    public class HomeController : Controller
    {
      private readonly  IToDoRepository db;
        
        public HomeController(IToDoRepository _db)
        {
            db=_db;
            
            
        }
        public IActionResult Index()
        {
        string r;
        try
        {
         r = Request.Cookies["Show"].ToString();
        }
        catch(NullReferenceException)
        {
            r="All";
        }
        if(r.Equals("All"))
        return View(db.GetAll.ToList().OrderBy(x=>x.Date));
        else 
        return View(db.GetAll.ToList().Where(x=>x.Status==false).OrderBy(x=>x.Date));
        }
     
        // public IActionResult Index(bool All)=>View(All==true?db.GetAll.ToList().OrderBy(x=>x.Date):db.GetAll.Where(x=>x.Status==false).ToList().OrderBy(x=>x.Date));
        [HttpPost]
        public IActionResult Index(DateTime date)=>View(db.GetAll.Where(x=>x.Date.Date==date.Date).OrderBy(x=>x.Date).ToList());
        public async Task<IActionResult> Change(int Id)
        {
        await  db.ChangeStatus(Id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int Id)
        {
            await db.Delete(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateToDo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateToDo(ToDo todo,DateTime time)
        {
          
            
            if(!ModelState.IsValid)
            {
                return View();
                
            }
            todo.Date=todo.Date.AddHours(time.Hour);
            todo.Date=todo.Date.AddMinutes(time.Minute);
            
             await db.Add(todo);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeViewtoAll()
         {
            Response.Cookies.Delete("Show");
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(3);       
            Response.Cookies.Append("Show","All",cookie);
            return RedirectToAction("Index");
         }
         public IActionResult ChangeViewtoFalse()
         {   
            Response.Cookies.Delete("Show");
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(3);       
            Response.Cookies.Append("Show","False",cookie);
            
            return RedirectToAction("Index");
         }
    
           
        

    }
}
