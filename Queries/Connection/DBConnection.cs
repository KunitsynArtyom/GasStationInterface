using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace Queries
{
    public class DBConnection //класс, устанавливающий соединение с базой данных
    {
        public NpgsqlConnection conn;
        public DBConnection(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        public void setConnection(NpgsqlConnection conn)
        {
            this.conn = conn;
        }

        public void openConnection()
        {
            try
            {
                conn.Open();
            }
            catch (PostgresException ne) { MessageBox.Show(ne.ToString()); }
        }

        public NpgsqlConnection getConnection()
        {
            return conn;
        }

        public void closeConnection()
        {
            try
            {
                conn.Close();
            }
            catch (NpgsqlException) { }
        }
    }
}
