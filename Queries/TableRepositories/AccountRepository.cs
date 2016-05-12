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
    public class AccountRepository
    {
        public DBConnection dbc;

        public AccountRepository(NpgsqlConnection conn)
        {
            dbc = new DBConnection(conn);
        }

        public List<Account> GetAccounting()
        {
            List<Account> dgvElements = new List<Account>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT  * FROM \"AZS\".\"Accounting\" ORDER BY accountdate", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Account account = new Account();
                        account.accountSet(Convert.ToInt32(dbDataRecord["station_id"]), dbDataRecord["station_adres"].ToString(),
                            dbDataRecord["fuelaccounttype"].ToString(), Convert.ToInt32(dbDataRecord["fuelaccountamount"]),
                            Convert.ToDateTime(dbDataRecord["accountdate"].ToString()));
                        dgvElements.Add(account);
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return dgvElements;
        }
    }
}
