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
using Queries.dgvControllers;
using Queries.Interfaces;
using Queries.Validators;

namespace Queries.dgvControllers
{
    public class StaffController
    {
        DataGridView dgv;
        List<Worker> dgvElements;
        IRepositoryFactory factory;
        StaffValidator staffValidator;
        List<string> errorList;
        string error;

        public StaffController(DataGridView dgv, IRepositoryFactory factory)
        {
            dgvElements = new List<Worker>();
            this.dgv = dgv;
            this.factory = factory;
            staffValidator = new StaffValidator();
        }

        public void showTable()
        {
            dgvElements = factory.GetStaffRepository().GetStaff();
            dgv.Rows.Clear();
            foreach (Worker wk in dgvElements)
            {
                dgv.Rows.Add(wk.GetStaff_id(), wk.GetSurname(), wk.GetName(), wk.GetGender(), wk.GetFunction(), wk.GetSalary());
            }
        }

        public void addToTable(Worker wk)
        {
            try
            {
                if (staffValidator.checkAddition(wk, out errorList))
                {
                    factory.GetStaffRepository().AddToStaffTable(wk);
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
            catch (Exception) { MessageBox.Show("Операция не может быть выполнена!"); }
        }

        public void updateTable(int id, Worker wk)
        {
            try
            {
                if (staffValidator.checkUpdate(id, wk, out errorList))
                {
                    factory.GetStaffRepository().UpdateStaffTable(id, wk);
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
            catch (Exception) { MessageBox.Show("Операция не может быть выполнена!"); }
        }

        public void deleteFromTable(int id)
        {
            try
            {
                if (staffValidator.checkDelete(id, out errorList))
                {
                    factory.GetStaffRepository().DeleteFromStaffTable(id);
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
            } catch (Exception) { MessageBox.Show("Операция не может быть выполнена!"); }
        }
    }
}
