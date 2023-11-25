using FullStackAuth_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class DailyProjectWithZoneOOSPrio
    {

        [Key]
        public int Id { get; set; }
        public DateTime ProjectDate { get; set; }
        public string ProjectName { get; set; }
        public OutOfStockDto OutOfStock { get; set; }
        public PriorityFillDto PriorityFill { get; set; }
        public ZoneDto Zone { get; set; }

        public UserForDisplayDto TeamMember { get; set; }
       

    }
}
