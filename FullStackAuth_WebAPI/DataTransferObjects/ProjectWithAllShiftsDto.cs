﻿using FullStackAuth_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ProjectWithAllShiftsDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDate { get; set; }
        public int WorkLoadAllocation { get; set; }
        public int TotalWorkloadRequired { get; set; }
        public int WorkLoadCompleted { get; set; }
        public double PercentCompleted { get; set; }
        public ICollection<ShiftForDisplayDto> ShiftForDisplays { get; set;}
    }
       
}
