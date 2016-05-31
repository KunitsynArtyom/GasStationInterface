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
using Queries.Validators;

namespace Queries.dgvControllers
{
    public class CarController
    {
        DataGridView dgv;
        List<Car> dgvElements;
        IRepositoryFactory factory;
        CarValidator carValidator;
        List<string> errorList;
        string error;

        public CarController(DataGridView dgv, IRepositoryFactory factory)
        {
            this.factory = factory;
            this.dgv = dgv;
            carValidator = new CarValidator();
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
            try
            {
                if (carValidator.checkAddition(car, out errorList))
                {
                    factory.GetCarRepository().AddToCarTable(car);
                }
                else
                {
                    int k = 0;
                    foreach (string str in errorList)
                    {
                        k++;
                        error += "Ошибка №" + k + ": " + str + " \n";
                    }
                    MessageBox.Show(error);
                }
            }
            catch (NpgsqlException ne) { MessageBox.Show("Невозможно выполнить операцию!"); }
        }
    }
}
