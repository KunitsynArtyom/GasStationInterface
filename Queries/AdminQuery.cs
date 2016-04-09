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

namespace Queries
{
    public class AdminQuery
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

        public void updateStaffTabele(string oldSurname, string oldName, string oldGender, string oldFunction, Worker wk)
        {
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"AZS\".\"Staff\" SET surname = '" + wk.GetSurname() + "', name = '" + wk.GetName() + "', gender = '" + wk.GetGender() + "', function = '" + wk.GetFunction() +
                "' WHERE surname = '" + oldSurname + "' AND name = '" + oldName + "' AND gender = '" + oldGender + "' AND function = '" + oldFunction + "' ", dbc.getConnection());
                queryCommand.ExecuteNonQuery();

                //dbc.closeConnection();
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }
        }
    }
}
