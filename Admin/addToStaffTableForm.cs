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
using Queries.Validators;
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
            cbGender.Items.Add("male");
            cbGender.Items.Add("female");
            try
            {
                cbStationList.Visible = false;
                label2.Visible = false;
                ComboBoxStaffFiller cbsf = new ComboBoxStaffFiller(cbOrgList, factory);
                cbsf.cbOrgFill();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка базы данных!"); }
        }

        private void cbOrgList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (cbOrgList.SelectedIndex != -1)
                {
                    cbStationList.Items.Clear();
                    //comboBoxStaffFiller cbsf;
                    cbStationList.Visible = true;
                    label2.Visible = true;
                    ComboBoxStaffFiller comboBoxStaffFiller = new ComboBoxStaffFiller(cbStationList, factory);
                    comboBoxStaffFiller.cbStationFill(cbOrgList.Text);
                }
            }
            catch (Exception ex) { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                station_id = factory.GetStationRepository().FindStationIDByLocation(cbStationList.Text);
                surname = tbSurname.Text;
                name = tbName.Text;
                if (cbGender.SelectedIndex != -1)
                {
                   gender = Convert.ToString(cbGender.Text);
                }
                birthdate = Convert.ToDateTime(birthDatePick.Text);
                function = tbFunction.Text;
                try
                {
                    manager = Convert.ToInt32(tbManager.Text);
                }
                catch (FormatException) { manager = 0; }
                salary = Convert.ToInt32(tbSalary.Text);
                Worker wk = new Worker();
                wk.workerSet(station_id, surname, name, gender, birthdate, function, manager, salary);
                //StaffValidator sc = new StaffValidator();
                //if (sc.checkAddition(wk))
                //{
                StaffController staffController = new StaffController(dgv, factory);
                staffController.addToTable(wk);
                //}
            }
            catch (Exception) { MessageBox.Show("Данные введены некорректно!"); }
            //Close();
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
            //Hide();
            Close();
            af.Show();
        }
    }
}
