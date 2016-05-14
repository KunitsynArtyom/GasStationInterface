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

namespace Admin
{
    public partial class addToCarTableForm : Form
    {
        public Form af;
        DataGridView dgv;
        DBConnection dbc;


        private void addToStaffTableForm_Load(object sender, EventArgs e)
        {

        }

        public addToCarTableForm(Form adminForm, DBConnection dbc, DataGridView dgv)
        {
            InitializeComponent();
            af = adminForm;
            this.dbc = dbc;
            this.dgv = dgv;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {        
            try
            {
                string carMark, cardNum;
                carMark = tbCarMark.Text.ToString();
                cardNum = tbCardNum.Text.ToString();
                Car car = new Car();
                car.buyerSet(carMark, cardNum);
                dgvCarController dgvc = new dgvCarController(dgv, dbc);
                dgvc.addToTable(car);
            }
            catch (FormatException) { MessageBox.Show("Данные введены некорректно!"); }
            Close();
            af.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
            af.Show();
        }
    }
}
