using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FullStackAuth_WebAPI.Models
{
    public class DailyProject // single project that needs to be completed will be used to push info to the shift


    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public Zone Zone { get; set; }

        [Required]
        public PriorityFill PriorityFill { get; set; }
        
        [Required]
        public OutOfStocks OutOfStocks { get; set; }


    }
}
