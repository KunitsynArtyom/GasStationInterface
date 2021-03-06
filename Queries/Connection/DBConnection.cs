﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace Queries
{
    public class DBConnection 
    {
        private NpgsqlConnection conn;

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
            catch (Exception) {  }
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
            catch (Exception) { }
        }
    }
}
