﻿using System;
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
using System.Text.RegularExpressions;

namespace Queries.Validators
{
    public class StationValidator
    {

        public StationValidator()
        {

        }

        public bool CheckAddition(Station st, out List<string> errorList)
        {
            string pattern = "^[А-ЯA-Z]{1}[а-яa-z]+ ?([А-ЯA-Z]{1}[а-яa-z]+ )?[0-9]+$";
            Regex rgx = new Regex(pattern);
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
            if (st.GetStreet() != String.Empty)
            {
                Match matches = rgx.Match(st.GetStreet());
                if (!matches.Success)
                {
                    checkFlag = false;
                    errorList.Add("Улица задана неверно!");
                }
            }
            if (st.GetStorageCap() < 300)
            {
                checkFlag = false;
                errorList.Add("Хранилище топлива должно хранить минимум 300 литров!");
            }

            return checkFlag;
        }
    }
}
