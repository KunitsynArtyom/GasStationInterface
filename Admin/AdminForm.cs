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
using Queries.dgvControllers;
using Queries.TableRepositories;
using Queries.Controllers;

namespace Admin
{
    public partial class AdminForm : Form
    {
        private Form additionalForm;
        dgvStaffController fillStaffTable;
        dgvCarController fillCarTable;
        dgvAccountController fillAccountingTable;
        dgvDealController fillDealTable;
        dgvStationController fillStationTable;
        StaffRepository staffQuery;
        public NpgsqlConnection conn;
        DBConnection dbc;

        public AdminForm(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            additionalForm = this;
            dbc = new DBConnection(conn);
            dbc.openConnection();
            staffQuery = new StaffRepository(dbc);                      
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            fillStationTable = new dgvStationController(dgvVievAZS, dbc);
            fillStationTable.showAdminTable();
            fillStaffTable = new dgvStaffController(dgvViewStaff, dbc);
            fillStaffTable.showTable();
            fillCarTable = new dgvCarController(dgvViewCars, dbc);
            fillCarTable.showTable();
            fillAccountingTable = new dgvAccountController(dgvViewAccounting, dbc);
            fillAccountingTable.showTable();
            fillDealTable = new dgvDealController(dgvViewDeal, dbc);
            fillDealTable.showTable();
        }

        private void btnTableView_Click(object sender, EventArgs e)
        {
            fillStaffTable = new dgvStaffController(dgvViewStaff, dbc);
            fillStaffTable.showTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateStaffTableForm updateForm = new updateStaffTableForm(dgvViewStaff.CurrentRow, dbc, dgvViewStaff);
            updateForm.ShowDialog();
            Hide();
            Show();
            fillStaffTable = new dgvStaffController(dgvViewStaff, dbc);
            fillStaffTable.showTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addToStaffTableForm addForm = new addToStaffTableForm(additionalForm, dbc, dgvViewStaff);
            addForm.ShowDialog();
            Hide();
            Show();
            fillStaffTable = new dgvStaffController(dgvViewStaff, dbc);
            fillStaffTable.showTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //fillStaffTable = new dgvStaffController(dgvViewStaff, dbc);
            //fillStaffTable.deleteFromTable(dgvViewStaff.CurrentRow.Index);
            StaffController sc = new StaffController(dgvViewStaff, dbc);
            sc.checkDelete(dgvViewStaff.CurrentRow.Index);
            fillStaffTable = new dgvStaffController(dgvViewStaff, dbc);
            fillStaffTable.showTable();
        }

        private void btnFindDeals_Click(object sender, EventArgs e)
        {
            DealList dealList = new DealList(dgvViewCars.CurrentRow.Index, dbc);
            dealList.ShowDialog();


            //Hide();
            //Show();
        }

        private void btnCarAdd_Click(object sender, EventArgs e)
        {
            addToCarTableForm addForm = new addToCarTableForm(additionalForm, dbc, dgvViewCars);
            addForm.ShowDialog();
            fillCarTable = new dgvCarController(dgvViewCars, dbc);
            fillCarTable.showTable();


            //Hide();
        }

        private void btnDealUpdate_Click(object sender, EventArgs e)
        {
            updateDealTableForm updateDealForm = new updateDealTableForm(dgvViewDeal.CurrentRow, dbc, dgvViewDeal);
            updateDealForm.ShowDialog();
            Hide();
            Show();
            fillDealTable = new dgvDealController(dgvViewDeal, dbc);
            fillDealTable.showTable();
        }

        private void btnStationAdd_Click(object sender, EventArgs e)
        {
            addToStationTableForm addForm = new addToStationTableForm(additionalForm, dbc, dgvViewCars);
            addForm.ShowDialog();
            Hide();
            Show();
            fillStationTable = new dgvStationController(dgvVievAZS, dbc);
            fillStationTable.showAdminTable();
        }
    }
}
