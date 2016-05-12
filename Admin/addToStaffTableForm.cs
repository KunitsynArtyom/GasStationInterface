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
using Queries.dgvMediators;
using Queries.combBoxFillers;
using Queries.TableRepositories;

namespace Admin
{
    public partial class addToStaffTableForm : Form
    {
        public Form af;
        NpgsqlConnection conn;
        StationRepository stationQuery;
        StaffRepository staffQuery;
        DataGridView dgv;
        int station_id, staff_id, manager, salary;
        string surname, name, gender, function;
        DateTime birthdate;

  

        private void addToStaffTableForm_Load(object sender, EventArgs e)
        {
            cb_gender.Items.Add("male");
            cb_gender.Items.Add("female");
            try
            {
                comboBoxStaffFiller cbsf;
                cbStationList.Visible = false;
                label2.Visible = false;
                cbsf = new comboBoxStaffFiller(cbOrgList, conn);
                cbsf.cb_orgFill();
            }
            catch (Exception ex) { }
        }

        private void cbOrgList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (cbOrgList.SelectedIndex != -1)
                {
                    comboBoxStaffFiller cbsf;
                    cbStationList.Visible = true;
                    label2.Visible = true;
                    cbsf = new comboBoxStaffFiller(cbStationList, conn);
                    cbsf.cb_stationFill(cbOrgList.Text);
                }
            }
            catch (Exception ex) { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //staff_id = Convert.ToInt32(tb_staff_id.Text);
            try
            {
                station_id = Convert.ToInt32(stationQuery.FindStationIDByLocation(cbStationList.Text));
                surname = tb_surname.Text;
                name = tb_name.Text;
                try
                {
                    if (cb_gender.SelectedIndex != -1)
                    {
                        gender = Convert.ToString(cb_gender.Text);
                    }
                }catch (Exception) { MessageBox.Show("Данные введены некорректно!"); }
                birthdate = Convert.ToDateTime(birthDatePick.Text);
                function = tb_function.Text;
                try
                {
                    manager = Convert.ToInt32(tb_manager.Text);
                }
                catch (FormatException) { manager = 0; }
                salary = Convert.ToInt32(tb_salary.Text);
                Worker wk = new Worker();
                //wk.workerSet(staff_id, station_id, surname, name, gender, birthdate, function, manager, salary);
                wk.workerSet(station_id, surname, name, gender, birthdate, function, manager, salary);
                dgvStaffFiller dgvs = new dgvStaffFiller(dgv, conn);
                dgvs.addToTable(wk);
            }
            catch (Exception) { MessageBox.Show("Данные введены некорректно!"); }
            Close();
        }
      
        public addToStaffTableForm(Form adminForm, NpgsqlConnection conn, DataGridView dgv)
        {
            InitializeComponent();
            af = adminForm;
            this.conn = conn;
            this.dgv = dgv;
            stationQuery = new StationRepository(conn);
            staffQuery = new StaffRepository(conn);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
            af.Show();
        }
    }
}
