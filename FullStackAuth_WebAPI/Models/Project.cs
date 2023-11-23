using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class Project
    {

        [Key]
        public int Id { get; set; }
      
        [Required]
        public int WorkLoadAllocation { get; set; }

        [Required]
        public int TotalWorkloadRequired { get; set; }

        [ForeignKey("Owner")]
        public string OwnerId { get; set; }

        public User Owner { get; set; }

    }


}
