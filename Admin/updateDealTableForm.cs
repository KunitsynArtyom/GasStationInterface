﻿using System;
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
using Queries.dgvMediators;
using Queries.combBoxFillers;

namespace Admin
{
    public partial class updateDealTableForm : Form
    {
        public Form af;
        AdminQuery adminQuery;
        DataGridViewRow updateRow;
        DataGridView dgv;
        int fuelamount, dealprice;
        string fueltype, cardnum;
        DateTime dealdate;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (cbFuelType.SelectedIndex != -1)
                    {
                        fueltype = Convert.ToString(cbFuelType.Text);
                    }
                }
                catch (Exception) { MessageBox.Show("Данные введены некорректно!"); }
                fuelamount = Convert.ToInt32(tb_fuelamount.Text);
                try
                {
                    if (cbCardNum.SelectedIndex != -1)
                    {
                        cardnum = Convert.ToString(cbCardNum.Text);
                    }
                }
                catch (Exception) { MessageBox.Show("Данные введены некорректно!"); }
                dealprice = Convert.ToInt32(tb_dealprice.Text);
                dealdate = Convert.ToDateTime(dealDatePick.Text);

            }
            catch (Exception ex) { MessageBox.Show("Данные введены некорректно!"); }
            Deal deal = new Deal();
            deal.dealSet(fueltype, fuelamount, dealprice, cardnum, dealdate);
            dgvDealFiller dgds = new dgvDealFiller(dgv, adminQuery);
            dgds.updateTable(updateRow.Index, deal);
            Close();
        }

        public updateDealTableForm(DataGridViewRow updateRow, AdminQuery adminQuery, DataGridView dgv)
        {
            InitializeComponent();
            this.updateRow = updateRow;
            this.adminQuery = adminQuery;
            this.dgv = dgv;
        }

        private void updateDealTableForm_Load(object sender, EventArgs e)
        {
            tb_fuelamount.Text = updateRow.Cells["fuelamount"].Value.ToString();
            tb_dealprice.Text = updateRow.Cells["dealprice"].Value.ToString();
            cbFuelType.Items.Add("A92");
            cbFuelType.Items.Add("A95");
            cbFuelType.Items.Add("A95+");
            comboBoxDealFiller cbdf;
            cbdf = new comboBoxDealFiller(cbCardNum, adminQuery);
            cbdf.cb_cardnumFill();
            //cbCardNum.Items.Add("");
        }
    }
}