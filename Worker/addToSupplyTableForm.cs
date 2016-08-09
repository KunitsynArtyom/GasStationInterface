﻿using System;
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
using Queries.Validators;
using Queries.dgvControllers;

namespace Worker
{
    public partial class AddToSupplyTableForm : Form
    {
        private IRepositoryFactory factory;
        private DataGridView dgv;
        private int id, fuelamount, hours, minutes;
        private string fueltype;
        private DateTime supplydate;

        private void btnCancel_Click(object sender, EventArgs e)
        {
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

        private void tbFuelAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void tbHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void tbMinutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
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
                        hours = Convert.ToInt32(tbHours.Text);
                        minutes = Convert.ToInt32(tbMinutes.Text);
                }
                
                supplydate = Convert.ToDateTime(supplyDateTimePick.Text);
                if (checkNow.Checked)
                {
                    supplydate = DateTime.Now;
                }
                else
                {
                    supplydate = supplydate.AddHours(hours);
                    supplydate = supplydate.AddMinutes(minutes);
                }
                Supply sup = new Supply();
                sup.supplySet(factory.GetStaffRepository().FindStationIDByStaffID(id), id, fueltype, fuelamount, supplydate);
                SupplyController supplyController = new SupplyController(dgv, factory);
                if (supplyController.AddToSupplyTable(sup))
                {
                    MessageBox.Show("Операция выполнена успешно!");
                    Close();
                }
            }
            catch (Exception) { MessageBox.Show("Данные введены некорректно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
