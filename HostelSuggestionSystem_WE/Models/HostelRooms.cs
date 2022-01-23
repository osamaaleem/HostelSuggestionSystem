using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostelSuggestionSystem_WE.Models
{
    public class HostelRooms
    {
        public Int64 HostelRoomId { get; set; }
        public Int64 HostelId { get; set; }
        public Int64 RoomTypeId { get; set; }
        public int RoomCount { get; set; }
        public int RoomsAvailable { get; set; }
        public int Price { get; set; }
    }
}