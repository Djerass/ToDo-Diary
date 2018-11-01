using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diary.Service
{
    public class CookieController : Controller
    {
        private protected DateTime ReadDateCookie(string key)
        {
            //check: Are we allready have DateCookie  
            //if  we have theirs  - read
            //if we haven`t create default
            var res =   Request.Cookies.TryGetValue(key, out var dateCookie);
            if (!res)
            {
                dateCookie = DateTime.Now.Date.ToString();
            }
            DateTime.TryParse(dateCookie, out DateTime DateRes);
            return DateRes;
        }

        private protected string ReadCookie(string key)
        {
            Request.Cookies.TryGetValue(key, out var cookieRes);
            return cookieRes;
        }
        
        //Delete old cookies and add new
        private protected void SwapCookie(string key,string value)
        {
            Response.Cookies.Delete(key);
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(3);       
            Response.Cookies.Append(key,value,cookie);
        }
    
    }
}