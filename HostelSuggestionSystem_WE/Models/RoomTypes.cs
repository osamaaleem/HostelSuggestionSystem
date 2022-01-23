using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostelSuggestionSystem_WE.Models
{
    public class RoomTypes
    {
        public Int64 RoomTypeId { get; set; }
        public string RoomTypeName { get; set;}
        public string RoomTypeDescription { get; set; }
        public int BedCount { get; set; }
        public bool IsBathAttached { get; set; }
        public bool IsPrivate { get; set; }
    }
}