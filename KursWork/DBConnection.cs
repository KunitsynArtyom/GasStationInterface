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
    class DBConnection //класс, устанавливающий соединение с базой данных
    {
        public NpgsqlConnection conn;
        public DBConnection(NpgsqlConnection conn)
        {
            //conn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = qwerty1; Database = AZS");
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
            catch (NpgsqlException ne) { MessageBox.Show(Convert.ToString(ne)); }
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
        catch (NpgsqlException ne) { MessageBox.Show(Convert.ToString(ne)); }
        }
    }
}
