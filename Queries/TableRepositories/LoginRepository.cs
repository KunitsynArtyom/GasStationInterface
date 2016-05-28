﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;
using System.Collections;
using Queries.Entities;
using Queries.Interfaces;

namespace Queries.TableRepositories
{
    public class LoginRepository : ILoginRepository
    {
        DBConnection dbc;

        public LoginRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }

        public string LoginToTable(Login login)
        {
            string role = "";
            try
            {
                dbc.openConnection();
            //NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"Login\".\"LoginTable\"  WHERE login LIKE" + "'%" + login.GetLogin() + "%'" +  "AND password LIKE" + "'%" + login.GetPassword() + "%'" + "", dbc.getConnection());
            NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"Login\".\"LoginTable\" WHERE login = @Login AND password = @Password", dbc.getConnection());
            queryCommand.Parameters.AddWithValue("@Login", login.GetLogin());
            queryCommand.Parameters.AddWithValue("@Password", login.GetPassword());


            NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
            MessageBox.Show(AZSTableReader.HasRows.ToString());
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        role = dbDataRecord["role"].ToString();
                    }
                }

            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return role;
        }

        public void AddNewAdmin(NewAdmin admin)
        {
            try
            {
                dbc.openConnection();

                NpgsqlCommand queryCommand = new NpgsqlCommand("INSERT INTO \"Login\".\"LoginTable\"(Login, Password, Role)" +
                    "VALUES(@Login, @Pass, @Role)", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Login", admin.GetAdminLogin());
                queryCommand.Parameters.AddWithValue("@Pass", admin.GetAdminPass());
                queryCommand.Parameters.AddWithValue("@Role", admin.GetAdminRole());
                queryCommand.ExecuteNonQuery();
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

        }
    }
}