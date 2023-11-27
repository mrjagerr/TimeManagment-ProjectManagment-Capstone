using FullStackAuth_WebAPI.DataTransferObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class OutOfStocks // out of stock for that area
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DepartmentName { get; set; } // Department where Oos are located


        [Required]
        public int WorkLoadValue { get; set; } // total work load to finish task

        [Required]
        public int TotalOosFill { get; set; } // total amount of items to pull

        [Required]
        public int OosRemaining { get; set; } // total amount of Oos remaining 
        [Required]
        public DateTime ProjectDate { get; set; }

    
     
    }
}
