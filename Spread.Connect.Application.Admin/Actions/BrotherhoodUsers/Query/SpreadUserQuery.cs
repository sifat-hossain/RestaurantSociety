namespace Spread.Connect.Application.Admin.Actions.BrotherhoodUsers.Query;

public class SpreadUserQuery : IRequest<List<SpreadUserModel>>
{
   
    public Guid SpreadUserId { get; set; }
    public string UserName { get; set; }
    public string? Name { get; set; }
    public string? FatherName { get; set; }
    public string? MotherName { get; set; }
    public string? Email { get; set; }
    public string? PrimaryPhone { get; set; }
    public string? AlternatePhone { get; set; }
    public string? NID { get; set; }
    public string? BloodGroup { get; set; }
    public string? Religion { get; set; }
    public string? ProfessionalStatus { get; set; }
    public string? MaritalStatus { get; set; }
    public string? DateOfBirth { get; set; }
    public string? PresentAddress { get; set; }
    public string? PermanentAddress { get; set; }
    public string? School { get; set; }
    public string? College { get; set; }
    public string? University { get; set; }
}
