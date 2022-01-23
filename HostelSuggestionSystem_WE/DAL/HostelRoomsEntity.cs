using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using HostelSuggestionSystem_WE.Models;
using System.Web;

namespace HostelSuggestionSystem_WE.DAL
{
    public class HostelRoomsEntity
    {
        public HostelRoomsEntity()
        {
            connection = new SqlConnection(connString);
        }
        private string connString = ConfigurationManager.ConnectionStrings["weProjectDbEntities"].ConnectionString;
        private SqlConnection connection;
        private string query;
        private SqlCommand cmd;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder builder;
        public List<HostelRooms> GetHostelRooms(int hostelId)
        {
            DataSet ds = new DataSet();
            query = $"SELECT * FROM HostelRooms hr INNER JOIN RoomTypes rt ON hr.RoomTypeId_FK = rt.RoomTypeId  WHERE hr.HostelId_FK = {hostelId}";
            cmd = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "HostelRooms");
            return RoomsList(ds.Tables["HostelRooms"]);
        }
        public int AddHostelRoom(int hostelId, HostelRooms room)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            query = $"SELECT * FROM HostelRooms";
            cmd = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "HostelRooms");
            builder = new SqlCommandBuilder(adapter);
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            return adapter.Update(dt);
        }
        public List<HostelRooms> RoomsList(DataTable dt)
        {
            List<HostelRooms> list = new List<HostelRooms>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new HostelRooms
                {
                    HostelRoomId = Convert.ToInt64(dr["HostelRoomId"]),
                    HostelId = Convert.ToInt64(dr["HostelId"]),
                    RoomTypeId = Convert.ToInt64(dr["RoomTypeId"]),
                    RoomCount = Convert.ToInt32(dr["RoomCount"]),
                    RoomsAvailable = Convert.ToInt32(dr["RoomsAvailable"]),
                    Price = Convert.ToInt32(dr["Price"])
                });
            }
            return list;
        }
    }
}