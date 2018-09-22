using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Diary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly  IToDoRepository db;
        private readonly Iid id;
        public HomeController(IToDoRepository _db,Iid _id)
        {
            db=_db;      
            id=_id;
        }
        
        public IActionResult Index()
        {
            string DateCookie;
            //check: Are we have DateCookie and ShowCookie allready
            //if  we have theirs  - read
            //if we haven`t create default
            try
                {
                    DateCookie=Request.Cookies["DateToDo"].ToString();
                }
            catch(NullReferenceException)
                {
                    DateCookie=DateTime.Now.Date.ToString();
                }
            DateTime.TryParse(DateCookie,out DateTime DateRes);
            ViewData["DateToDo"]=DateRes.ToShortDateString();
            string ShowCookieRes;
            try
                {
                    ShowCookieRes = Request.Cookies["Show"].ToString();
                }
            catch(NullReferenceException)
                {
                     ShowCookieRes="All";
                }
            ViewData["Show"]=ShowCookieRes;
             //if ShowCookie == "All" make model with all TodoS 
             //else make model with only false ToDos
             //Date of ToDos is from DateCookie
            if(ShowCookieRes.Equals("All"))
                {
                var userId = id.TakaId(this.User); //taking current user Id
                return View(db.GetAll.OrderBy(x=>x.Date).Where(x=>x.UserId==userId).Where(x=>x.Date.Date==DateRes.Date).ToList());
                }
            else 
                {
                var userId = id.TakaId(this.User); //taking current user Id
                return View(db.GetAll.Where(x=>x.Status==false).Where(x=>x.UserId==userId).OrderBy(x=>x.Date).Where(x=>x.Date.Date==DateRes.Date).ToList());
                }
        }
       
     
        // public IActionResult Index(bool All)=>View(All==true?db.GetAll.ToList().OrderBy(x=>x.Date):db.GetAll.Where(x=>x.Status==false).ToList().OrderBy(x=>x.Date));
        [HttpPost]
        public IActionResult ChooseDate(DateTime date)
        {
            SwapCookie("DateToDo",date.ToShortDateString());
           
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Change(int Id)
        {
            await  db.ChangeStatus(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)=> View(db.Find(Id));
        
        [HttpPost]
        public async Task<IActionResult> Edit(ToDo toDo,DateTime time)
        {
          toDo.Date= toDo.Date.AddHours(time.Hour);
          toDo.Date=toDo.Date.AddMinutes(time.Minute);
          await db.Update(toDo);
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
            var userId = id.TakaId(this.User);
            todo.UserId = userId;
             await db.Add(todo);
             return RedirectToAction("Index");
        }

        public IActionResult ChangeViewtoAll()
         {
            SwapCookie("Show","All");
            return RedirectToAction("Index");
         }
         public IActionResult ChangeViewtoFalse()
         {   
            SwapCookie("Show","False");
            return RedirectToAction("Index");
         }
       
        private void SwapCookie(string key,string value)
        {
            Response.Cookies.Delete(key);
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(3);       
            Response.Cookies.Append(key,value,cookie);
        }
           
        

    }
}
