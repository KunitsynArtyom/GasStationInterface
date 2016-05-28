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
using Queries.TableRepositories;
using Queries.Controllers;
using Queries.Interfaces;

namespace Admin
{
    public partial class AddToStaffTableForm : Form
    {
        public Form af;
        IRepositoryFactory factory;
        DataGridView dgv;
        int station_id, manager, salary;
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
                cbsf = new comboBoxStaffFiller(cbOrgList, factory);
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
                    cbStationList.Items.Clear();
                    comboBoxStaffFiller cbsf;
                    cbStationList.Visible = true;
                    label2.Visible = true;
                    cbsf = new comboBoxStaffFiller(cbStationList, factory);
                    cbsf.cb_stationFill(cbOrgList.Text);
                }
            }
            catch (Exception ex) { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> ErrorList = new List<string>();
            try
            {
                if (cbStationList.Text == String.Empty)
                {
                    ErrorList.Add("Станция не выбрана!");
                }
                if (tb_surname.Text == String.Empty)
                {
                    ErrorList.Add("Фамилия не задана!");
                }
                if (tb_name.Text == String.Empty)
                {
                    ErrorList.Add("Имя не задано!");
                }
                if (cb_gender.Text == String.Empty)
                {
                    ErrorList.Add("Пол не задан!");
                }
                if (birthDatePick.Text == String.Empty)
                {
                    ErrorList.Add("Дата рождения не выбрана!");
                }
                if (tb_function.Text == String.Empty)
                {
                    ErrorList.Add("Назначение не выбрано!");
                }
                if (birthDatePick.Text == String.Empty)
                {
                    ErrorList.Add("Дата рождения не задана!");
                }
                if (tb_salary.Text == String.Empty)
                {
                    ErrorList.Add("Зарплата не установлена!");
                }
                if (ErrorList.Count != 0)
                {
                    foreach (string str in ErrorList)
                    {
                        MessageBox.Show(str);
                    }
                }

                station_id = factory.GetStationRepository().FindStationIDByLocation(cbStationList.Text);
                surname = tb_surname.Text;
                name = tb_name.Text;
                if (cb_gender.SelectedIndex != -1)
                {
                   gender = Convert.ToString(cb_gender.Text);
                }
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
                StaffController sc = new StaffController();
                if (sc.checkAddition(wk))
                {
                    dgvStaffController dgvs = new dgvStaffController(dgv, factory);
                    dgvs.addToTable(wk);
                }
            }
            catch (Exception) { MessageBox.Show("Данные введены некорректно!"); }
            Close();
        }
      
        public AddToStaffTableForm(Form adminForm, IRepositoryFactory factory, DataGridView dgv)
        {
            InitializeComponent();
            af = adminForm;
            this.factory = factory;
            this.dgv = dgv;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
            af.Show();
        }
    }
}
