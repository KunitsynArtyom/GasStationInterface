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

namespace Admin
{
    public partial class addToStaffTableForm : Form
    {
        public Form af;
        AdminQuery adminQuery;
        DataGridView dgv;
        int station_id, staff_id, manager, salary;
        string surname, name, gender, function;
        DateTime birthdate;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //staff_id = Convert.ToInt32(tb_staff_id.Text);
            try
            {
                station_id = Convert.ToInt32(tb_station_id.Text);
                surname = tb_surname.Text;
                name = tb_name.Text;
                gender = tb_gender.Text;
                birthdate = Convert.ToDateTime(tb_birthdate.Text);
                function = tb_function.Text;
                try
                {
                    manager = Convert.ToInt32(tb_manager.Text);
                }
                catch (FormatException) { manager = 0; }
                //else manager = 0;
                salary = Convert.ToInt32(tb_salary.Text);
                Worker wk = new Worker();
                wk.workerSet(staff_id, station_id, surname, name, gender, birthdate, function, manager, salary);
                dgvStaffFiller dgvs = new dgvStaffFiller(dgv, adminQuery);
                dgvs.addToTable(wk);
            }
            catch (FormatException) {  }
            Close();
        }

        //private NpgsqlConnection conn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = qwerty1; Database = AZS");

        public addToStaffTableForm(Form adminForm, AdminQuery adminQuery, DataGridView dgv)
        {
            InitializeComponent();
            af = adminForm;
            this.adminQuery = adminQuery;
            this.dgv = dgv;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
            //AdminForm adminForm = new AdminForm(conn);
            af.Show();
        }
    }
}
