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
    public class StaffController
    {
        List<string> ErrorList = new List<string>();

        public StaffController()
        {

        }

        public bool checkAddition(Worker wk)
        {
            bool checkFlag = true;
            if (wk.GetStation_id() <= 0)
            {
                checkFlag = false;
            }
            if (wk.GetSurname() == String.Empty)
            {
                checkFlag = false;
                ErrorList.Add("Фамилия не введена!");
            }
            if (wk.GetName() == String.Empty)
            {
                checkFlag = false;
                ErrorList.Add("Имя не введено!");
            }
            if (wk.GetGender() == String.Empty)
            {
                checkFlag = false;
                ErrorList.Add("Пол не выбран!");
            }
            if (wk.GetFunction() == String.Empty)
            {
                checkFlag = false;
                ErrorList.Add("Назначение не выбрано!");
            }
            if (wk.GetSalary() < 500)
            {
                checkFlag = false;
                ErrorList.Add("Зарплата не может быть меньше 500 у.е!");
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

        public bool checkUpdate(int id, Worker wk)
        {
            bool checkFlag = true;
            if (wk.GetSurname() == String.Empty)
            {
                checkFlag = false;
                ErrorList.Add("Фамилия не введена!");
            }
            if (wk.GetName() == String.Empty)
            {
                checkFlag = false;
                ErrorList.Add("Имя не введено!");
            }
            if (wk.GetGender() == String.Empty)
            {
                checkFlag = false;
                ErrorList.Add("Пол не введен!");
            }
            if (wk.GetFunction() == String.Empty)
            {
                checkFlag = false;
                ErrorList.Add("Назначение не введено!");
            }
            if (wk.GetSalary() < 500)
            {
                checkFlag = false;
                ErrorList.Add("Зарплата не может быть меньше 500 у.е!");
            }
            if (id < 0)
            { checkFlag = false; }
            if (checkFlag == false)
            {
                foreach (string str in ErrorList)
                {
                    MessageBox.Show(str);
                }
            }

            return checkFlag;
        }

        public bool checkDelete(int id)
        {
            bool checkFlag = true;
            if (id < 0)
            {
                checkFlag = false;
                ErrorList.Add("Сотрудник не обнаружен!");
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
