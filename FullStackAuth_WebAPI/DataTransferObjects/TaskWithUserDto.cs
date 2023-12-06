namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class TaskWithUserDto
    {

        public int Id { get; set; }
        public string Goal { get; set; }
        public  string GoalAssignedTo { get; set; }
        public UserForDisplayDto Poster { get; set; }
    }
}
