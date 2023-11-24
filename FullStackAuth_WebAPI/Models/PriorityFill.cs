using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class PriorityFill
    {
         

        [Key]
        public int Id { get; set; }

        [Required]
        public string DepartmentName { get; set; } // Department where prioritys are located


        [Required]
        public int WorkLoadValue { get; set; } // total work load to finish task

        [Required]
        public int TotalPriorityFill { get; set; } // total amount of items to pull

        [Required]
        public int PriorityRemaining { get; set; } // total amount remaining 
        [Required]
        public DateTime ProjectDate { get; set; }



        [ForeignKey("ProjectName")]
     
        public string ProjectName { get; set; }

    }
}
