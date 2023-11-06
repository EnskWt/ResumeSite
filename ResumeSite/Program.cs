using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResumeSite.Contracts.RepositoriesContracts.PublicationRepositoryContracts;
using ResumeSite.Contracts.ServicesContracts.PublicationServiceContracts;
using ResumeSite.DatabaseContext;
using ResumeSite.Models.IdentityEntities;
using ResumeSite.Repositories;
using ResumeSite.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPublicationsRepository, PublicationsRepository>();

builder.Services.AddScoped<IPublicationsGetterService, PublicationsGetterService>();
builder.Services.AddScoped<IPublicationsAdderService, PublicationsAdderService>();
builder.Services.AddScoped<IPublicationsUpdaterService, PublicationsUpdaterService>();
builder.Services.AddScoped<IPublicationsDeleterService, PublicationsDeleterService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
    .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

    options.AddPolicy("NotAuthorized", policy => policy.RequireAssertion(context =>
    {
        return !context.User.Identity!.IsAuthenticated;
    }));

    options.AddPolicy("BlockAll", policy => policy.RequireAssertion(context => false));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/auth/login";
    options.AccessDeniedPath = "/auth/accessdenied";
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHsts();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
