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
using Queries.Interfaces;
using Queries.Security;

namespace Queries.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private DBConnection dbc;

        public LoginRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }

        public string LoginToTable(Login login)
        {
            string role = String.Empty;
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"Login\".\"LoginTable\" WHERE login = @Login AND password = @Password", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Login", login.GetLogin());
                queryCommand.Parameters.AddWithValue("@Password", login.GetPassword());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        role = dbDataRecord["role"].ToString();
                    }
                }

            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }

            return role;
        }

        public void AddNewDBUser(DBUser dbUser)
        {            
            try
            {
                dbc.openConnection();            
                
                NpgsqlCommand queryCommand = new NpgsqlCommand("INSERT INTO \"Login\".\"LoginTable\"(Login, Password, Role)" +
                    "VALUES(@Login, @Pass, @Role)", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Login", dbUser.GetDBUserLogin());
                queryCommand.Parameters.AddWithValue("@Pass", SecurityCrypt.MD5((dbUser.GetDBUserPass())));
                queryCommand.Parameters.AddWithValue("@Role", dbUser.GetDBUserRole());
                queryCommand.ExecuteNonQuery();
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }
        }

        public bool CheckLoginExistence(string login)
        {
            bool checkFlag = false;
            try
            {
                dbc.openConnection();

                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"Login\".\"LoginTable\" WHERE login = @Login", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Login", login);
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    checkFlag = true;
                }
                else checkFlag = false;
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }

            return checkFlag;
        }      

        public string GetRolePass(string role)
        {
            string passWord = String.Empty;
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT Password FROM \"Login\".\"RoleTable\" WHERE Role = @Role", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Role", role);

                NpgsqlDataReader passWordSearch = queryCommand.ExecuteReader();
                if (passWordSearch.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in passWordSearch)
                    {
                        passWord = dbDataRecord["Password"].ToString();
                    }
                    passWordSearch.Close();
                }
            }
            catch (PostgresException pe)
            {
                throw pe;          
            }
            finally { dbc.closeConnection(); }

            return passWord;

        }

        public void DeleteStaffFromLoginTable(string id)
        {
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("DELETE FROM \"Login\".\"LoginTable\"  WHERE login = @Login", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Login", id);
                queryCommand.ExecuteNonQuery();

            }
            catch (PostgresException)
            { }
            finally { dbc.closeConnection(); }

        }
    }
}
