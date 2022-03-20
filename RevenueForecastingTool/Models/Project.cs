using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RevenueForecastingTool.Models
{
    public class Project
    {
        public int id { get; set; }
        [Required]
        public string Client { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public int  JobNumber { get; set; }
        [Required]
        public string Month { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public decimal Revenue { get; set; }
    }
}