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
using Queries;
using Queries.Entities;
using Queries.dgvControllers;
using Queries.Validators;
using Queries.Interfaces;

namespace Admin
{
    public partial class UpdateStaffTableForm : Form
    {
        public Form af;
        IRepositoryFactory factory;
        int manager, salary;
        string surname, name, gender, function;
        DateTime birthdate;
        DataGridViewRow updateRow;
        DataGridView dgv;

        public UpdateStaffTableForm(DataGridViewRow updateRow, IRepositoryFactory factory, DataGridView dgv)
        {
            InitializeComponent();
            this.updateRow = updateRow;
            this.factory = factory;
            this.dgv = dgv;
        }

        private void updateStaffTableForm_Load(object sender, EventArgs e)
        {
            tb_surname.Text = updateRow.Cells["surname"].Value.ToString().Trim().Replace(" ", string.Empty);
            tb_name.Text = updateRow.Cells["name"].Value.ToString().Trim().Replace(" ", string.Empty);
            tb_function.Text = updateRow.Cells["function"].Value.ToString().Trim().Replace(" ", string.Empty);
            cbGender.Items.Add("male");
            cbGender.Items.Add("female");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                surname = tb_surname.Text;
                name = tb_name.Text;
                try
                {
                    if (cbGender.SelectedIndex != -1)
                    {
                        gender = Convert.ToString(cbGender.Text);
                    }
                }
                catch (Exception) { }
                birthdate = Convert.ToDateTime(birthDatePick.Text);
                function = tb_function.Text;
                try
                {
                    manager = Convert.ToInt32(tb_manager.Text);
                }
                catch (FormatException) { manager = 0; }
                salary = Convert.ToInt32(tb_salary.Text);
                Worker wk = new Worker();
                wk.workerSet(surname, name, gender, birthdate, function, manager, salary);
                var cell = dgv[0, dgv.CurrentRow.Index];
                int id = Convert.ToInt32(cell.Value);
                StaffValidator sc = new StaffValidator();
                //if (sc.checkUpdate(id, wk))
                //{
                    StaffController staffController = new StaffController(dgv, factory);
                staffController.updateTable(id, wk);
                //}
            }
            catch (Exception ex) { MessageBox.Show("Данные введены некорректно!"); }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
