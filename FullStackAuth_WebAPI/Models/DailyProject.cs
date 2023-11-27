using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FullStackAuth_WebAPI.Models
{
    public class DailyProject // single project that needs to be completed will be used to push info to the shift


    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public int TotalHoursForSingleProject { get; set; }
        [Required]
        public DateTime ProjectDate { get; set; }
        public ICollection<Zone> Zone { get; set; }
        public ICollection<PriorityFill> PriorityFill { get; set; }
        public ICollection<OutOfStocks> OutOfStocks { get; set;}



        [ForeignKey("Owner")]
        public string OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
