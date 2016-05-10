using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Npgsql;
using Queries.Entities;

namespace Queries.combBoxFillers
{
    public class comboBoxDealFiller
    {
        ComboBox cb;
        ArrayList comboBoxElements;
        WorkerQuery workerQuery;
        AdminQuery adminQuery;

        public comboBoxDealFiller(ComboBox cb, WorkerQuery workerQuery)
        {
            this.cb = cb;
            this.workerQuery = workerQuery; ;
        }

        public comboBoxDealFiller(ComboBox cb, AdminQuery adminQuery)
        {
            this.cb = cb;
            this.adminQuery = adminQuery; ;
        }

        public void cb_orgFill()
        {
            comboBoxElements = workerQuery.getOrgList();
            foreach (string st in comboBoxElements)
            {
                cb.Items.Add(st);
            }
        }

        public void cb_stationFill(string Orgname)
        {
            comboBoxElements = workerQuery.getStationList(Orgname);
            foreach (string st in comboBoxElements)
            {
                string cbString = RemoveSpaces(st);
                cb.Items.Add(cbString);
            }
        }

        public void cb_cardnumFill()
        {
            List<Car> comboBoxCarElements = adminQuery.GetCars();
            foreach (Car car in comboBoxCarElements)
            {               
                cb.Items.Add(car.GetCardNum());
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
