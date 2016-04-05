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

namespace Admin
{
    public partial class AdminForm : Form
    {
        private Form additionalForm;
        public AdminQuery adminQuery;
        public NpgsqlConnection conn;
        public AdminForm(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            adminQuery = new AdminQuery(conn, dgvVievStaff);
            additionalForm = this;
        }

        private void AdminForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //EnterForm frm1 = new EnterForm();
            //frm1.Show();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            adminQuery.showStaffTabele();
            //btnUpdate.Enabled = false;
        }

        private void btnTableView_Click(object sender, EventArgs e)
        {
            adminQuery.showStaffTabele();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateStaffTableForm updateForm = new updateStaffTableForm(dgvVievStaff.CurrentRow, adminQuery);
            updateForm.ShowDialog();
            Hide();
            Show();
            //dgvVievStaff.currentrow.index;
            //this.dgvVievStaff.EditMode = DataGridViewEditMode.EditOnEnter;
            //DataGridViewRow updateRow = dgvVievStaff.Rows[0];
            //btnUpdate.Enabled = true;
            //adminQuery.updateStaffTabele(dgvVievStaff.CurrentRow);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addToStaffTableForm addForm = new addToStaffTableForm(additionalForm, adminQuery);
            addForm.ShowDialog();
            Hide();
            Show();
        }
    }
}
