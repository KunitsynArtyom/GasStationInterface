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

namespace Queries.comboBoxFillers
{
    public class comboBoxCardNumFiller
    {
        ComboBox cb;
        List<string> comboBoxElements;
        DBConnection dbc;
        CarRepository carQuery;
        public comboBoxCardNumFiller(ComboBox cb, DBConnection dbc)
        {
            this.cb = cb;
            this.dbc = dbc;
            carQuery = new CarRepository(dbc);
        }

        public void cb_CardNumFill()
        {
            comboBoxElements = carQuery.GetCardNumList();
            foreach (string st in comboBoxElements)
            {
                cb.Items.Add(st);
            }
        }
    }
}
