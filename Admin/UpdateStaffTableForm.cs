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
using Queries.Controllers;
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
            tb_surname.Text = updateRow.Cells["surname"].Value.ToString();
            tb_name.Text = updateRow.Cells["name"].Value.ToString();
            tb_function.Text = updateRow.Cells["function"].Value.ToString();
            cb_gender.Items.Add("male");
            cb_gender.Items.Add("female");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                surname = tb_surname.Text;
                name = tb_name.Text;
                try
                {
                    if (cb_gender.SelectedIndex != -1)
                    {
                        gender = Convert.ToString(cb_gender.Text);
                    }
                }
                catch (Exception) { MessageBox.Show("Данные введены некорректно!"); }
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
                StaffController sc = new StaffController();
                if (sc.checkUpdate(id, wk))
                {
                    dgvStaffController dgvs = new dgvStaffController(dgv, factory);
                    dgvs.updateTable(id, wk);
                }
                //dgvStaffController dgvs = new dgvStaffController(dgv, dbc);
                //dgvs.updateTable(updateRow.Index, wk);
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
