using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HostelSuggestionSystem_WE.Models;


namespace HostelSuggestionSystem_WE.DAL
{
    public class HostelsEntity
    {
        public HostelsEntity()
        {
            connection = new SqlConnection(connString);
        }
        private string connString = ConfigurationManager.ConnectionStrings["weProjectDbEntities"].ConnectionString;
        private SqlConnection connection;
        private string query;
        private SqlCommand cmd;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder builder;
        public List<Hostels> GetHostels()
        {
            DataSet ds = new DataSet();
            query = "SELECT * FROM Hostels";
            cmd = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds,"Hostels");
            
            return RoomsList(ds.Tables["Hostels"]);
        }
        public List<Hostels> GetHostelsByFilter(string filter, string filterBody)
        {
            DataSet ds = new DataSet();
            switch (filter)
            {
                case "Distance":
                    query = "SELECT * FROM Hostels ORDER BY HostelDistance ASC";
                    break;
                case "Rating":
                    query = "SELECT * FROM Hostels ORDER BY HostelRating DESC";
                    break;
                case "City":
                    query = $"SELECT * FROM Hostels WHERE HostelCity LIKE '%{filterBody}%'";
                    break;
                case "Name":
                    query = $"SELECT * FROM Hostels WHERE HostelName like '%{filterBody}%' OR HostelCity like '%{filterBody}%'";
                    break;
                default:
                    ds = null;
                    break;
            }
            try
            {
                cmd = new SqlCommand(query, connection);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds,"Hostels");
            }
            catch (Exception ex)
            {
                ds = null;
            }
            if (ds != null)
            {
                return RoomsList(ds.Tables["Hostels"]);
            }
            return GetHostels();
        }
        public List<Hostels> GetHostelsById(Int64 id)
        {
            DataSet ds = new DataSet();
            query = $"SELECT * FROM Hostels WHERE HostelId = '{id}'";
            cmd = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "Hostels");
            return RoomsList(ds.Tables["Hostels"]);
        }
        public int AddHostels(Hostels hostels)
        {
            int count = 0;
            query = $"INSERT INTO Hostels VALUES('{hostels.HostelName}','{hostels.HostelAddress}','{hostels.HostelCity}','{hostels.HostelDistance}','{hostels.HostelRating}','{hostels.HostelImageUrl}')";
            cmd = new SqlCommand(query, connection);
            connection.Open();
            try
            {
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                count = 0;
            }
            connection.Close();
            return count;
        }
        public int UpdateHostel(Hostels hostel)
        {
            int rowsAffected = 0;
            query = $"UPDATE Hostels SET " +
                $"HostelName = '{hostel.HostelName}', " +
                $"HostelAddress = '{hostel.HostelAddress}', " +
                $"HostelCity = '{hostel.HostelCity}', " +
                $"HostelDistance = '{hostel.HostelDistance}', " +
                $"HostelRating = '{hostel.HostelRating}', " +
                $"HostelImageUrl = '{hostel.HostelImageUrl}' " +
                $"WHERE HostelId = '{hostel.HostelId}'";
            connection.Open();
            cmd = new SqlCommand(query, connection);
            try
            {
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsAffected = 0;
            }
            connection.Close();
            return rowsAffected;
        }
        public List<Hostels> RoomsList(DataTable dt)
        {
            List<Hostels> list = new List<Hostels>();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Hostels
                    {
                        HostelId = Convert.ToInt64(dr["HostelId"]),
                        HostelName = dr["HostelName"].ToString(),
                        HostelAddress = dr["HostelAddress"].ToString(),
                        HostelCity = dr["HostelCity"].ToString(),
                        HostelRating = Convert.ToDouble(dr["HostelRating"]),
                        HostelDistance = Convert.ToDouble(dr["HostelDistance"]),
                        HostelImageUrl = dr["HostelImageUrl"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                list = GetHostels();
            }
            
            return list;
        }
        public int DeleteHostel(Int64 id)
        {
            int rowsAffected = 0;
            query = $"DELETE FROM Hostels WHERE HostelId = '{id}'";
            connection.Open();
            cmd = new SqlCommand(query, connection);
            try
            {
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsAffected = 0;
            }
            connection.Close();
            return rowsAffected;
        }
    }
}