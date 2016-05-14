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

namespace Queries.TableRepositories
{
    public class StaffRepository 
    {
        public DBConnection dbc;

        public StaffRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }

        public List<Worker> GetStaff()
        {
            List<Worker> dgvElements = new List<Worker>();
            try
            {
                //dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Staff\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
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
                AZSTableReader.Close();
            }
            catch (NpgsqlException ne)
            {

            }
            //finally { dbc.closeConnection(); }
            return dgvElements;
        }

        public void AddToStaffTable(Worker wk)
        {
            NpgsqlCommand queryCommand;
            try
            {
                //dbc.openConnection();
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
                    queryCommand.ExecuteNonQuery();
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
                    queryCommand.ExecuteNonQuery();
                }
                //finally { dbc.closeConnection(); }
            }
            catch (NpgsqlException ne)
            {

            }

            //finally { dbc.closeConnection(); }
        }

        public void UpdateStaffTable(Worker wkToUpdate, Worker wk)
        {
            try
            {
                //dbc.openConnection();
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
            //finally { dbc.closeConnection(); }
        }

        public void DeleteFromStaffTabele(Worker wkToDelete)
        {
            try
            {
                //dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"AZS\".\"Staff\"  WHERE staff_id = @Staff_id", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Staff_id", Convert.ToInt32(wkToDelete.GetStaff_id()));
                queryCommand.ExecuteNonQuery();

            }
            catch (NpgsqlException ne)
            {

            }
            //finally { dbc.closeConnection(); }
        }

        public string FindStaffByID(int staff_id)
        {
            string SName = "", name, surname;
            try
            {
                NpgsqlDataReader AZSTableReader = null;
                //dbc.openConnection();
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
                AZSTableReader.Close();
            }
            catch (NpgsqlException ne)
            {

            }
            //finally { dbc.closeConnection(); }

            return SName;
        }
    }
}
