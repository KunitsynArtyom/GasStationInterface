using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using System.Data.Common;

namespace KursWork
{
    class AdminQuery
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
    }
}
