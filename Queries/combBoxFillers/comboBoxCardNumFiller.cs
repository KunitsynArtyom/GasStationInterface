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
using Queries.dgvMediators;
using Queries.combBoxFillers;
using Queries.TableRepositories;

namespace Queries.combBoxFillers
{
    public class comboBoxCardNumFiller
    {
        ComboBox cb;
        List<string> comboBoxElements;
        NpgsqlConnection conn;
        CarRepository carQuery;
        public comboBoxCardNumFiller(ComboBox cb, NpgsqlConnection conn)
        {
            this.cb = cb;
            this.conn = conn;
            carQuery = new CarRepository(conn);
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
