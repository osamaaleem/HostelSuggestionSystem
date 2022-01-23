using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostelSuggestionSystem_WE.Models
{
    public class Hostels
    {
        public Int64 HostelId { get; set; }
        public string HostelName { get; set; }
        public string HostelAddress { get; set; }
        public string HostelCity { get; set; }
        public double HostelDistance { get; set; }
        public double HostelRating { get; set; }
        public string HostelImageUrl { get; set; }
        public HttpPostedFileBase HostelImage { get; set; }
    }
}