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
using Queries.Validators;
using Queries.Interfaces;

namespace Admin
{
    public partial class UpdateDealTableForm : Form
    {
        public Form af;
        IRepositoryFactory factory;
        DataGridViewRow updateRow;
        DataGridView dgv;
        int fuelamount, dealprice, hours, minutes;
        string fueltype, cardnum;
        DateTime dealdate;

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
                   cardnum = Convert.ToString(cbCardNum.Text).Trim().Replace(" ", string.Empty);
                }
                dealprice = Convert.ToInt32(tbDealprice.Text);
                hours = Convert.ToInt32(tbHours.Text);
                minutes = Convert.ToInt32(tbMinutes.Text);
                dealdate = Convert.ToDateTime(dealDatePick.Text);
                dealdate = dealdate.AddHours(hours);
                dealdate = dealdate.AddMinutes(minutes);
                Deal deal = new Deal();
                deal.dealSet(fueltype, fuelamount, dealprice, cardnum, dealdate);
                var cell = dgv[0, dgv.CurrentRow.Index];
                int id = Convert.ToInt32(cell.Value);
                //DealValidator dc = new DealValidator();
                //if (dc.checkUpdate(id, deal))
                //{
                    DealController dgds = new DealController(dgv, factory);
                    dgds.updateTable(id, deal);
                //}
            } catch (Exception ex) { MessageBox.Show("Данные введены некорректно!"); }
                //Close();
        }

        public UpdateDealTableForm(DataGridViewRow updateRow, IRepositoryFactory factory, DataGridView dgv)
        {
            InitializeComponent();
            this.updateRow = updateRow;
            this.factory = factory;
            this.dgv = dgv;
        }

        private void updateDealTableForm_Load(object sender, EventArgs e)
        {
            tbFuelamount.Text = updateRow.Cells["fuelamount"].Value.ToString();
            tbDealprice.Text = updateRow.Cells["dealprice"].Value.ToString();
            cbFuelType.Items.Add("A92");
            cbFuelType.Items.Add("A95");
            cbFuelType.Items.Add("A95+");
            ComboBoxDealFiller comboBoxDealFiller = new ComboBoxDealFiller(cbCardNum, factory);
            comboBoxDealFiller.cbCardnumFill();
        }
    }
}
