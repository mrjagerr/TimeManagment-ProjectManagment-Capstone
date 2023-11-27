using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
   public class Zone //zone for that day
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AreaToZone { get; set; } //Area that needs to be zoned

        [Required]
        public int WorkloadValue { get; set; } // hrs requried to do work
        [Required]
        public DateTime ProjectDate { get; set; }

        [Required]
        public string DepartmentName { get; set; }





    }
}
