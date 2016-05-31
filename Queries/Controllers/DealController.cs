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
    public class DealController
    {
        DataGridView dgv;
        List<Deal> dgvElements;
        IRepositoryFactory factory;
        DealValidator dealValidator;
        List<string> errorList;
        string error;


        public DealController(DataGridView dgv, IRepositoryFactory factory)
        {
            dgvElements = new List<Deal>();
            this.factory = factory;
            this.dgv = dgv;
            dealValidator = new DealValidator();
        }

        public int showDeals(int id)
        {
            var foundDealList = new List<Deal>();
            var dealList = factory.GetDealRepository().ShowBuyerDealTable(id);
            if (dealList.Count != 0)
            {
                foreach (Deal deal in dealList)
                {
                    dgv.Rows.Add(deal.GetFuelType(), deal.GetFuelAmount(), deal.GetDealPrice(), deal.GetDealDate());
                }
            }
            else MessageBox.Show("Сделок с данным пользователем не найдено!");

            return dealList.Count;
        }

        public void showTable()
        {
            dgvElements = factory.GetDealRepository().ShowDealTable();
            dgv.Rows.Clear();
            foreach (Deal deal in dgvElements)
            {
                dgv.Rows.Add(deal.GetDeal_id(), factory.GetStaffRepository().FindStaffByID(deal.GetStaff_id()), deal.GetFuelType(), deal.GetFuelAmount(), deal.GetDealPrice(), deal.GetCardNum(), deal.GetDealDate());
            }
        }

        public void showWorkerTable(int ID)
        {
            dgvElements = factory.GetDealRepository().ShowWorkerDealTable(ID);
            dgv.Rows.Clear();
            foreach (Deal deal in dgvElements)
            {
                dgv.Rows.Add(deal.GetFuelType(), deal.GetFuelAmount(), deal.GetDealPrice(), deal.GetCardNum(), deal.GetDealDate());
            }
        }

        public void showUserTable(string cardnum)
        {
            dgvElements = factory.GetDealRepository().ShowUserDealTable(cardnum);
            dgv.Rows.Clear();
            foreach (Deal deal in dgvElements)
            {
                dgv.Rows.Add(deal.GetFuelType(), deal.GetFuelAmount(), deal.GetDealPrice(), deal.GetDealDate());
            }
        }

        public void updateTable(int id, Deal deal)
        {
            try
            {
                if (dealValidator.checkUpdate(id, deal, out errorList))
                {
                    factory.GetDealRepository().UpdateDealTable(id, deal);
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
            } catch (NpgsqlException ne) { MessageBox.Show("Невозможно выполнить операцию!"); }
        }

        public void addToTable(Deal deal)
        {
            try
            {      
                if (dealValidator.checkAddition(deal, out errorList))
                {
                    factory.GetDealRepository().AddToDealTable(deal);
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
            } catch(NpgsqlException ne) { MessageBox.Show("Невозможно выполнить операцию!"); }
        }
    }
}
