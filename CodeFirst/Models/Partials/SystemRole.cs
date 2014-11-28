using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Models
{
    public partial class SystemRole
    {
        private SampleContext db = new SampleContext();

        public static SystemRole Instance
        {
            get { return new SystemRole(); }
        }

        public List<SelectListItem> getActiveSystemRolesForSelectList(SystemUser systemuser)
        {
            var SystemRoles = db.SystemRoles.Where(sr => sr.IsEnable).ToList();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (SystemRole SystemRole in SystemRoles)
            {
                var item = new SelectListItem()
                {
                    Text = SystemRole.Name,
                    Value = SystemRole.ID.ToString(),
                    Selected = (systemuser.SystemRoles.Where(sr => sr.ID == SystemRole.ID).Count()>0)
                };
                items.Add(item);
            }

            return items;
        }

        public string getNameForOutput()
        {
            return this.Name + " Wong";
        }
    }
}