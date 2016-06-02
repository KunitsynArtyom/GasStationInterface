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
using Queries.Validators;
using Queries.Interfaces;

namespace Admin
{
    public partial class AddToStationTableForm : Form
    {
    public Form af;
        private IRepositoryFactory factory;
        private DataGridView dgv;
        private string orgname, country, city, street;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                orgname = tbOrgName.Text.ToString();
                country = tbCountry.Text.ToString();
                city = tbCity.Text.ToString();
                street = tbStreet.Text.ToString();
                int storagecap;
                bool checkStorageCap = Int32.TryParse(tbStorageCap.Text, out storagecap);
                if (!checkStorageCap)
                {
                    //MessageBox.Show("Объемы цистерн заданы неверно!");
                    storagecap = -1;
                }
                else
                {
                    Station st = new Station();
                    st.stationSet(orgname, country, city, street, storagecap);
                    StationController stationController = new StationController(dgv, factory);
                    if (stationController.AddToTable(st))
                    {
                        MessageBox.Show("Операция выполнена успешно!");
                        Close();
                    }
                }
            }
            catch (Exception) { MessageBox.Show("Данные введены некорректно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
