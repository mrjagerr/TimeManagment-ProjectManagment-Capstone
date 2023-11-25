namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class OutOfStockDto
    {


        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public DateTime ProjectDate { get; set; }
        public int WorkLoadValue { get; set; }
        public int TotalOosFill { get; set; }
        public int TotalOosRemaining {  get; set; }
        
    }

}
