using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Entities
{
    public class NewAdmin
    {
        public string adminLogin { private set; get; }
        public string adminPass { private set; get; }
        public string adminRole { private set; get; }

        public void setNewAdmin(string Login, string Pass, string Role)
        {
            adminLogin = Login;
            adminPass = Pass;
            adminRole = Role;
        }

        public string GetAdminLogin() => adminLogin;
        public string GetAdminPass() => adminPass;
        public string GetAdminRole() => adminRole;
    }
}
