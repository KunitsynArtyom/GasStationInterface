using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Queries.Interfaces;
using Queries.Entities;
using Queries.Controllers;
using Queries.dgvControllers;

namespace Worker
{
    public partial class addToSupplyTableForm : Form
    {
        IRepositoryFactory factory;
        DataGridView dgv;
        int id, station_id, staff_id, fuelamount;
        string fueltype;
        DateTime supplydate;

        public addToSupplyTableForm(int id, IRepositoryFactory factory, DataGridView dgv)
        {
            InitializeComponent();
            this.id = id;
            this.factory = factory;
            this.dgv = dgv;
        }

        private void addToSupplyTableForm_Load(object sender, EventArgs e)
        {
            cbFuelType.Items.Add("A92");
            cbFuelType.Items.Add("A95");
            cbFuelType.Items.Add("A95+");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbFuelType.SelectedIndex != -1)
                {
                    fueltype = Convert.ToString(cbFuelType.Text);
                }
                fuelamount = Convert.ToInt32(tbFuelAmount.Text);
                supplydate = Convert.ToDateTime(supplyDateTimePick.Text);
                Supply sup = new Supply();
                sup.supplySet(factory.GetStaffRepository().FindStationIDByStaffID(id), id, fueltype, fuelamount, supplydate);
                SupplyController sc = new SupplyController();
                if (sc.checkAddition(sup))
                {
                    dgvSupplyController dgsc = new dgvSupplyController(dgv, factory);
                    dgsc.addToSupplyTable(sup);
                }
            }
            catch (Exception ex) { MessageBox.Show("Данные введены неверно!"); }
        }
    }
}
