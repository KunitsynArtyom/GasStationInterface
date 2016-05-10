﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Queries.combBoxFillers
{
    public class comboBoxStaffFiller
    {
        ComboBox cb;
        //ArrayList comboBoxElements;
        List<string> comboBoxElements;
        AdminQuery adminQuery;

        public comboBoxStaffFiller(ComboBox cb, AdminQuery adminQuery)
        {
            this.cb = cb;
            this.adminQuery = adminQuery; ;
        }

        public void cb_orgFill()
        {
            comboBoxElements = adminQuery.GetOrganisations();
            foreach (string st in comboBoxElements)
            {
                cb.Items.Add(st);
            }
        }

        public void cb_stationFill(string Orgname)
        {
            comboBoxElements = adminQuery.GetStationsAdres(Orgname);
            foreach (string st in comboBoxElements)
            {
                string cbString = RemoveSpaces(st);
                cb.Items.Add(cbString);
            }
        }

        private string RemoveSpaces(string inputString)
        {
            inputString = inputString.Replace("  ", string.Empty);
            inputString = inputString.Trim().Replace(" ", string.Empty);

            return inputString;
        }
    }
}
