using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CodeFirst.Helpers;

namespace CodeFirst.Controllers
{
    public class BaseController : Controller
    {
        public string CultureName = null;

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            this.CultureName = CultureHelper.getCultureName();
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(this.CultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            return base.BeginExecuteCore(callback, state);
        }

        protected void forward404Unless(bool result)
        {
            if (result != true)
            {
                throw new HttpException(404, "Not found");
            }
        }

    }
}
