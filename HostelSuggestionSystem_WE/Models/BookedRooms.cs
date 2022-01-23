using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostelSuggestionSystem_WE.Models
{
    public class BookedRooms
    {
        public Int64 BookedRoomsId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 HostelRoomId { get; set; }
    }
}