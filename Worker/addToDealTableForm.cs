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

namespace Worker
{
    public partial class addToDealTableForm : Form
    {
        public Form wf;
        DataGridView dgv;
        IRepositoryFactory factory;
        int ID, fuelamount, dealprice, hours, minutes;
        string fueltype, cardnum;
        DateTime dealdate;

        public addToDealTableForm(int ID, IRepositoryFactory factory, DataGridView dgv)
        {
            InitializeComponent();
            this.factory = factory;
            this.dgv = dgv;
            this.ID = ID;
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
                hours = Convert.ToInt32(tbHours.Text);
                minutes = Convert.ToInt32(tbMinutes.Text);
                dealdate = Convert.ToDateTime(dealDatePick.Text);
                dealdate = dealdate.AddHours(hours);
                dealdate = dealdate.AddMinutes(minutes);
                //dealDatePick.Value = dealDatePick.Value.AddHours(hours);
                //dealDatePick.Value = dealDatePick.Value.AddMinutes(minutes);
                Deal deal = new Deal();
                deal.dealSet(0, factory.GetCarRepository().FindCarIDByCardnum(cardnum), ID, fueltype, fuelamount, dealprice, cardnum, dealdate);
            dgvDealController dgdc = new dgvDealController(dgv, factory);
            dgdc.addToTable(deal);
            }
            catch (Exception ex) { MessageBox.Show("Данные введены неверно!"); }
        }

        private void updateDealTableForm_Load(object sender, EventArgs e)
        {
            cbFuelType.Items.Add("A92");
            cbFuelType.Items.Add("A95");
            cbFuelType.Items.Add("A95+");
            comboBoxDealFiller cbdf;
            cbdf = new comboBoxDealFiller(cbCardNum, factory);
            cbdf.cb_cardnumFill();
        }
    }
}
