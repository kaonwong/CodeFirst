using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    public class ErrorController : BaseController
    {

        public ActionResult NotFound()
        {
            return Content("error 404, page not found.");
        }

    }
}
