namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class PriorityFillDto
    {

        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public DateTime ProjectDate { get; set; }
        public int WorkLoadValue { get; set; }
        public int TotalPriorityFill { get; set; }
        public int PriorityRemaining { get; set; }
    }
}
