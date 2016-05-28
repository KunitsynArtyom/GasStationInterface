using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;
using System.Collections;
using Queries;
using Queries.Entities;
using Queries.dgvControllers;
using Queries.comboBoxFillers;
using Queries.TableRepositories;
using Queries.Interfaces;

namespace Queries.Controllers
{
    public class NewAdminController
    {
        List<string> ErrorList = new List<string>();

        public NewAdminController()
        {

        }

        public bool checkAddition(NewAdmin admin)
        {
            bool checkFlag = true;
            if (admin.GetAdminLogin() == String.Empty || admin.GetAdminLogin().Length < 4)
            {
                checkFlag = false;
                ErrorList.Add("Логин должн быть не меньше 4 символов!");
            }
            if (admin.GetAdminPass() == String.Empty || admin.GetAdminPass().Length < 6)
            {
                checkFlag = false;
                ErrorList.Add("Пароль должн быть не меньше 6 символов!");
            }
            if (admin.GetAdminRole() == String.Empty || !admin.GetAdminRole().Equals("admin"))
            {
                checkFlag = false;
                ErrorList.Add("Роль указана неверно!");
            }
            if (checkFlag == false)
            {
                foreach (string str in ErrorList)
                {
                    MessageBox.Show(str);
                }
            }

            return checkFlag;
        }
    }
}
