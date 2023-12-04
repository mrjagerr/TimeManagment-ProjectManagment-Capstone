using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class TaskList
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Goal { get; set; }
        [Required]
        public string GoalAssignedTo { get; set; }  

        [ForeignKey("Owner")]
        public string OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
