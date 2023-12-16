namespace Restaurant.Society.Domain.Digital.Menu.Base;

public class BaseEntity
{
    /// <summary>Gets or sets the primary key.</summary>
    /// <value>The primary key identifier.</value>
    public Guid Id { get; set; }

    /// <summary>Gets or sets the creation date.</summary>
    /// <value>The creation date.</value>
    public DateTime CreationDate { get; set; }

    /// <summary>Gets or sets the first name.</summary>
    /// <value>The first name.</value>
    public bool IsDeleted { get; set; }

    /// <summary>Gets or sets the surname.</summary>
    /// <value>The surname.</value>
    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    /// <summary>Gets or sets the password.</summary>
    /// <value>The password.</value>
    public string Password { get; set; }

    /// <summary>Gets or sets the email.</summary>
    /// <value>The email.</value>
    public string Email { get; set; }
}
