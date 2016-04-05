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
    public class UserQuery //класс, содержащий в себе методы-запросы к таблице GasStation
    {
        public DataGridView dgv;
        //DBConnection dbc = new DBConnection();
        public DBConnection dbc;
        public UserQuery(NpgsqlConnection conn, DataGridView dgv)
        {
            dbc = new DBConnection(conn);
            this.dgv = dgv;
        }
        public void showAZSTabele()
        {
            try
            {
                dbc.openConnection();
                if (!dgv.Equals(0))
                {
                    dgv.Rows.Clear();
                }
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"GasStation\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        dgv.Rows.Add(dbDataRecord["orgname"].ToString(), dbDataRecord["country"].ToString(), dbDataRecord["city"].ToString(), dbDataRecord["street"].ToString());
                    }
                }
                dbc.closeConnection();
            }
            catch (NpgsqlException ne)
            {
                MessageBox.Show(Convert.ToString(ne));
            }
        }

        public void findAZS(TextBox tbCountry, TextBox tbCity)
        {
            dbc.openConnection();
            dgv.Rows.Clear();
            String countrySearch, citySearch;
            countrySearch = tbCountry.Text;
            citySearch = tbCity.Text;
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"AZS\".\"GasStation\" WHERE country LIKE" + "'%" + countrySearch + "%' AND city LIKE" + "'%" + citySearch + "%'", dbc.getConnection());
                NpgsqlDataReader AZSTableSearcher = command.ExecuteReader();
                if (AZSTableSearcher.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableSearcher)
                    {
                        this.dgv.Rows.Add(dbDataRecord["orgname"].ToString(), dbDataRecord["country"].ToString(), dbDataRecord["city"].ToString(), dbDataRecord["street"].ToString());
                    }
                }
                dbc.closeConnection();
            }
            catch (NpgsqlException ne)
            {
                MessageBox.Show(Convert.ToString(ne));
            }
        }
    }
}
