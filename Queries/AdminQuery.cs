using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;
using Connection;
using System.Collections;
using Queries.Entities;

namespace Queries
{
    public class AdminQuery : IAdminQuery
    {
        public DataGridView dgv;
        public DBConnection dbc;
        public AdminQuery(NpgsqlConnection conn/*, DataGridView dgv*/)
        {
            dbc = new DBConnection(conn);
            //this.dgv = dgv;
        }

        public ArrayList showStaffTable()
        {
            var dgvElements = new ArrayList();
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
                //dbc.closeConnection();
            }
            catch (NpgsqlException ne)
            {
                
            }
            finally { dbc.closeConnection(); }
            return dgvElements;
        }

        public void addToStaffTable(Worker wk)
        {
            NpgsqlCommand queryCommand;
            try
            {
                dbc.openConnection();
                if (wk.GetManager() != 0)
                {
                    queryCommand = new NpgsqlCommand("INSERT INTO \"AZS\".\"Staff\"(Station_id, Surname, Name, Gender, Birthdate, Function, Manager, Salary)" + 
                        "VALUES(@Station_id, @Surname, @Name, @Gender, @Birthdate, @Function, @Manager, @Salary)", dbc.getConnection());
                    //queryCommand.Parameters.AddWithValue("@Staff_id", staff_id);
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
                    //queryCommand.Parameters.AddWithValue("@Staff_id", staff_id);
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

        public void updateStaffTabele(Worker wkToUpdate, Worker wk)
        {
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"AZS\".\"Staff\" SET surname = '" + wk.GetSurname() + "', name = '" + wk.GetName() + "', gender = '" + wk.GetGender() + "', function = '" + wk.GetFunction() + "'" +
                " WHERE staff_id = " + Convert.ToInt32(wkToUpdate.GetStaff_id()) + " ", dbc.getConnection());
                queryCommand.ExecuteNonQuery();

                //dbc.closeConnection();
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }
        }

        public void deleteFromStaffTabele(Worker wkToDelete)
        {
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"AZS\".\"Staff\"  WHERE staff_id = " + Convert.ToInt32(wkToDelete.GetStaff_id()) + " ", dbc.getConnection());
                queryCommand.ExecuteNonQuery();

                //dbc.closeConnection();
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }
        }

        public ArrayList getOrgList()
        {
            var comboBoxElements = new ArrayList();

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

        public ArrayList getStationList(string Orgname)
        {
            var comboBoxElements = new ArrayList();
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

        //public ArrayList splitLocation(string location)
        //{
        //    int station_id = 0;
        //    var splittedLocation = new ArrayList();
        //    string[] split = location.Split(new Char[] { ',' });
        //    foreach (string s in split)
        //    {
        //        //if (s.Trim() != "")
        //        splittedLocation.Add(s);
        //    }
        //    return splittedLocation;
        //}


        //public int[] findIDsByInfo(string surname, string name)
        //{
        //    int[] IDs = new int[2];
        //    try
        //    {
        //        dbc.openConnection();
        //        NpgsqlCommand command = new NpgsqlCommand("SELECT station_id, staff_id FROM \"AZS\".\"Staff\" WHERE surname LIKE" +
        //               "'%" + surname + "%' AND name LIKE" + "'%" + name + "%'", dbc.getConnection());
        //        NpgsqlDataReader Station_ID_TableSearcher = command.ExecuteReader();
        //        if (Station_ID_TableSearcher.HasRows)
        //        {
        //            foreach (DbDataRecord dbDataRecord in Station_ID_TableSearcher)
        //            {
        //                IDs[0] = Convert.ToInt32(dbDataRecord["station_id"]);
        //                IDs[1] = Convert.ToInt32(dbDataRecord["staff_id"]);
        //                //station_id = Convert.ToInt32(dbDataRecord["station_id"]);
        //            }
        //        }
        //    }
        //    catch (NpgsqlException ne) { }
        //    finally { dbc.closeConnection(); }
        //    return IDs;
        //}

        public int findIDByLocation(string location)
        {
            int station_id = 0;
            var splittedLocation = new ArrayList();
            string[] split = location.Split(new Char[] {','});
            foreach (string s in split)
            {
                //if (s.Trim() != "")
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
            catch (NpgsqlException ne) { }
            finally { dbc.closeConnection(); }
            return station_id;
        }

        public ArrayList showCarTable()
        {
            var dgvElements = new ArrayList();
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

        public ArrayList showDealTable()
        {
            var dgvElements = new ArrayList();
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
                            Convert.ToInt32(dbDataRecord["station_id"]), Convert.ToInt32(dbDataRecord["staff_id"]),
                            dbDataRecord["fueltype"].ToString(), Convert.ToInt32(dbDataRecord["fuelamount"]), 
                            dbDataRecord["cardnum"].ToString(), Convert.ToDateTime(dbDataRecord["dealdate"].ToString()));
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

        public ArrayList findDealList(Deal deal)
        {
            var dgvElements = new ArrayList();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT fueltype, fuelamount, cardnum, dealdate FROM \"AZS\".\"Deal\" WHERE car_id = '" + deal.GetCar_id() + "' ", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Deal foundDeal = new Deal();
                        foundDeal.dealSet(dbDataRecord["fueltype"].ToString(), Convert.ToInt32(dbDataRecord["fuelamount"].ToString()), dbDataRecord["cardnum"].ToString(), Convert.ToDateTime(dbDataRecord["dealdate"].ToString()));
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
    }
}
