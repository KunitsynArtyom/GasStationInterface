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
using Queries.Validators;
using Queries.Interfaces;

namespace Admin
{
    public partial class AddToStationTableForm : Form
    {
    public Form af;
    IRepositoryFactory factory;
    DataGridView dgv;
    string orgname, country, city, street;
    int storagecap;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> ErrorList = new List<string>();
            try
            {
                orgname = tbOrgName.Text.ToString();
                country = tbCountry.Text.ToString();
                city = tbCity.Text.ToString();
                street = tbStreet.Text.ToString();
                storagecap = Convert.ToInt32(tbStorageCap.Text);
                Station st = new Station();
                st.stationSet(orgname, country, city, street, storagecap);
                //StationValidator sc = new StationValidator();
                //if (sc.checkAddition(st))
                //{
                StationController stationController = new StationController(dgv, factory);
                stationController.addToTable(st);
                //}
            }
            catch (Exception) { MessageBox.Show("Данные введены некорректно!"); }
            //Close();
        }

        public AddToStationTableForm(Form adminForm, IRepositoryFactory factory, DataGridView dgv)
        {
            InitializeComponent();
            af = adminForm;
            this.factory = factory;
            this.dgv = dgv;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            af.Show();
        }
    }
}
