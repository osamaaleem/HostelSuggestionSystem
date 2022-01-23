using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HostelSuggestionSystem_WE.Models
{
    public class Hostels
    {
        public Int64? HostelId { get; set; }
        [Required,Display(Name = "Hostel Name")]
        public string HostelName { get; set; }
        [Required,Display(Name = "Address")]
        public string HostelAddress { get; set; }
        [Required,Display(Name = "City")]
        public string HostelCity { get; set; }
        [Required,Display(Name = "Distance from city center")]
        public double HostelDistance { get; set; }
        [Required,Display(Name = "Ratings")]
        public double HostelRating { get; set; }
        [Display(Name = "Image")]
        public string HostelImageUrl { get; set; }
        public HttpPostedFileBase HostelImage { get; set; }
    }
}