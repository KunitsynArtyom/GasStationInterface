using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Validators
{
    public class LoginValidator
    {
        public LoginValidator()
        {

        }

        public bool checkGetRole(string role, out List<string> errorList)
        {
            errorList = new List<string>();
            bool checkFlag = true;
            if (role == String.Empty)
            {
                checkFlag = false;
                errorList.Add("Роль не задана!");
            }

            return checkFlag;
        }
    }
}
