using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace CodeFirst.Models
{
    public partial class SystemUser
    {
        private SampleContext db = new SampleContext();

        public static SystemUser Instance
        {
            get { return new SystemUser(); }
        }

        public SystemUser findOneById(Guid id)
        {
            SystemUser SystemUser = db.SystemUsers.Include(x => x.SystemRoles).FirstOrDefault(x => x.ID == id);
            return SystemUser;
        }
    }
}