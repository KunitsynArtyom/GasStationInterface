using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Queries.Entities;

namespace Queries.dgvMediators
{
    public class dgvCarFiller
    {
        DataGridView dgv;
        AdminQuery adminQuery;
        List<Car> dgvElements;

        public dgvCarFiller(DataGridView dgv, AdminQuery adminQuery)
        {
            dgvElements = new List<Car>();
            this.adminQuery = adminQuery;
            this.dgv = dgv;
        }

        public void showTable()
        {
            dgvElements = adminQuery.GetCars();
            dgv.Rows.Clear();
            foreach (Car car in dgvElements)
            {
                dgv.Rows.Add(car.GetCarMark(), car.GetCardNum());
            }
        }

        public void addToTable(Car car)
        {
            adminQuery.AddToCarTable(car);
        }
    }
}
