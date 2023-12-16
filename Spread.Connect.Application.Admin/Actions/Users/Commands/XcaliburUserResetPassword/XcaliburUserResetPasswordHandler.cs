using Microsoft.Extensions.Configuration;
using Spread.Connect.Application.Admin.Services;
using Spread.Connect.Domain.Framework.Interfaces;
using static BCrypt.Net.BCrypt;


namespace Spread.Connect.Application.Admin.Actions.Users.Commands.SpreadUserResetPassword;

public class SpreadUserResetPasswordHandler : IRequestHandler<SpreadUserResetPasswordCommand>
{
    /// <summary>The admin datbase context</summary>
    private readonly IAdminDbContext _adminDbContext;

    /// <summary>The token service</summary>
    private readonly ITokenService _tokenService;


    /// <summary>The configuration</summary>
    private readonly IConfiguration _configuration;

    /// <summary>The notification service </summary>
    private readonly INotificationService? _notificationService;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpreadUserResetPasswordHandler" /> class.
    /// </summary>
    /// <param name="adminDbContext">The admin database context.</param>
    /// <param name="tokenService">The token service.</param>
    /// <param name="configuration">The configuration.</param>
    public SpreadUserResetPasswordHandler(IAdminDbContext adminDbContext,
        ITokenService tokenService,
        IConfiguration configuration, INotificationService notificationService)
    {
        _adminDbContext = adminDbContext;
        _tokenService = tokenService;
        _configuration = configuration;
        _notificationService = notificationService;
    }

    public async Task<Unit> Handle(SpreadUserResetPasswordCommand command,
        CancellationToken cancellationToken)
    {
        string tempPassword = string.Empty;
        var user = await _adminDbContext.SpreadUser
              .SingleOrDefaultAsync(u => u.Email == command.Email,
                cancellationToken: cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(nameof(SpreadUser), command.Email);
        }

        bool shouldGeneratePassword = Convert.ToBoolean(_configuration["ShouldGeneratePassword"]);

        tempPassword = shouldGeneratePassword ? _tokenService.GenerateTempPassword()
            : _configuration["DefaultPassword"];

        user.Password = HashPassword(tempPassword);
        user.RequiresPasswordReset = true;

        // await _adminDbContext.SaveChangesAsync(cancellationToken);

        //await _notificationService.SendResetPasswordEmailAsync(new SendResetPasswordEmailRequest()
        //{
        //    Email = command.Email,
        //    TempPassword = tempPassword
        //});

        return Unit.Value;
    }
}
