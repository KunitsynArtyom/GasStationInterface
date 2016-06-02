using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Npgsql;
using Queries.Entities;
using Queries.Repositories;
using Queries.Interfaces;
using Queries.Validators;

namespace Queries.dgvControllers
{
    public class CarController
    {
        private DataGridView dgv;
        private List<Car> dgvElements;
        private IRepositoryFactory factory;
        private CarValidator carValidator;
        private List<string> errorList;
        private string error;

        public CarController(DataGridView dgv, IRepositoryFactory factory)
        {
            this.factory = factory;
            this.dgv = dgv;
            carValidator = new CarValidator();
        }

        public void ShowTable()
        {
            try
            {
                dgvElements = factory.GetCarRepository().GetCars();
                dgv.Rows.Clear();
                foreach (Car car in dgvElements)
                {
                    dgv.Rows.Add(car.GetCar_id(), car.GetCarMark(), car.GetCardNum());
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public bool AddToTable(Car car)
        {
            bool checkFlag = false;
            try
            {
                if (checkFlag = carValidator.checkAddition(car, out errorList))
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
            catch (Exception) { MessageBox.Show("Невозможно выполнить операцию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return checkFlag;
        }
    }
}
