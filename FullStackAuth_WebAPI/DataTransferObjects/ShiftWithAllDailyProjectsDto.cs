using FullStackAuth_WebAPI.Models;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ShiftWithAllDailyProjectsDto
    {
        public int Id { get; set; }
        public string TeamMemberFirstName { get; set; }
        public int ShiftDuration { get; set; }
        public ICollection<DailyProjectWithZoneOOSPrioDto> DailyProject { get; set; }
    }
}
