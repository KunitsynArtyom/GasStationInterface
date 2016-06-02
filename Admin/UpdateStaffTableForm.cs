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
using Queries;
using Queries.Entities;
using Queries.dgvControllers;
using Queries.Validators;
using Queries.Interfaces;

namespace Admin
{
    public partial class UpdateStaffTableForm : Form
    {
        private IRepositoryFactory factory;
        private int salary;
        private string surname, name, gender, function;
        private DateTime birthdate;
        private DataGridViewRow updateRow;
        private DataGridView dgv;

        public UpdateStaffTableForm(DataGridViewRow updateRow, IRepositoryFactory factory, DataGridView dgv)
        {
            InitializeComponent();
            this.updateRow = updateRow;
            this.factory = factory;
            this.dgv = dgv;
        }

        private void updateStaffTableForm_Load(object sender, EventArgs e)
        {
            tbSurname.Text = updateRow.Cells["surname"].Value.ToString().Trim().Replace(" ", string.Empty);
            tbName.Text = updateRow.Cells["name"].Value.ToString().Trim().Replace(" ", string.Empty);
            tbFunction.Text = updateRow.Cells["function"].Value.ToString().Trim().Replace(" ", string.Empty);
            cbGender.Items.Add("муж");
            cbGender.Items.Add("жен");
            cbGender.SelectedItem = updateRow.Cells["gender"].Value.ToString().Trim().Replace(" ", string.Empty);
            tbFunction.Text = updateRow.Cells["function"].Value.ToString().Trim().Replace(" ", string.Empty);
            tbSalary.Text = updateRow.Cells["salary"].Value.ToString().Trim().Replace(" ", string.Empty);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                surname = tbSurname.Text;
                name = tbName.Text;
                if (cbGender.SelectedIndex != -1)
                {
                    gender = Convert.ToString(cbGender.Text);
                }
                else gender = String.Empty;
                birthdate = Convert.ToDateTime(birthDatePick.Text);
                function = tbFunction.Text;
                int salary;
                bool checkSalary = Int32.TryParse(tbSalary.Text, out salary);
                if (!checkSalary)
                {
                    salary = -1;
                }
                //salary = Convert.ToInt32(tbSalary.Text);
                Worker wk = new Worker();
                wk.workerSet(surname, name, gender, birthdate, function, salary);
                var cell = dgv[0, dgv.CurrentRow.Index];
                int id = Convert.ToInt32(cell.Value);
                StaffController staffController = new StaffController(dgv, factory);
                if (staffController.UpdateTable(id, wk))
                {
                    MessageBox.Show("Операция выполнена успешно!");
                    Close();
                }
            }
            catch (Exception) { MessageBox.Show("Данные введены некорректно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
