using FullStackAuth_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class DailyProjectWithZoneOOSPrioDto
    {

        [Key]
        public int Id { get; set; }
        public DateTime ProjectDate { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<OutOfStockDto> outOfStocks { get; set; }
        public ICollection<PriorityFillDto> PriorityFill { get; set; }
        public ICollection<ZoneDto> Zones { get; set; }

        public ICollection<UserForDisplayDto>  TeamMember { get; set; }
       

    }
}
