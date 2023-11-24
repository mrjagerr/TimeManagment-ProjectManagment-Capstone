using FullStackAuth_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class DailyProjectWithZoneOOSPrio
    {

        [Key]
        public int Id { get; set; }
  
        public string ProjectName { get; set; }
  
        public Zone Zone { get; set; }

      
        public PriorityFill PriorityFill { get; set; }

  
        public OutOfStocks OutOfStocks { get; set; }

        public UserForDisplayDto TeamMember { get; set; }
        public DateTime ProjectDate { get; set; }

    }
}
