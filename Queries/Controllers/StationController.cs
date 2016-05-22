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
    public class StationController
    {
        List<string> ErrorList = new List<string>();

        public StationController()
        {

        }

        public bool checkAddition(Station st)
        {
            bool checkFlag = true;
            if (st.GetOrgName() == String.Empty)
            {
                checkFlag = false;
                ErrorList.Add("Название организации отсутсвует!");
            }
            if (st.GetCountry() == String.Empty)
            {
                checkFlag = false;
                ErrorList.Add("Поле для ввода страны пусто!");
            }
            if (st.GetCity() == String.Empty)
            {
                checkFlag = false;
                ErrorList.Add("Поле для ввода города пусто!");
            }
            if (st.GetStreet() == String.Empty)
            {
                checkFlag = false;
                ErrorList.Add("Поле для ввода улицы пусто!");
            }
            if (st.GetStorageCap() < 300)
            {
                checkFlag = false;
                ErrorList.Add("Хранилище топлива может быть минимум 300 литров!");
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
