using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace CodeFirst.Helpers
{
    public static class CultureHelper
    {
        private static readonly List<string> ValidCulture = new List<string> { "zh-tw", "zh", "en", "en-us" };
        private static readonly List<string> Cultures = new List<string> { "en", "zh" };

        public static string getImpletementedCulture(string name)
        {
            if (string.IsNullOrEmpty(name)) return getDefaultCulture();
            if (ValidCulture.Where(vc => vc.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Count() == 0) return getDefaultCulture();
            if (ValidCulture.Where(vc => vc.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Count() > 0)
            {
                var neutralCulture = getNeutralCulture(name);
                foreach (var culture in Cultures)
                {
                    if (culture.StartsWith(neutralCulture))
                    {
                        return culture;
                    }
                }
            }
            return getDefaultCulture();
        }

        public static string getDefaultCulture()
        {
            return Cultures[0];
        }

        public static List<string> getCultures()
        {
            return Cultures;
        }

        public static string getCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }

        public static string getCurrentNeutralCulture()
        {
            return getNeutralCulture(getCurrentCulture());
        }

        public static string getNeutralCulture(string name)
        {
            if (name.Length <= 2) return name;
            return name.Substring(0, 2);
        }

        public static string getCultureName()
        {
            HttpCookie cultureCookie = HttpContext.Current.Request.Cookies["culture"];
            string cultureName = null;
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else
            {
                string[] userLanguages = HttpContext.Current.Request.UserLanguages;
                cultureName = (userLanguages != null && userLanguages.Length > 0) ? userLanguages[0] : null;
            }
            return getImpletementedCulture(cultureName);
        }
    }
}