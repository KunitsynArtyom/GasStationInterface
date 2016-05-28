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
    public class DBUserController
    {
        List<string> ErrorList = new List<string>();

        public DBUserController()
        {

        }

        public bool checkAddition(DBUser user)
        {
            bool checkFlag = true;
            if (user.GetDBUserLogin() == String.Empty || user.GetDBUserLogin().Length < 4 && !user.GetDBUserRole().Equals("worker"))
            {
                checkFlag = false;
                ErrorList.Add("Логин должн быть не меньше 4 символов!");
            }
            if (user.GetDBUserPass() == String.Empty || user.GetDBUserPass().Length < 6)
            {
                checkFlag = false;
                ErrorList.Add("Пароль должн быть не меньше 6 символов!");
            }
            if (user.GetDBUserRole() == String.Empty)
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
