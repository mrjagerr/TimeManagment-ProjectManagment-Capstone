namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ShiftWithTeamMemberDto
    {
        
        
             public int Id { get; set; }
             public int ShiftDuration {get; set; }
            
             public UserForDisplayDto TeamMember {  get; set; }
             public UserForDisplayDto TeamLead { get; set; }
        
    }
}
