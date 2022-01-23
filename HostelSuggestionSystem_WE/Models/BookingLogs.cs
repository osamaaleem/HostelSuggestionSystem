using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostelSuggestionSystem_WE.Models
{
    public class BookingLogs
    {
        public Int64 LogId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 HostelId { get; set; }
        public Int64 HostelRoomId { get; set; }
        public DateTime Created { get; set; }
    }
}