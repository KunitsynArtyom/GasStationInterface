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
    public partial class AddToSupplyTableForm : Form
    {
        IRepositoryFactory factory;
        DataGridView dgv;
        int id, fuelamount, hours, minutes;
        string fueltype;
        DateTime supplydate;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
        }

        private void checkNow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNow.Checked)
            {
                tbHours.Visible = false;
                tbMinutes.Visible = false;
                label5.Visible = false;
                label4.Visible = false;
            }
            if (!checkNow.Checked)
            {
                tbHours.Visible = true;
                tbMinutes.Visible = true;
                label5.Visible = true;
                label4.Visible = true;
            }
        }

        public AddToSupplyTableForm(int id, IRepositoryFactory factory, DataGridView dgv)
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
                if (checkNow.Checked)
                {
                    supplydate = DateTime.Now;
                }
                if (!checkNow.Checked)
                {
                    //try
                    //{
                        hours = Convert.ToInt32(tbHours.Text);
                        minutes = Convert.ToInt32(tbMinutes.Text);
                    //}
                    //catch (Exception ex) { }
                }
                
                supplydate = Convert.ToDateTime(supplyDateTimePick.Text);
            if (checkNow.Checked)
            {
                supplydate = DateTime.Now;
            }
            else
            {
                //try
                //{
                    supplydate = supplydate.AddHours(hours);
                    supplydate = supplydate.AddMinutes(minutes);
                //}
                //catch (Exception ex) { }
            }
            //if (checkNow.Checked)
            //    {
            //        supplydate = DateTime.Now;
            //    }
                Supply sup = new Supply();
                sup.supplySet(factory.GetStaffRepository().FindStationIDByStaffID(id), id, fueltype, fuelamount, supplydate);
                SupplyController sc = new SupplyController();
                if (sc.checkAddition(sup))
                {
                    dgvSupplyController dgsc = new dgvSupplyController(dgv, factory);
                    dgsc.addToSupplyTable(sup);                }
            }
            catch (Exception ex) { MessageBox.Show("Данные введены неверно!"); }
            //Close();
        }
    }
}
