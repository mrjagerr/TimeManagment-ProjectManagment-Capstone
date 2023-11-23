using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class Zone
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AreaToZone { get; set; } //Area that needs to be zoned

        [Required]
        public string WorkloadValue { get; set; } // hrs requried to do work

        [ForeignKey("ProjectName")]

        public string ProjectName { get; set; }


    }
}
