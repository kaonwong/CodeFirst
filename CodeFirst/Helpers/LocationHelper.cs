using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Helpers
{
    public class LocationHelper
    {
        public static bool isCurrentControllerAndAction(string controller, string action, ViewContext viewContext)
        {
            if (viewContext == null) return false;
            if (string.IsNullOrEmpty(controller) || string.IsNullOrEmpty(action)) return false;

            string currentController = viewContext.RouteData.Values["controller"].ToString();
            string currentAction = viewContext.RouteData.Values["action"].ToString();
            if (currentController.ToLower().Equals(controller.ToLower()) && currentAction.ToLower().Equals(action.ToLower())) return true;
            return false;
        }
    }
}