using Microsoft.Extensions.Configuration;
using Spread.Connect.Application.Admin.Services;
using Spread.Connect.Domain.Framework.Contracts.Email;
using Spread.Connect.Domain.Framework.Interfaces;
using static BCrypt.Net.BCrypt;

namespace Spread.Connect.Application.Admin.Actions.BrotherhoodUsers.Commands
{
    /// <summary>
    /// Represents logic for SpreadUserHandler
    /// </summary>
    public class CreateSpreadUserHandler : IRequestHandler<CreateSpreadUserCommand, ActionResponse<SpreadUserModel>>
    {
        private readonly IAdminDbContext _adminDbContext;
        private readonly INotificationService _notificationService;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public CreateSpreadUserHandler(IAdminDbContext adminDbContext,
            INotificationService notificationService,
            IConfiguration configuration,
            ITokenService tokenService)
        {
            _adminDbContext = adminDbContext;
            _notificationService = notificationService;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        public async Task<ActionResponse<SpreadUserModel>> Handle(CreateSpreadUserCommand command, CancellationToken cancellationToken)
        {


            SpreadUser? existingUser = await _adminDbContext.SpreadUser
                .FirstOrDefaultAsync(x => x.Phone == command.Phone, cancellationToken: cancellationToken);

            if (existingUser != null)
            {
                throw new ConflictException(nameof(SpreadUser), command.Phone);
            }

            string tempPassword = "password";//_tokenService.GenerateTempPassword();
            try
            {
                string filePath = "~/Image/" + command.FormFile;

                using (FileStream stream = File.Create(filePath))
                {
                    await command.FormFile.CopyToAsync(stream, cancellationToken: cancellationToken);
                }
                var user = new SpreadUser
                {
                    UserName = command.UserName,
                    Password = HashPassword(tempPassword),
                    RequiresPasswordReset = true,
                    Name = command.Name,
                    FatherName = command.FatherName,
                    MotherName = command.MotherName,
                    Email = command.Email,
                    Phone = command.Phone,
                    AlternatePhone = command.AlternatePhone,
                    NID = command.NID.Trim(),
                    BloodGroup = command.BloodGroup.ToLower(),
                    Religion = command.Religion,
                    PresentAddress = command.PresentAddress,
                    PermanentAddress = command.PermanentAddress,
                    School = command.School,
                    College = command.College,
                    University = command.University,
                    DateOfBirth = command.DateOfBirth,
                    ProfessionalStatus = command.ProfessionalStatus,
                    MaritalStatus = command.MaritalStatus,
                    ImagePath = filePath
                };

                ApplicationSetting? defRoleId = await _adminDbContext.ApplicationSettings
                    .FirstOrDefaultAsync(x => x.ParamName == "DefaultRole", cancellationToken: cancellationToken);

                List<Guid> Roles = Validate(command.Roles, Guid.Parse(defRoleId.Value1));

                List<Guid> roles = await _adminDbContext.Role
                  .Where(r => Roles.Contains(r.RoleId))
                  .Select(r => r.RoleId)
                  .ToListAsync();

                user.SpreadUserRoles.AddRange(roles.Select(role => new SpreadUserRole
                {
                    RoleId = role
                }));

                await _adminDbContext.SpreadUser.AddAsync(user, cancellationToken);
                await _adminDbContext.SaveChangesAsync(cancellationToken);

                //Send Email
                EmailHelper emailHelper = new EmailHelper
                {
                    Email = "isrukhasan@gmail.com",
                    Subject = "Registration completed",
                    CcEmail = "sifat1258@gmail.com",
                    BccEmail = "sifat1258@gmail.com",
                    Content = $"Congratulations! " +
                            $"You have complete your registration. " +
                            $"Here is Temporary password:{user.Password}. Please Login with this password and change the password for your account security."
                };
                await _notificationService.SendEmail(emailHelper);


                //Send SMS

                //Keep count
                return new ActionResponse<SpreadUserModel>
                {
                    IsSuccessful = true,
                    Model = SpreadUserModel.Create(user)
                };
            }
            catch (Exception e)
            {
                var message = e.Message + e.InnerException?.Message;

                return new ActionResponse<SpreadUserModel>
                {
                    IsSuccessful = true,
                    Message = message
                };
            }
        }

        /// <summary>
        /// Validate roles
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="DefaultRole"></param>
        /// <returns></returns>
        public static List<Guid> Validate(List<Guid> roles, Guid DefaultRole)
        {
            if (roles == null || roles.Count == 0)
            {
                return new List<Guid>() { DefaultRole };
            }
            return roles;
        }
    }
}
