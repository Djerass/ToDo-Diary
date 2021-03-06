﻿using System;
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
            string DateCookie;
            try
                {
                    DateCookie=Request.Cookies["Date"].ToString();
                }
            catch(NullReferenceException)
                {
                    DateCookie=DateTime.Now.Date.ToString();
                }
            DateTime.TryParse(DateCookie,out DateTime DateRes);
            string ShowCookieRes;
            try
                {
                    ShowCookieRes = Request.Cookies["Show"].ToString();
                }
            catch(NullReferenceException)
                {
                     ShowCookieRes="All";
                }
            if(ShowCookieRes.Equals("All"))
                return View(db.GetAll.OrderBy(x=>x.Date).Where(x=>x.Date.Date==DateRes.Date).ToList());
            else 
                return View(db.GetAll.Where(x=>x.Status==false).OrderBy(x=>x.Date).Where(x=>x.Date.Date==DateRes.Date).ToList());
        }
     
        // public IActionResult Index(bool All)=>View(All==true?db.GetAll.ToList().OrderBy(x=>x.Date):db.GetAll.Where(x=>x.Status==false).ToList().OrderBy(x=>x.Date));
        [HttpPost]
        public IActionResult ChooseDate(DateTime date)
        {
            Response.Cookies.Delete("Date");
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(3);       
            Response.Cookies.Append("Date",date.Date.ToString(),cookie);
            return RedirectToAction("Index");
        }
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
