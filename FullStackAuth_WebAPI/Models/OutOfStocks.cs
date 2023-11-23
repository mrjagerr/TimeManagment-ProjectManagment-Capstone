using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class OutOfStocks
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DepartmentName { get; set; } // Department where Oos are located


        [Required]
        public int WorkLoadValue { get; set; } // total work load to finish task

        [Required]
        public int TotalOoaFill { get; set; } // total amount of items to pull

        [Required]
        public int OosRemaining { get; set; } // total amount of Oos remaining 
    }
}
