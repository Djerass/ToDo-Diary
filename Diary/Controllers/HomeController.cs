using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Diary.Models;
using Diary.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly  IToDoRepository _db;
        private readonly Iid _id;
        public HomeController(IToDoRepository _db,Iid _id)
        {
            this._db=_db;      
            this._id=_id;
        }
        
        public IActionResult Index()
        {
            string dateCookie;
            //check: Are we have DateCookie and ShowCookie allready
            //if  we have theirs  - read
            //if we haven`t create default
            try
                {
                    dateCookie=Request.Cookies["DateToDo"].ToString();
                }
            catch(NullReferenceException)
                {
                    dateCookie=DateTime.Now.Date.ToString();
                }
            DateTime.TryParse(dateCookie,out DateTime DateRes);
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
                var userId = _id.TakeId(this.User); //taking current user Id
                return View(_db.GetAll.OrderBy(x=>x.Date).Where(x=>x.UserId==userId).Where(x=>x.Date.Date==DateRes.Date).ToList());
                }
            else 
                {
                var userId = _id.TakeId(this.User); //taking current user Id
                return View(_db.GetAll.Where(x=>x.Status==false).Where(x=>x.UserId==userId).OrderBy(x=>x.Date).Where(x=>x.Date.Date==DateRes.Date).ToList());
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
            await  _db.ChangeStatus(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)=> View(_db.Find(Id));
        
        [HttpPost]
        public async Task<IActionResult> Edit(ToDo toDo,DateTime time)
        {
          toDo.Date= toDo.Date.AddHours(time.Hour);
          toDo.Date=toDo.Date.AddMinutes(time.Minute);
          await _db.Update(toDo);
          return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(int Id)
        {
            await _db.Delete(Id);
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
            var userId = _id.TakeId(this.User);
            todo.UserId = userId;
             await _db.Add(todo);
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
         public IActionResult Stat()
         {
             var userId=_id.TakeId(this.User);
            Statistic stat = new Statistic(_db.GetAll.Where(i=>i.UserId==userId).ToArray());
            ViewData["AllCount"]=stat.CountAll;
            ViewData["NotFinishedCount"]=stat.CountNotFinished;
            ViewData["FailedCount"]=stat.CountFailed;
            return View(stat.Failed());
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
