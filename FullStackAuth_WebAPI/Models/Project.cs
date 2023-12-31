﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace FullStackAuth_WebAPI.Models
{
    public class Project //total days project that needs to be completed
    {

        [Key]
        public int Id { get; set; }
       
        public string ProjectName { get; set; }

     
        public string ProjectDate { get; set; }

        [Required]
        public int WorkLoadAllocation { get; set; }

        [Required]
        public int TotalWorkloadRequired { get; set; }
        public ICollection<Shift> Shift { get; set; }
        public int WorkloadCompleted {  get; set; }
        public double PercentCompleted { get; set; }






        [ForeignKey("Owner")]
        public string OwnerId { get; set; }

        public User Owner { get; set; }

    }


}
