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
using Queries.Interfaces;

namespace Queries.dgvControllers
{
    public class dgvCarController
    {
        DataGridView dgv;
        List<Car> dgvElements;
        IRepositoryFactory factory;

        public dgvCarController(DataGridView dgv, IRepositoryFactory factory)
        {
            this.factory = factory;
            this.dgv = dgv;
        }

        public void showTable()
        {
            dgvElements = factory.GetCarRepository().GetCars();
            dgv.Rows.Clear();
            foreach (Car car in dgvElements)
            {
                dgv.Rows.Add(car.GetCar_id(), car.GetCarMark(), car.GetCardNum());
            }
        }

        public void addToTable(Car car)
        {
            factory.GetCarRepository().AddToCarTable(car);
        }
    }
}
