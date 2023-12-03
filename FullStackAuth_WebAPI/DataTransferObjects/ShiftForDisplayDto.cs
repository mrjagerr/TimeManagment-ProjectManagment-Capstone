using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ShiftForDisplayDto
    {
        public int Id { get; set; }
        public string TeamMemberFirstName { get; set; }
        public int ShiftDuration { get; set; }
        public string DepartmentName { get; set; }
        public string ShiftDate { get; set; }
        public int WorkLoadValue { get; set; }
        public int PriorityFill { get; set; }
        public int OutOfStock { get; set; }
        public string Zone { get; set; }
    }
}
