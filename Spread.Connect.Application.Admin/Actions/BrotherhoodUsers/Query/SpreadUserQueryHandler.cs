namespace Spread.Connect.Application.Admin.Actions.BrotherhoodUsers.Query;

public class BrotherhoodUserQueryHandler : IRequestHandler<SpreadUserQuery, List<SpreadUserModel>>
{
    private readonly IAdminDbContext _adminDbContext;
    public BrotherhoodUserQueryHandler(IAdminDbContext adminDbContext)
    {
        _adminDbContext = adminDbContext;
    }
    public async Task<List<SpreadUserModel>> Handle(SpreadUserQuery request, CancellationToken cancellationToken)
    {
        List<SpreadUser> brotherhoodUser = await _adminDbContext.SpreadUser.ToListAsync(cancellationToken);
        if (brotherhoodUser != null)
        {
            List<SpreadUserModel> brotherhoodUserModels = brotherhoodUser.Select(u => SpreadUserModel.Create(u)).ToList();

            return brotherhoodUserModels;
        }
        else
        {
            return new List<SpreadUserModel>();
        }
    }
}
