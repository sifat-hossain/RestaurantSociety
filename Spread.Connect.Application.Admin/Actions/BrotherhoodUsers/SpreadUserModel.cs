namespace Spread.Connect.Application.Admin.Actions.BrotherhoodUsers;

public class SpreadUserModel
{
    /// <summary>Gets or sets the Spread user identifier.</summary>
    /// <value>The Spread user identifier.</value>
    public Guid SpreadUserId { get; set; }

    /// <summary>Gets or sets the name of the user.</summary>
    /// <value>The name of the user.</value>
    public string UserName { get; set; }

    /// <summary>Gets or sets the password.</summary>
    /// <value>The password.</value>
    public string Password { get; set; }

    /// <summary>Gets or sets the full name of the user.</summary>
    public string? Name { get; set; }

    /// <summary>Gets or sets the father's name of the user.</summary>
    public string? FatherName { get; set; }

    /// <summary>Gets or sets the mother's name of the user.</summary>
    public string? MotherName { get; set; }

    /// <summary>Gets or sets the email address of the user.</summary>
    public string? Email { get; set; }

    /// <summary>Gets or sets the phone number of the user.</summary>
    public string Phone { get; set; }

    /// <summary>Gets or sets the alternate phone number of the user.</summary>
    public string? AlternatePhone { get; set; }

    /// <summary>Gets or sets the national ID card number of the user.</summary>
    public string? NID { get; set; }

    /// <summary>Gets or sets the blood group of the user.</summary>
    public string? BloodGroup { get; set; }

    /// <summary>Gets or sets the religion of the user.</summary>
    public string? Religion { get; set; }

    /// <summary>Gets or sets the professional status of the user.</summary>
    public string? ProfessionalStatus { get; set; }

    /// <summary>Gets or sets the marital status of the user.</summary>
    public string? MaritalStatus { get; set; }

    /// <summary>Gets or sets the date of birth of the user.</summary>
    public string? DateOfBirth { get; set; }

    /// <summary>Gets or sets the present address of the user.</summary>
    public string? PresentAddress { get; set; }

    /// <summary>Gets or sets the permanent address of the user.</summary>
    public string? PermanentAddress { get; set; }

    /// <summary>Gets or sets the name of the school of the user.</summary>
    public string? School { get; set; }

    /// <summary>Gets or sets the name of the college of the user.</summary>
    public string? College { get; set; }

    /// <summary>Gets or sets the name of the university of the user.</summary>
    public string? University { get; set; }

    /// <summary> User's roles </summary>
    public List<string> Roles { get; set; } = new List<string>();

    public string? ImagePath { get; set; }

    public static Expression<Func<SpreadUser, SpreadUserModel>> Projection
    {
        get
        {
            return user => new SpreadUserModel
            {
                UserName = user.UserName,
                Name = user.Name,
                FatherName = user.FatherName,
                MotherName = user.MotherName,
                Email = user.Email,
                Phone = user.Phone,
                AlternatePhone = user.AlternatePhone,
                NID = user.NID,
                BloodGroup = user.BloodGroup,
                Religion = user.Religion,
                PresentAddress = user.PresentAddress,
                PermanentAddress = user.PermanentAddress,
                School = user.School,
                College = user.College,
                University = user.University,
                DateOfBirth = user.DateOfBirth,
                ProfessionalStatus = user.ProfessionalStatus,
                MaritalStatus = user.MaritalStatus,
                Roles = user.SpreadUserRoles.Where(ur => ur.Role != null).Select(ur => ur.Role.Name).ToList(),
                ImagePath= user.ImagePath,
            };
        }
    }

    public static SpreadUserModel Create(SpreadUser entity)
    {
        return Projection.Compile().Invoke(entity);
    }
}
