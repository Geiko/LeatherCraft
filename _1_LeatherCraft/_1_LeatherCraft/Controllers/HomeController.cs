using _1_LeatherCraft.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_LeatherCraft.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        public ActionResult Index ( )
        {
            return View ( );
        }

        public ActionResult ChangeCulture ( string lang )
        {
            //string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список культур
            List<string> cultures = new List<string> ( ) { "ru", "en", "ua" };
            if ( !cultures.Contains ( lang ) )
            {
                lang = "ua";
            }
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies [ "lang" ];
            if ( cookie != null )
                cookie.Value = lang;   // если куки уже установлено, то обновляем значение
            else
            {

                cookie = new HttpCookie ( "lang" );
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears ( 1 );
            }
            Response.Cookies.Add ( cookie );

            return View("Index");
            //return Redirect ( returnUrl );
        }
    }
}