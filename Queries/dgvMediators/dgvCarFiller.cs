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
    public class dgvCarFiller
    {
        DataGridView dgv;
        NpgsqlConnection conn;
        CarRepository carQuery;
        List<Car> dgvElements;

        public dgvCarFiller(DataGridView dgv, NpgsqlConnection conn)
        {
            dgvElements = new List<Car>();
            this.conn = conn;
            this.dgv = dgv;
            carQuery = new CarRepository(conn);
        }

        public void showTable()
        {
            dgvElements = carQuery.GetCars();
            dgv.Rows.Clear();
            foreach (Car car in dgvElements)
            {
                dgv.Rows.Add(car.GetCarMark(), car.GetCardNum());
            }
        }

        public void addToTable(Car car)
        {
            carQuery.AddToCarTable(car);
        }
    }
}
