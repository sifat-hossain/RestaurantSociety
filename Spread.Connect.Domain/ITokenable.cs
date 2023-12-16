namespace Spread.Connect.Domain;

public interface ITokenable
{
    public string UserId { get; }

    //public string FirstName { get; }

    //public string Surname { get; }

    public string Email { get; }

    public string UserName { get; }
}
