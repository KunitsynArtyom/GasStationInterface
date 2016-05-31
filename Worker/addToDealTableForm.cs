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
using Queries.Interfaces;
using Queries.Validators;

namespace Worker
{
    public partial class AddToDealTableForm : Form
    {
        public Form wf;
        DataGridView dgv;
        IRepositoryFactory factory;
        int ID, fuelamount, dealprice, hours, minutes;
        string fueltype, cardnum;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        DateTime dealdate;

        public AddToDealTableForm(int ID, IRepositoryFactory factory, DataGridView dgv)
        {
            InitializeComponent();
            this.factory = factory;
            this.dgv = dgv;
            this.ID = ID;
        }

        private void checkNow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNow.Checked)
            {
                tbHours.Visible = false;
                tbMinutes.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
            }
            if (!checkNow.Checked)
            {
                tbHours.Visible = true;
                tbMinutes.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbFuelType.SelectedIndex != -1)
                {
                    fueltype = Convert.ToString(cbFuelType.Text);
                }
                fuelamount = Convert.ToInt32(tbFuelamount.Text);
                if (cbCardNum.SelectedIndex != -1)
                {
                    cardnum = Convert.ToString(cbCardNum.Text);
                    cardnum = cardnum.Trim().Replace(" ", string.Empty);
                }
                dealprice = Convert.ToInt32(tbDealPrice.Text);
                if (checkNow.Checked)
                {
                    dealdate = DateTime.Now;
                }
                if (!checkNow.Checked)
                {
                    hours = Convert.ToInt32(tbHours.Text);
                    minutes = Convert.ToInt32(tbMinutes.Text);
                }
                dealdate = Convert.ToDateTime(dealDatePick.Text);
                if (checkNow.Checked)
                {
                    dealdate = DateTime.Now;
                }
                else
                {
                    dealdate = dealdate.AddHours(hours);
                    dealdate = dealdate.AddMinutes(minutes);
                }

                Deal deal = new Deal();
                deal.dealSet(0, factory.GetCarRepository().FindCarIDByCardnum(cardnum), ID, fueltype, fuelamount, dealprice, cardnum, dealdate);
                //DealValidator dc = new DealValidator();
                //if (dc.checkAddition(deal))
                //{
                    DealController dealController = new DealController(dgv, factory);
                    dealController.addToTable(deal);
                    //MessageBox.Show("Сделка добавлена!");
                //}
            }
            catch (Exception ex) { MessageBox.Show("Данные введены неверно!"); }
            //Close();
        }

        private void updateDealTableForm_Load(object sender, EventArgs e)
        {
            cbFuelType.Items.Add("A92");
            cbFuelType.Items.Add("A95");
            cbFuelType.Items.Add("A95+");
            ComboBoxDealFiller  comboBoxDealFiller = new ComboBoxDealFiller(cbCardNum, factory);
            comboBoxDealFiller.cbCardnumFill();
        }
    }
}
