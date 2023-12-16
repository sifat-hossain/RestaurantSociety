using Microsoft.AspNetCore.Http;

namespace Spread.Connect.Application.Admin.Actions.BrotherhoodUsers.Commands;

public class CreateSpreadUserCommand : IRequest<ActionResponse<SpreadUserModel>>
{
    /// <summary>
    /// The username of the user.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// The user's full name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The name of the user's father.
    /// </summary>
    public string? FatherName { get; set; }

    /// <summary>
    /// The name of the user's mother.
    /// </summary>
    public string? MotherName { get; set; }

    /// <summary>
    /// The user's email address.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// The user's phone number.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// An alternate phone number for the user.
    /// </summary>
    public string? AlternatePhone { get; set; }

    /// <summary>
    /// The user's national identification number.
    /// </summary>
    public string? NID { get; set; }

    /// <summary>
    /// The user's blood group.
    /// </summary>
    public string? BloodGroup { get; set; }

    /// <summary>
    /// The user's religion.
    /// </summary>
    public string? Religion { get; set; }

    /// <summary>
    /// The user's professional status or job title.
    /// </summary>
    public string? ProfessionalStatus { get; set; }

    /// <summary>
    /// The user's marital status.
    /// </summary>
    public string? MaritalStatus { get; set; }

    /// <summary>
    /// The user's date of birth.
    /// </summary>
    public string? DateOfBirth { get; set; }

    /// <summary>
    /// The user's present address.
    /// </summary>
    public string? PresentAddress { get; set; }

    /// <summary>
    /// The user's permanent address.
    /// </summary>
    public string? PermanentAddress { get; set; }

    /// <summary>
    /// The user's school of education.
    /// </summary>
    public string? School { get; set; }

    /// <summary>
    /// The user's college or university of education.
    /// </summary>
    public string? College { get; set; }

    /// <summary>
    /// The user's university of education.
    /// </summary>
    public string? University { get; set; }

    /// <summary>
    /// A list of roles that the user has in an application.
    /// This is represented as a list of Guids.
    /// </summary>

    public List<Guid>? Roles { get; set; } = new List<Guid>();

    public IFormFile? FormFile { get; set; }

}
