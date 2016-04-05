using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;
using Connection;

namespace Queries
{
    public class AdminQuery
    {
        public DataGridView dgv;
        public DBConnection dbc;
        public AdminQuery(NpgsqlConnection conn, DataGridView dgv)
        {
            dbc = new DBConnection(conn);
            this.dgv = dgv;
        }

        public void showStaffTabele()
        {
            try
            {
                dbc.openConnection();
                if (!dgv.Equals(0))
                {
                    dgv.Rows.Clear();
                }
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Staff\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        dgv.Rows.Add(dbDataRecord["surname"].ToString(), dbDataRecord["name"].ToString(), dbDataRecord["gender"].ToString(), dbDataRecord["function"].ToString());
                    }
                }
                dbc.closeConnection();
            }
            catch (NpgsqlException ne)
            {
                MessageBox.Show(Convert.ToString(ne));
            }
        }

        public void addToStaffTable(int staff_id, int station_id, String surname, String name, String gender, DateTime birthdate, String function, int manager, int salary)
        {
            NpgsqlCommand queryCommand;
            try
            {
                dbc.openConnection();
                if (manager != 0)
                {
                    queryCommand = new NpgsqlCommand("INSERT INTO \"AZS\".\"Staff\"(Station_id, Surname, Name, Gender, Birthdate, Function, Manager, Salary) VALUES(@Station_id, @Surname, @Name, @Gender, @Birthdate, @Function, @Manager, @Salary)", dbc.getConnection());
                    //queryCommand.Parameters.AddWithValue("@Staff_id", staff_id);
                    queryCommand.Parameters.AddWithValue("@Station_id", station_id);
                    queryCommand.Parameters.AddWithValue("@Surname", surname);
                    queryCommand.Parameters.AddWithValue("@Name", name);
                    queryCommand.Parameters.AddWithValue("@Gender", gender);
                    queryCommand.Parameters.AddWithValue("@Birthdate", birthdate);
                    queryCommand.Parameters.AddWithValue("@Function", function);
                    queryCommand.Parameters.AddWithValue("@Manager", manager);
                    queryCommand.Parameters.AddWithValue("@Salary", salary);
                }
                else
                {
                    queryCommand = new NpgsqlCommand("INSERT INTO \"AZS\".\"Staff\"(Station_id, Surname, Name, Gender, Birthdate, Function, Salary) VALUES(@Station_id, @Surname, @Name, @Gender, @Birthdate, @Function, @Salary)", dbc.getConnection());
                    //queryCommand.Parameters.AddWithValue("@Staff_id", staff_id);
                    queryCommand.Parameters.AddWithValue("@Station_id", station_id);
                    queryCommand.Parameters.AddWithValue("@Surname", surname);
                    queryCommand.Parameters.AddWithValue("@Name", name);
                    queryCommand.Parameters.AddWithValue("@Gender", gender);
                    queryCommand.Parameters.AddWithValue("@Birthdate", birthdate);
                    queryCommand.Parameters.AddWithValue("@Function", function);
                    queryCommand.Parameters.AddWithValue("@Salary", salary);
                }
                try
                {
                    queryCommand.ExecuteNonQuery();
                }
                catch (NpgsqlException ne)
                {
                    MessageBox.Show(Convert.ToString(ne));
                }
                //queryCommand.ExecuteNonQuery();
                //NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                dbc.closeConnection();
            }
            catch (NpgsqlException ne)
            {
                MessageBox.Show(Convert.ToString(ne));
            }
        }

        public void updateStaffTabele(DataGridViewRow updateRow, int station_id, String surname, String name, String gender, DateTime birthdate, String function, int manager, int salary)
        {
            try
            {
                dbc.openConnection();
                string oldSurname = Convert.ToString(updateRow.Cells["surname"].Value);
                string oldName = Convert.ToString(updateRow.Cells["name"].Value);
                string oldGender = Convert.ToString(updateRow.Cells["gender"].Value);
                string oldFunction = Convert.ToString(updateRow.Cells["function"].Value);
                MessageBox.Show(Convert.ToString(surname + name + gender + function));
                //row.Cells[ratingColumn].Value = stars;
                //DataGridViewRow updateRow = dgv.Rows[0];
                NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"AZS\".\"Staff\" SET surname = '" + surname + "', name = '" + name + "', gender = '" + gender + "', function = '" + function + "' WHERE surname = '" + oldSurname + "' AND name = '" + oldName + "' AND gender = '" + oldGender + "' AND function = '" + oldFunction + "' ", dbc.getConnection());
                //NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                //NpgsqlCommand queryCommand = new NpgsqlCommand("UPDATE \"AZS\".\"Staff\" SET surname = 'azv' WHERE surname = 'a'", dbc.getConnection());
                queryCommand.ExecuteNonQuery();

                dbc.closeConnection();
            }
            catch (NpgsqlException ne)
            {
                MessageBox.Show(Convert.ToString(ne));
            }
        }
    }
}
