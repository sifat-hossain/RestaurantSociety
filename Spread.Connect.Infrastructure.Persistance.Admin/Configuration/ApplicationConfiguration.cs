namespace Spread.Connect.Infrastructure.Persistance.Admin.Configuration;

public class ApplicationConfiguration : IEntityTypeConfiguration<ApplicationSetting>
{
    public void Configure(EntityTypeBuilder<ApplicationSetting> builder)
    {
        builder.HasKey(x => x.ApplicationSettingId);

        builder.HasData(new[]
        {
            new ApplicationSetting{ApplicationSettingId=1,ParamName="DefaultRole",Value1="0da3649e-e5ec-4c5b-a9c0-ec3b19f86e0c",Scope="Default user role"}
        });
    }
}
