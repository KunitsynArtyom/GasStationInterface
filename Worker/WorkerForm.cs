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
using Queries.dgvMediators;

namespace Worker
{
    public partial class WorkerForm : Form
    {
        public Form additionalForm;
        dgvDealFiller fillDealTable;
        WorkerQuery workerQuery;
        public NpgsqlConnection conn;

        public WorkerForm(NpgsqlConnection conn)
        {
            InitializeComponent();
            workerQuery = new WorkerQuery(conn);
            this.conn = conn;
            additionalForm = this;
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            fillDealTable = new dgvDealFiller(dgvVievDeal, workerQuery);
            fillDealTable.showTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addToDealTableForm addForm = new addToDealTableForm(additionalForm, workerQuery, dgvVievDeal);
            addForm.ShowDialog();
            Hide();
            Show();
            fillDealTable = new dgvDealFiller(dgvVievDeal, workerQuery);
            fillDealTable.showTable();
        }
    }
}
