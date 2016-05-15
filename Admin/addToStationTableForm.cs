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
using Queries.Controllers;

namespace Admin
{
    public partial class addToStationTableForm : Form
    {
    public Form af;
    DBConnection dbc;
    StationRepository stationQuery;
    DataGridView dgv;
    string orgname, country, city, street;
    int storagecap;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                orgname = tbOrgName.Text.ToString();
                country = tbCountry.Text.ToString();
                city = tbCity.Text.ToString();
                street = tbStreet.Text.ToString();
                storagecap = Convert.ToInt32(tbStorageCap.Text);
                Station st = new Station();
                st.stationSet(orgname, country, city, street, storagecap);
                StationController sc = new StationController(dgv, dbc);
                sc.checkAddition(st);
            }
            catch (Exception) { MessageBox.Show("Данные введены некорректно!"); }
            Close();
        }

        public addToStationTableForm(Form adminForm, DBConnection dbc, DataGridView dgv)
        {
            InitializeComponent();
            af = adminForm;
            this.dbc = dbc;
            this.dgv = dgv;
            stationQuery = new StationRepository(dbc);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
            af.Show();
        }
    }
}
