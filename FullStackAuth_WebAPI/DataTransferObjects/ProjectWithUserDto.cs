namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ProjectWithUserDto
    {
      
        
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime ProjectDate { get; set; }
        public int WorkLoadAllocation { get; set; }
        public int TotalWorkloadRequired { get; set; }
        public UserForDisplayDto Owner { get; set; }
        }
    
}
