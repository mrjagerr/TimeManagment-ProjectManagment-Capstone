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
        public ICollection<DailyProject> DailyProject { get; set; }


        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
