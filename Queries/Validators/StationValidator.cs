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
    public class StationValidator
    {

        public StationValidator()
        {

        }

        public bool checkAddition(Station st, out List<string> errorList)
        {
            errorList = new List<string>();
            bool checkFlag = true;
            if (st.GetOrgName() == String.Empty)
            {
                checkFlag = false;
                errorList.Add("Название организации не задано!");
            }
            if (st.GetCountry() == String.Empty)
            {
                checkFlag = false;
                errorList.Add("Страна не задана!");
            }
            if (st.GetCity() == String.Empty)
            {
                checkFlag = false;
                errorList.Add("Город не задан!");
            }
            if (st.GetStreet() == String.Empty)
            {
                checkFlag = false;
                errorList.Add("Улица не задана!");
            }
            if (st.GetStorageCap() < 300)
            {
                checkFlag = false;
                errorList.Add("Объем хранилища введен неверно!");
                //errorList.Add("Хранилище топлива должно хранить минимум 300 литров!");
            }

            return checkFlag;
        }
    }
}
