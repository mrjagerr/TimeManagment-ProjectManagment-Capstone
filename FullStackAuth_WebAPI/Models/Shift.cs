using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class Shift
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ShiftDuration { get; set; }

        public string Username { get; set; }
        // Team member username
       
        


        [ForeignKey("Owner")] //admin id
        public string OwnerId { get; set; }
        public User Owner { get; set; }
     
       
    }
}
