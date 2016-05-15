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

namespace Worker
{
    public partial class WorkerForm : Form
    {
        public Form additionalForm;
        dgvDealController fillDealTable;
        DBConnection dbc;
        NpgsqlConnection conn;
        dgvSupplyController fillSupplyTable;

        public WorkerForm(NpgsqlConnection conn)
        {
            InitializeComponent();
            DBConnection dbc = new DBConnection(conn);
            dbc.openConnection();
            fillDealTable = new dgvDealController(dgvVievDeal, dbc);
            fillSupplyTable = new dgvSupplyController(dgvViewSupply, dbc);
            additionalForm = this;
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            fillDealTable.showTable();
            fillSupplyTable.showTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addToDealTableForm addForm = new addToDealTableForm(additionalForm, dbc, dgvVievDeal);
            addForm.ShowDialog();
            Hide();
            Show();
            fillDealTable = new dgvDealController(dgvVievDeal, dbc);
            fillDealTable.showTable();
        }
    }
}
