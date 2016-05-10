using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;
using System.Collections;
using Queries.Entities;

namespace Queries
{
    public class AdminQuery : IAdminQuery
    {
        public DBConnection dbc;
        public AdminQuery(NpgsqlConnection conn)
        {
            dbc = new DBConnection(conn);
        }

        public List<Worker> GetStaff()
        {
            //var dgvElements = new ArrayList();
            List<Worker> dgvElements = new List<Worker>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Staff\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        //dgv.Rows.Add(dbDataRecord["surname"].ToString(), dbDataRecord["name"].ToString(), dbDataRecord["gender"].ToString(), dbDataRecord["function"].ToString());
                        Worker wk = new Worker();
                        try
                        {
                            wk.workerSet(Convert.ToInt32(dbDataRecord["staff_id"]), Convert.ToInt32(dbDataRecord["station_id"]), dbDataRecord["surname"].ToString(),
                                dbDataRecord["name"].ToString(), dbDataRecord["gender"].ToString(), Convert.ToDateTime(dbDataRecord["birthdate"]),
                                dbDataRecord["function"].ToString(), Convert.ToInt32(dbDataRecord["manager"]), Convert.ToInt32(dbDataRecord["salary"]));
                        }
                        catch (InvalidCastException)
                        {
                            wk.workerSet(Convert.ToInt32(dbDataRecord["staff_id"]), Convert.ToInt32(dbDataRecord["station_id"]), dbDataRecord["surname"].ToString(),
                                dbDataRecord["name"].ToString(), dbDataRecord["gender"].ToString(), Convert.ToDateTime(dbDataRecord["birthdate"]),
                                dbDataRecord["function"].ToString(), 0, Convert.ToInt32(dbDataRecord["salary"]));
                        }
                        dgvElements.Add(wk);
                    }
                }
            }
            catch (NpgsqlException ne)
            {
                
            }
            finally { dbc.closeConnection(); }
            return dgvElements;
        }

        public void AddToStaffTable(Worker wk)
        {
            NpgsqlCommand queryCommand;
            try
            {
                dbc.openConnection();
                if (wk.GetManager() != 0)
                {
                    queryCommand = new NpgsqlCommand("INSERT INTO \"AZS\".\"Staff\"(Station_id, Surname, Name, Gender, Birthdate, Function, Manager, Salary)" + 
                        "VALUES(@Station_id, @Surname, @Name, @Gender, @Birthdate, @Function, @Manager, @Salary)", dbc.getConnection());
                    queryCommand.Parameters.AddWithValue("@Station_id", wk.GetStation_id());
                    queryCommand.Parameters.AddWithValue("@Surname", wk.GetSurname());
                    queryCommand.Parameters.AddWithValue("@Name", wk.GetName());
                    queryCommand.Parameters.AddWithValue("@Gender", wk.GetGender());
                    queryCommand.Parameters.AddWithValue("@Birthdate", wk.GetBirthdate());
                    queryCommand.Parameters.AddWithValue("@Function", wk.GetFunction());
                    queryCommand.Parameters.AddWithValue("@Manager", wk.GetManager());
                    queryCommand.Parameters.AddWithValue("@Salary", wk.GetSalary());
                }
                else
                {
                    queryCommand = new NpgsqlCommand("INSERT INTO \"AZS\".\"Staff\"(Station_id, Surname, Name, Gender, Birthdate, Function, Salary)" + 
                        "VALUES(@Station_id, @Surname, @Name, @Gender, @Birthdate, @Function, @Salary)", dbc.getConnection());
                    queryCommand.Parameters.AddWithValue("@Station_id", wk.GetStation_id());
                    queryCommand.Parameters.AddWithValue("@Surname", wk.GetSurname());
                    queryCommand.Parameters.AddWithValue("@Name", wk.GetName());
                    queryCommand.Parameters.AddWithValue("@Gender", wk.GetGender());
                    queryCommand.Parameters.AddWithValue("@Birthdate", wk.GetBirthdate());
                    queryCommand.Parameters.AddWithValue("@Function", wk.GetFunction());
                    queryCommand.Parameters.AddWithValue("@Salary", wk.GetSalary());
                }
                try
                {
                    queryCommand.ExecuteNonQuery();
                }
                catch (NpgsqlException ne)
                {

                }
                finally { dbc.closeConnection(); }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }
        }

        public void UpdateStaffTabele(Worker wkToUpdate, Worker wk)
        {
            try
            {
                dbc.openConnection();
                //NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"AZS\".\"Staff\" SET surname = '" + wk.GetSurname() + "', name = '" + wk.GetName() +
                //"', gender = '" + wk.GetGender() + "', function = '" + wk.GetFunction() + "'" +
                //" WHERE staff_id = " + Convert.ToInt32(wkToUpdate.GetStaff_id()) + " ", dbc.getConnection());
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"AZS\".\"Staff\" SET surname = @Surname, name = @Name, gender = @Gender, function = @Function, " +
                "salary = @Salary WHERE staff_id = @Staff_id ", dbc.getConnection());

                queryCommand.Parameters.AddWithValue("@Surname", wk.GetSurname());
                queryCommand.Parameters.AddWithValue("@Name", wk.GetName());
                queryCommand.Parameters.AddWithValue("@Gender", wk.GetGender());
                queryCommand.Parameters.AddWithValue("@Function", wk.GetFunction());
                queryCommand.Parameters.AddWithValue("@Salary", wk.GetSalary());
                queryCommand.Parameters.AddWithValue("@Staff_id", wkToUpdate.GetStaff_id());

                queryCommand.ExecuteNonQuery();
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }
        }

        public void DeleteFromStaffTabele(Worker wkToDelete)
        {
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"AZS\".\"Staff\"  WHERE staff_id = @Staff_id", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Staff_id", Convert.ToInt32(wkToDelete.GetStaff_id()));
                queryCommand.ExecuteNonQuery();

            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }
        }

        public List<string> GetOrganisations()
        {
            //var comboBoxElements = new ArrayList();
            List<string>  comboBoxElements = new List<string>();

            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT DISTINCT orgname FROM \"AZS\".\"GasStation\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        comboBoxElements.Add(dbDataRecord["orgname"].ToString());
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return comboBoxElements;
        }

        public List<string> GetStationsAdres(string Orgname)
        {
            List<string> comboBoxElements = new List<string>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT country, city, street FROM \"AZS\".\"GasStation\" WHERE orgname = '" + Orgname + "' ", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        comboBoxElements.Add(dbDataRecord["country"].ToString() + "," + dbDataRecord["city"].ToString() + "," + dbDataRecord["street"].ToString());
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return comboBoxElements;
        }

        public int FindStationIDByLocation(string location)
        {
            int station_id = 0;
            var splittedLocation = new ArrayList();
            string[] split = location.Split(new Char[] { ',' });
            foreach (string s in split)
            {
                splittedLocation.Add(s);
            }
            try
            {
                dbc.openConnection();
                NpgsqlCommand command = new NpgsqlCommand("SELECT station_id FROM \"AZS\".\"GasStation\" WHERE country LIKE" +
                       "'%" + splittedLocation[0] + "%' AND city LIKE" + "'%" + splittedLocation[1] + "%' AND street LIKE" +
                       "'%" + splittedLocation[2] + "%'", dbc.getConnection());
                NpgsqlDataReader Station_ID_TableSearcher = command.ExecuteReader();
                if (Station_ID_TableSearcher.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in Station_ID_TableSearcher)
                    {
                        station_id = Convert.ToInt32(dbDataRecord["station_id"]);
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return station_id;
        }

        public List<Car> GetCars()
        {
            List<Car> dgvElements = new List<Car>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Car\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Car buyerCar = new Car();
                        buyerCar.buyerSet(Convert.ToInt32(dbDataRecord["car_id"]), dbDataRecord["carmark"].ToString(), dbDataRecord["cardnum"].ToString());
                        dgvElements.Add(buyerCar);
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return dgvElements;
        }

        public List<Deal> ShowBuyerDealTable()
        {
            List<Deal> dgvElements = new List<Deal>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Deal\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Deal deal = new Deal();
                        deal.dealSet(Convert.ToInt32(dbDataRecord["deal_id"]), Convert.ToInt32(dbDataRecord["car_id"]),
                            Convert.ToInt32(dbDataRecord["staff_id"]),dbDataRecord["fueltype"].ToString(), 
                            Convert.ToInt32(dbDataRecord["fuelamount"]), Convert.ToInt32(dbDataRecord["dealprice"]),
                            dbDataRecord["cardnum"].ToString(), Convert.ToDateTime(dbDataRecord["dealdate"].ToString()).Date);
                        dgvElements.Add(deal);
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return dgvElements;
        }

        public List<Deal> GetDeals(Car car)
        {
            List<Deal> dgvElements = new List<Deal>();
            
            try
            {
                NpgsqlDataReader AZSTableReader = null;
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT fueltype, fuelamount, dealprice, dealdate FROM \"AZS\".\"Deal\" WHERE car_id = @Car_id", dbc.getConnection());
                //NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT fueltype, fuelamount, dealprice, dealdate FROM \"AZS\".\"Deal\" WHERE car_id = '" + car.GetCar_id() + "' ", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Car_id", car.GetCar_id());
                AZSTableReader = queryCommand.ExecuteReader();
                //NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Deal foundDeal = new Deal();
                        foundDeal.dealSet(dbDataRecord["fueltype"].ToString(), Convert.ToInt32(dbDataRecord["fuelamount"].ToString()),
                            Convert.ToInt32(dbDataRecord["dealprice"]), Convert.ToDateTime(dbDataRecord["dealdate"].ToString()));
                        dgvElements.Add(foundDeal);
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return dgvElements;
        }

        public List<string> GetCardNumList()
        {
            List<string> comboBoxElements = new List<string>();

            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT DISTINCT cardnum FROM \"AZS\".\"Car\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        comboBoxElements.Add(dbDataRecord["cardnum"].ToString());
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return comboBoxElements;
        }

        public void AddToCarTable(Car car)
        {
            NpgsqlCommand queryCommand;
            try
            {
                dbc.openConnection();

                queryCommand = new NpgsqlCommand("INSERT INTO \"AZS\".\"Car\"(carmark, cardnum)" +
                "VALUES(@carmark, @cardnum)", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@carmark", car.GetCarMark());
                queryCommand.Parameters.AddWithValue("@cardnum", car.GetCardNum());

                queryCommand.ExecuteNonQuery();
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }
        }

        public List<Account> GetAccounting()
        {
            List<Account> dgvElements = new List<Account>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT  * FROM \"AZS\".\"Accounting\" ORDER BY accountdate", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Account account = new Account();
                        account.accountSet(Convert.ToInt32(dbDataRecord["station_id"]), dbDataRecord["station_adres"].ToString(),
                            dbDataRecord["fuelaccounttype"].ToString(), Convert.ToInt32(dbDataRecord["fuelaccountamount"]),
                            Convert.ToDateTime(dbDataRecord["accountdate"].ToString()));
                        dgvElements.Add(account);
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return dgvElements;
        }

        public List<Deal> ShowDealTable()
        {
            List<Deal> dealList = new List<Deal>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Deal\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Deal deal = new Deal();

                        deal.dealSet(Convert.ToInt32(dbDataRecord["deal_id"]), Convert.ToInt32(dbDataRecord["car_id"]), Convert.ToInt32(dbDataRecord["staff_id"]),
                            dbDataRecord["fueltype"].ToString(), Convert.ToInt32(dbDataRecord["fuelamount"]), Convert.ToInt32(dbDataRecord["dealprice"]),
                            dbDataRecord["cardnum"].ToString(), Convert.ToDateTime(dbDataRecord["dealdate"].ToString()));
                        dealList.Add(deal);
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return dealList;
        }

        public string FindStaffByID(int staff_id)
        {
            string SName = "", name, surname;
            try
            {
                NpgsqlDataReader AZSTableReader = null;
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT surname, name FROM \"AZS\".\"Staff\" WHERE staff_id = @Staff_id ", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Staff_id", staff_id);
                AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        surname = dbDataRecord["surname"].ToString().Replace(" ", string.Empty);
                        name = dbDataRecord["name"].ToString().Replace(" ", string.Empty);
                        SName = surname + " " + name;
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return SName;
        }

        public void UpdateDealTabele(Deal dealToUpdate, Deal deal)
        {
            try
            {
                dbc.openConnection();
                //NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"AZS\".\"Deal\" SET fueltype = '" + deal.GetFuelType() + "', fuelamount = '" + deal.GetFuelAmount() + 
                //"', dealprice = '" + deal.GetDealPrice() + "', cardnum = '" + deal.GetCardNum() + "', dealdate = '" + deal.GetDealDate() + "'" +
                //" WHERE deal_id = " + Convert.ToInt32(dealToUpdate.GetDeal_id()) + " ", dbc.getConnection());
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"AZS\".\"Deal\" SET fueltype = @Fueltype, fuelamount = @Fuelamount, dealprice = @DealPrice,"+
                    "cardnum = @Cardnum, dealdate = @DealDate WHERE deal_id = @Deal_id ", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Fueltype", deal.GetFuelType());
                queryCommand.Parameters.AddWithValue("@Fuelamount", deal.GetFuelAmount());
                queryCommand.Parameters.AddWithValue("@DealPrice", deal.GetDealPrice());
                queryCommand.Parameters.AddWithValue("@Cardnum", deal.GetCardNum());
                queryCommand.Parameters.AddWithValue("@DealDate", deal.GetDealDate());
                queryCommand.Parameters.AddWithValue("@Deal_id", dealToUpdate.GetDeal_id());
                queryCommand.ExecuteNonQuery();

            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }
        }
    }
}
