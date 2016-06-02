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
    public class DealController
    {
        private DataGridView dgv;
        private List<Deal> dgvElements;
        private IRepositoryFactory factory;
        private DealValidator dealValidator;
        private List<string> errorList;
        private string error;


        public DealController(DataGridView dgv, IRepositoryFactory factory)
        {
            dgvElements = new List<Deal>();
            this.factory = factory;
            this.dgv = dgv;
            dealValidator = new DealValidator();
        }

        public int ShowDeals(int id)
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

        public void ShowTable()
        {
            try
            {
                dgvElements = factory.GetDealRepository().ShowDealTable();
                dgv.Rows.Clear();
                foreach (Deal deal in dgvElements)
                {
                    dgv.Rows.Add(deal.GetDeal_id(), factory.GetStationRepository().GetStationsAdresByID(factory.GetStaffRepository().FindStationIDByStaffID(deal.GetStaff_id())).Trim().Replace(" ", string.Empty),
                        factory.GetStaffRepository().FindStaffByID(deal.GetStaff_id()), deal.GetFuelType(), deal.GetFuelAmount(),
                        deal.GetDealPrice(), deal.GetCardNum(), deal.GetDealDate());
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void ShowWorkerTable(int ID)
        {
            try
            {
                dgvElements = factory.GetDealRepository().ShowWorkerDealTable(ID);
                dgv.Rows.Clear();
                foreach (Deal deal in dgvElements)
                {
                    dgv.Rows.Add(deal.GetFuelType(), deal.GetFuelAmount(), deal.GetDealPrice(), deal.GetCardNum(), deal.GetDealDate());
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void ShowUserTable(string cardnum)
        {
            try
            {
                dgvElements = factory.GetDealRepository().ShowUserDealTable(cardnum);
                dgv.Rows.Clear();
                foreach (Deal deal in dgvElements)
                {
                    dgv.Rows.Add(deal.GetFuelType(), deal.GetFuelAmount(), deal.GetDealPrice(), deal.GetDealDate());
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public bool UpdateTable(int id, Deal deal)
        {
            bool checkFlag = false;
            try
            {
                if (checkFlag = dealValidator.checkUpdate(id, deal, out errorList))
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
            }
            catch (Exception) { MessageBox.Show("Невозможно выполнить операцию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return checkFlag;
        }

        public bool AddToTable(Deal deal)
        {
            bool checkFlag = false;
            try
            {      
                if (checkFlag = dealValidator.checkAddition(deal, out errorList))
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
            }
            catch (Exception) { MessageBox.Show("Невозможно выполнить операцию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return checkFlag;
        }
    }
}
