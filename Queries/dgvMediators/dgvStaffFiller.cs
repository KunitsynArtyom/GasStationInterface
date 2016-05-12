using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Npgsql;
using Queries.Entities;
using Queries.TableRepositories;

namespace Queries.dgvMediators
{
    public class dgvStaffFiller
    {
        DataGridView dgv;
        StaffRepository staffQuery;
        List<Worker> dgvElements;

        public dgvStaffFiller(DataGridView dgv, NpgsqlConnection conn)
        {
            dgvElements = new List<Worker>();
            staffQuery = new StaffRepository(conn);
            this.dgv = dgv;
        }

        public void showTable()
        {
            dgvElements = staffQuery.GetStaff();
            dgv.Rows.Clear();
            foreach (Worker wk in dgvElements)
            {
                dgv.Rows.Add(wk.GetSurname(), wk.GetName(), wk.GetGender(), wk.GetFunction(), wk.GetSalary());
            }
        }

        public void addToTable(Worker wk)
        {
            staffQuery.AddToStaffTable(wk);
        }

        public void updateTable(int number, Worker wk)
        {
            var workerList = staffQuery.GetStaff();
            Worker wkToUpdate = workerList[number];
            staffQuery.UpdateStaffTabele(wkToUpdate, wk);
        }

        public void deleteFromTable(int number)
        {
            var workerList = staffQuery.GetStaff();
            Worker wkToDelete = workerList[number];
            staffQuery.DeleteFromStaffTabele(wkToDelete);
        }
    }
}
