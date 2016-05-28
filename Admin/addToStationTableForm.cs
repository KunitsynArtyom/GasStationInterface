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
using Queries.Interfaces;

namespace Admin
{
    public partial class AddToStationTableForm : Form
    {
    public Form af;
    IRepositoryFactory factory;
    StationRepository stationQuery;
    DataGridView dgv;
    string orgname, country, city, street;
    int storagecap;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> ErrorList = new List<string>();
            try
            {
                if (tbStorageCap.Text == String.Empty)
                {
                    ErrorList.Add("Недопустимые объемы резервуаров!");
                }
                if (ErrorList.Count != 0)
                {
                    foreach (string str in ErrorList)
                    {
                        MessageBox.Show(str);
                    }
                }

                orgname = tbOrgName.Text.ToString();
                country = tbCountry.Text.ToString();
                city = tbCity.Text.ToString();
                street = tbStreet.Text.ToString();
                storagecap = Convert.ToInt32(tbStorageCap.Text);
                Station st = new Station();
                st.stationSet(orgname, country, city, street, storagecap);
                StationController sc = new StationController();
                if (sc.checkAddition(st))
                {
                    dgvStationController dgsc = new dgvStationController(dgv, factory);
                    dgsc.addToTable(st);
                }
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
            //stationQuery = factory.GetStationRepository(); ;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
            af.Show();
        }
    }
}
