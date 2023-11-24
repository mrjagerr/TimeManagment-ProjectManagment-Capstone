using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class Shift
    {

        [Key]
        public int Id { get; set; }
        public string UserName {  get; set; }
        public int ShiftDuration { get; set; }


        [ForeignKey("Owner")]
        public string OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
