using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ZoneDto
    {
        public string Id { get; set; }
        public string AreaToZone { get; set; } //Area that needs to be zoned

      
        public int WorkloadValue { get; set; } // hrs requried to do work
      
        public DateTime ProjectDate { get; set; }

       
        public string DepartmentName { get; set; }
    }
}
