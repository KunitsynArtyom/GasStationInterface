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

namespace Queries.dgvControllers
{
    public class dgvCarController
    {
        DataGridView dgv;
        NpgsqlConnection conn;
        CarRepository carQuery;
        List<Car> dgvElements;
        DBConnection dbc;

        public dgvCarController(DataGridView dgv, DBConnection dbc)
        {
            this.dbc = dbc;
            carQuery = new CarRepository(dbc);
            this.dgv = dgv;
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
