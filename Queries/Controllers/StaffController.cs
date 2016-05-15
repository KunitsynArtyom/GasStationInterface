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

namespace Queries.Controllers
{
    public class StaffController
    {
        DBConnection dbc;
        StaffRepository staffQuery;
        DataGridView dgv;
        dgvStaffController dgsc;

        public StaffController(DataGridView dgv,DBConnection dbc)
        {
            staffQuery = new StaffRepository(dbc);
            this.dgv = dgv;
            dgsc = new dgvStaffController(dgv, dbc);
        }

        public void checkAddition(Worker wk)
        {
            bool checkFlag = true;
            if (wk.GetStation_id() <= 0)
            { checkFlag = false; }
            if (wk.GetSurname() == String.Empty)
            { checkFlag = false; }
            if (wk.GetName() == String.Empty)
            { checkFlag = false; }
            if (wk.GetGender() == String.Empty)
            { checkFlag = false; }
            if (wk.GetFunction() == String.Empty)
            { checkFlag = false; }
            //if (wk.GetManager() < 0)
            //{ checkFlag = false; MessageBox.Show(wk.GetManager().ToString()); }
            if (wk.GetSalary() < 500)
            { checkFlag = false; }
            if (checkFlag == true)
            {
                dgsc.addToTable(wk);
            }
            else
                MessageBox.Show("Данные были введены неправильно!");
        }

        public void checkUpdate(int number, Worker wk)
        {
            bool checkFlag = true;
            if (wk.GetSurname() == String.Empty)
            { checkFlag = false; }
            if (wk.GetName() == String.Empty)
            { checkFlag = false; }
            if (wk.GetGender() == String.Empty)
            { checkFlag = false; }
            if (wk.GetFunction() == String.Empty)
            { checkFlag = false; }
            if (wk.GetSalary() < 500)
            { checkFlag = false; }
            if (number == -1)
            { checkFlag = false; }
            if (number == -1)
            { }
            if (checkFlag == true)
            {
                dgsc.updateTable(number, wk);
            }
            else
                MessageBox.Show("Данные были введены неправильно!");
        }

        public void checkDelete(int number)
        {
            bool checkFlag = true;
            if (number == -1)
            { checkFlag = false; }
            if (checkFlag == true)
            {
                dgsc.deleteFromTable(number);
            }
            else
                MessageBox.Show("Данные были введены неправильно!");
        }
    }
}
