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

namespace Queries.Controllers
{
    public class StationController
    {
        DBConnection dbc;
        StationRepository stationQuery;
        DataGridView dgv;
        dgvStationController dgsc;

        public StationController(DataGridView dgv, DBConnection dbc)
        {
            stationQuery = new StationRepository(dbc);
            this.dgv = dgv;
            dgsc = new dgvStationController(dgv, dbc);
        }

        public void checkAddition(Station st)
        {
            bool checkFlag = true;
            if (st.GetOrgName() == String.Empty)
            { checkFlag = false; }
            if (st.GetCountry() == String.Empty)
            { checkFlag = false; }
            if (st.GetCity() == String.Empty)
            { checkFlag = false; }
            if (st.GetStreet() == String.Empty)
            { checkFlag = false; }
            if (st.GetStorageCap() < 300)
            { checkFlag = false; }
            if (checkFlag == true)
            {
                dgsc.addToTable(st);
            }
            else
                MessageBox.Show("Данные были введены неправильно!");
        }
    }
}
