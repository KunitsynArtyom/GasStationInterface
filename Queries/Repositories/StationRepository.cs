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

namespace Queries.Repositories
{
    public class StationRepository : IStationRepository
    {
        private DBConnection dbc;

        public StationRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }

        public void Dispose()
        {

        }

        public List<Station> GetStations()
        {
            List<Station> stationList = new List<Station>();
            try
            {

                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"GasStation\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Station st = new Station();
                        st.stationSet(Convert.ToInt32(dbDataRecord["station_id"]), dbDataRecord["orgname"].ToString(), dbDataRecord["country"].ToString(),
                            dbDataRecord["city"].ToString(), dbDataRecord["street"].ToString(), Convert.ToInt32(dbDataRecord["storagecap"]));
                        stationList.Add(st);
                    }
                }
                 AZSTableReader.Close();
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }
            return stationList;
        }

        public List<Station> FindStations(string fCountry, string fCity)
        {
            List<Station> stationList = new List<Station>();
            dbc.openConnection();
            try
            {
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"GasStation\" WHERE country LIKE" +
                " @fCountry AND city LIKE @fCity ", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@fCountry", "%" + fCountry + "%");
                queryCommand.Parameters.AddWithValue("@fCity", "%" + fCity + "%");

                NpgsqlDataReader AZSTableSearcher = queryCommand.ExecuteReader();
                if (AZSTableSearcher.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableSearcher)
                    {
                        Station st = new Station();
                        st.stationSet(Convert.ToInt32(dbDataRecord["station_id"]),
                            dbDataRecord["orgname"].ToString(),
                            dbDataRecord["country"].ToString(),
                            dbDataRecord["city"].ToString(),
                            dbDataRecord["street"].ToString(),
                            Convert.ToInt32(dbDataRecord["storagecap"]));
                        stationList.Add(st);
                    }
                    AZSTableSearcher.Close();
                }
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }
            return stationList;
        }

        public int FindStationIDByLocation(string location)
        {
            int station_id = 0;
            try
            {

                List<string> splittedLocation = new List<string>();
                if (location != String.Empty)
                {
                    string[] split = location.Split(new Char[] { ',' });
                    foreach (string s in split)
                    {
                        splittedLocation.Add(s);
                    }
                    splittedLocation[2] = CheckRigthStreet(splittedLocation[2]);
                }
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"GasStation\" WHERE country =" +
                  "'" + splittedLocation[0] + "' AND city =" + "'" + splittedLocation[1] + "'" + "AND street =" + "'" + splittedLocation[2] + "'" + "", dbc.getConnection());

                //NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"GasStation\" WHERE country LIKE" +
                //  "'%" + splittedLocation[0] + "%' AND city LIKE" + "'%" + splittedLocation[1] + "%'" + "AND street LIKE" + "'%" + splittedLocation[2] + "%'" + "", dbc.getConnection());

                NpgsqlDataReader Station_ID_TableSearcher = queryCommand.ExecuteReader();
                if (Station_ID_TableSearcher.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in Station_ID_TableSearcher)
                    {
                        station_id = Convert.ToInt32(dbDataRecord["station_id"]);
                    }
                }
                Station_ID_TableSearcher.Close();
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }
            return station_id;
        }

        public List<string> GetStationsAdres(string Orgname)
        {
            List<string> comboBoxElements = new List<string>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT country, city, street FROM \"AZS\".\"GasStation\" WHERE orgname LIKE @Orgname ", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Orgname", "%" + Orgname + "%");
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        comboBoxElements.Add(dbDataRecord["country"].ToString() + "," + dbDataRecord["city"].ToString() + "," + dbDataRecord["street"].ToString());
                    }
                    
                }
                AZSTableReader.Close();
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }

            return comboBoxElements;
        }

        public string GetStationAdresByID(int station_id)
        {
            string location = String.Empty;
            var comboBoxElements = new List<string>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT country, city, street FROM \"AZS\".\"GasStation\" WHERE station_id = @Station_id ", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Station_id", station_id);
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        location = dbDataRecord["country"].ToString() + "," + dbDataRecord["city"].ToString() + "," + dbDataRecord["street"].ToString();
                    }

                }
                AZSTableReader.Close();
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }

            return location.Trim().Replace(" ", string.Empty);
        }

        public List<string> GetOrganisations()
        {
            List<string> comboBoxElements = new List<string>();

            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT DISTINCT orgname FROM \"AZS\".\"GasStation\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        comboBoxElements.Add(dbDataRecord["orgname"].ToString());
                    }
                }
                AZSTableReader.Close();
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }

            return comboBoxElements;
        }

        public void AddToStationTable(Station st)
        {
            try
            {
                dbc.openConnection();

                NpgsqlCommand queryCommand = new NpgsqlCommand("INSERT INTO \"AZS\".\"GasStation\"(OrgName, Country, City, Street, StorageCap)" +
                        "VALUES(@OrgName, @Country, @City, @Street, @StorageCap)", dbc.getConnection());
                    queryCommand.Parameters.AddWithValue("@OrgName", st.GetOrgName());
                    queryCommand.Parameters.AddWithValue("@Country", st.GetCountry());
                    queryCommand.Parameters.AddWithValue("@City", st.GetCity());
                    queryCommand.Parameters.AddWithValue("@Street", st.GetStreet());
                    queryCommand.Parameters.AddWithValue("@StorageCap", st.GetStorageCap());
                    queryCommand.ExecuteNonQuery();
            }
            catch (PostgresException pe)
            {
                throw pe;
            }
            finally { dbc.closeConnection(); }

        }

        private string CheckRigthStreet(string street)
        {
            try
            {
                for (int i = 1; i < street.Length; i++)
                {
                    if ((street[i] >= 'А' && street[i] <= 'Я') && (street[i - 1] >= 'а' && street[i - 1] <= 'я'))
                    {
                        street = street.Insert(i, " ");
                    }
                    if ((street[i] >= 'A' && street[i] <= 'Z') && (street[i - 1] >= 'a' && street[i - 1] <= 'z'))
                    {
                        street = street.Insert(i, " ");
                    }
                    if ((street[i] >= '0' && street[i] <= '9') && (street[i - 1] >= 'а' && street[i - 1] <= 'я'))
                    {
                        street = street.Insert(i, " ");
                    }
                    if ((street[i] >= '0' && street[i] <= '9') && (street[i - 1] >= 'a' && street[i - 1] <= 'z'))
                    {
                        street = street.Insert(i, " ");
                    }
                }
            }
            catch (Exception) { };
            return street;
        }
    }
}
