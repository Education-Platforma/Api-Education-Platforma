using Education.Application;
using Education.Domain.Entities.Auth;
using Education.Infrastructure;
using Education.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins",
        builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

builder.Services.AddEducationApplication();
builder.Services.AddEducationINfrastructure(builder.Configuration);

builder.Services.AddIdentity<UserModel, IdentityRole>()
               .AddEntityFrameworkStores<EducationDbContext>()
               .AddDefaultTokenProviders();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("_myAllowSpecificOrigins");

// Add CORS middleware before authentication and authorization
app.UseCors("_myAllowSpecificOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "User", "Teacher" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager =
        scope.ServiceProvider.GetRequiredService<UserManager<UserModel>>();

    string email = "admin@gmail.com";
    string password = "Sardor0618!";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new UserModel()
        {
            Id = "ab0cd123-e456-789f-abcd-ef0123456789",
            UserName = "Insoniyat",
            FullName = "Brat",
            Country = "Uzbekistan",
            Exp = 50000,
            Rank = 1,
            Email = email,
            EmailConfirmed = true
        };

        var res = await userManager.CreateAsync(user, password);

        var res1 = await userManager.AddToRoleAsync(user, "Admin");

    }
}

app.Run();
