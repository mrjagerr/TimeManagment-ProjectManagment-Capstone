using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class PriorityFill
    {
         

        [Key]
        public int Id { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public int WorkLoadValue { get; set; }

        [Required]
        public int TotalPriorityFill { get; set; }

        [Required]
        public int PriorityRemaining { get; set; }

      
    
}
}
