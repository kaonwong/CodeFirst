using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirst.Helpers;

namespace CodeFirst.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SetCulture(string culture)
        {
            culture = CultureHelper.getImpletementedCulture(culture);
            HttpCookie cookie = Request.Cookies["Culture"];
            if (cookie != null)
            {
                cookie.Value = culture;
            }
            else
            {
                cookie = new HttpCookie("Culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }

    }
}
