namespace Spread.Connect.Application.Admin.Actions.Users;

public class DriverModel
{
    #region Properties
    /// <summary>Gets or sets the driver identifier.</summary>
    /// <value>The driver identifier.</value>
    public Guid DriverId { get; set; }
    /// <summary>Gets or sets the first name.</summary>
    /// <value>The first name.</value>
    public string FirstName { get; set; }
    /// <summary>Gets or sets the surname.</summary>
    /// <value>The surname.</value>
    public string Surname { get; set; }
    /// <summary>Gets or sets the email.</summary>
    /// <value>The email.</value>
    public string Email { get; set; }
    /// <summary>Gets or sets the hauler identifier.</summary>
    /// <value>The hauler identifier.</value>
    public Guid? HaulerId { get; set; }
    #endregion

    public static Expression<Func<SpreadUser, DriverModel>> Projection
    {
        get
        {
            return entity => new DriverModel
            {
                DriverId = entity.SpreadUserId,
                Email = entity.Email
                //FirstName = entity.FirstName,
                //Surname = entity.Surname
            };
        }
    }

    /// <summary>Creates the specified model.</summary>
    /// <param name="entity">The source entity.</param>
    /// <returns>
    /// The driver model of the driver entity
    /// </returns>
    public static DriverModel Create(SpreadUser entity)
    {
        return Projection.Compile().Invoke(entity);
    }
}
