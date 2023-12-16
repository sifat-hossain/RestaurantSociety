namespace Spread.Connect.Application.Admin.Actions.Roles.Commands.CreateRole;

/// <summary>
/// Represents logic for CreateRoleCommand
/// </summary>
public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, RoleModel>
{
    private readonly IAdminDbContext _adminDbContext;

    public CreateRoleHandler(IAdminDbContext adminDbContext)
    {
        _adminDbContext = adminDbContext;
    }

    public async Task<RoleModel> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        Role dbRole = await _adminDbContext.Role
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Name == request.Name);

        if (dbRole != null)
        {
            throw new ConflictException(nameof(Role), request.Name);
        }

        var role = new Role
        {
            Name = request.Name
        };

        _adminDbContext.Role.Add(role);

        await _adminDbContext.SaveChangesAsync(cancellationToken);

        return RoleModel.Create(role);
    }
}
