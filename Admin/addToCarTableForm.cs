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

namespace Admin
{
    public partial class addToCarTableForm : Form
    {
        public Form af;
        DataGridView dgv;
        NpgsqlConnection conn;


        private void addToStaffTableForm_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    comboBoxCardNumFiller comboBoxFiller = new comboBoxCardNumFiller(cbCardNum, adminQuery);
            //    comboBoxFiller.cb_CardNumFill();
            //}
            //catch (Exception ex) { }
        }

        public addToCarTableForm(Form adminForm, NpgsqlConnection conn, DataGridView dgv)
        {
            InitializeComponent();
            af = adminForm;
            this.conn = conn;
            this.dgv = dgv;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {        
            try
            {
                string carMark, cardNum;
                carMark = tbCarMark.Text.ToString();
                //if (tbCardNum.Text != "" && cbCardNum.SelectedIndex == -1)
                //{
                    cardNum = tbCardNum.Text.ToString();
                //}
                //else
                //    cardNum = cbCardNum.Text.ToString();
                Car car = new Car();
                car.buyerSet(carMark, cardNum);
                dgvCarFiller dgvc = new dgvCarFiller(dgv, conn);
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
