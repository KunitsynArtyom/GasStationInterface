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
using Queries.Repositories;
using Queries.Interfaces;

namespace Queries.Validators
{
    public class StaffValidator
    {

        public StaffValidator()
        {

        }

        public bool checkAddition(Worker wk, out List<string> errorList)
        {
            errorList = new List<string>();
            bool checkFlag = true;
            if (wk.GetStation_id() <= 0)
            {
                checkFlag = false;
            }
            if (wk.GetSurname() == String.Empty)
            {
                checkFlag = false;
                errorList.Add("Фамилия не задана!");
            }
            if (wk.GetName() == String.Empty)
            {
                checkFlag = false;
                errorList.Add("Имя не задано!");
            }
            if (wk.GetGender() == String.Empty)
            {
                checkFlag = false;
                errorList.Add("Пол не выбран!");
            }
            if (wk.GetFunction() == String.Empty)
            {
                checkFlag = false;
                errorList.Add("Должность не задана!");
            }
            if (wk.GetSalary() < 500)
            {
                checkFlag = false;
                errorList.Add("Зарплата не может быть дробным числом или быть меньше 500 у.е!");
            }

            return checkFlag;
        }

        public bool checkUpdate(int id, Worker wk, out List<string> errorList)
        {
            errorList = new List<string>();
            bool checkFlag = true;
            if (wk.GetSurname() == String.Empty)
            {
                checkFlag = false;
                errorList.Add("Фамилия не задана!");
            }
            if (wk.GetName() == String.Empty)
            {
                checkFlag = false;
                errorList.Add("Имя не задано!");
            }
            if (wk.GetGender() == String.Empty)
            {
                checkFlag = false;
                errorList.Add("Пол не выбран!");
            }
            if (wk.GetFunction() == String.Empty)
            {
                checkFlag = false;
                errorList.Add("Должность не задана!");
            }
            if (wk.GetSalary() < 500)
            {
                checkFlag = false;
                errorList.Add("Зарплата не может быть меньше 500 у.е!");
            }
            if (id < 0)
            { checkFlag = false; }

            return checkFlag;
        }

        public bool checkDelete(int id, out List<string> errorList)
        {
            errorList = new List<string>();
            bool checkFlag = true;
            if (id < 0)
            {
                checkFlag = false;
                errorList.Add("Сотрудник не обнаружен!");
            }

            return checkFlag;
        }
    }
}
