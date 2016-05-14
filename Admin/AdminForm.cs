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

namespace Admin
{
    public partial class AdminForm : Form
    {
        private Form additionalForm;
        dgvStaffController fillStaffTable;
        dgvCarController fillCarTable;
        dgvAccountController fillAccountingTable;
        dgvDealController fillDealTable;
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
            fillStaffTable = new dgvStaffController(dgvVievStaff, dbc);
            fillStaffTable.showTable();
            fillCarTable = new dgvCarController(dgvVievCars, dbc);
            fillCarTable.showTable();
            fillAccountingTable = new dgvAccountController(dgvViewAccounting, dbc);
            fillAccountingTable.showTable();
            fillDealTable = new dgvDealController(dgvVievDeal, dbc);
            fillDealTable.showTable();
        }

        private void btnTableView_Click(object sender, EventArgs e)
        {
            fillStaffTable = new dgvStaffController(dgvVievStaff, dbc);
            fillStaffTable.showTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateStaffTableForm updateForm = new updateStaffTableForm(dgvVievStaff.CurrentRow, dbc, dgvVievStaff);
            updateForm.ShowDialog();
            Hide();
            Show();
            fillStaffTable = new dgvStaffController(dgvVievStaff, dbc);
            fillStaffTable.showTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addToStaffTableForm addForm = new addToStaffTableForm(additionalForm, dbc, dgvVievStaff);
            addForm.ShowDialog();
            Hide();
            Show();
            fillStaffTable = new dgvStaffController(dgvVievStaff, dbc);
            fillStaffTable.showTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            fillStaffTable = new dgvStaffController(dgvVievStaff, dbc);
            fillStaffTable.deleteFromTable(dgvVievStaff.CurrentRow.Index);
            fillStaffTable = new dgvStaffController(dgvVievStaff, dbc);
            fillStaffTable.showTable();
        }

        private void btnFindDeals_Click(object sender, EventArgs e)
        {
            DealList dealList = new DealList(dgvVievCars.CurrentRow.Index, dbc);
            dealList.ShowDialog();


            //Hide();
            //Show();
        }

        private void btnCarAdd_Click(object sender, EventArgs e)
        {
            addToCarTableForm addForm = new addToCarTableForm(additionalForm, dbc, dgvVievCars);
            addForm.ShowDialog();
            fillCarTable = new dgvCarController(dgvVievCars, dbc);
            fillCarTable.showTable();


            //Hide();
        }

        private void btnDealUpdate_Click(object sender, EventArgs e)
        {
            updateDealTableForm updateDealForm = new updateDealTableForm(dgvVievDeal.CurrentRow, dbc, dgvVievDeal);
            updateDealForm.ShowDialog();
            Hide();
            Show();
            fillDealTable = new dgvDealController(dgvVievDeal, dbc);
            fillDealTable.showTable();
        }
    }
}
