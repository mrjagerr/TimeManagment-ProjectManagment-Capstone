using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class Shift
    {

        [Key]
        public int Id { get; set; }
        public string TeamMemberFirstName {  get; set; }
        public int ShiftDuration { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public string ShiftDate { get; set; }
        [Required]
        public int WorkLoadValue { get; set; }
        [Required]
        public int PriorityFill { get; set; }
        [Required] 
        public int OutOfStock { get; set; }
        [Required]
        public string Zone { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
