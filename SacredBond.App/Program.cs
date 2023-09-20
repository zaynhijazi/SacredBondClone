using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using SacredBond.Core.Contexts;
using SacredBond.Core.Domain;
using SacredBond.Core.Email;
using SacredBond.Core.Financial;
using SacredBond.Core.ProfilePictureStorage;
using SacredBond.Core.Repositories;
using SacredBond.Core.Services;
using System.Security.Policy;
using System.Security.Principal;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IPrincipal>(options => options.GetService<IHttpContextAccessor>().HttpContext.User);

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IFinancialService, FinancialService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IProfileMatchesService, ProfileMatchesService>();

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<IProfileLanguageRepository, ProfileLanguageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdminProfileRepository, AdminProfileRepository>();
builder.Services.AddScoped<IProfileMatchesRepository, ProfileMatchesRepository>();
builder.Services.AddScoped<IProfileStatusChangeRepository, ProfileStatusChangeRepository>();    
builder.Services.AddScoped<IProfileMatchStatusChangeRepository, ProfileMatchStatusChangeRepository>();
builder.Services.AddScoped<IProfilePicturesRepository, ProfilePicturesRepository>();
// Register AzureBlobStorageService as a scoped service, which is often used for services with dependencies like IConfiguration.
builder.Services.AddScoped<IAzureBlobStorageService, AzureBlobStorageService>();


builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(context => {

        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        if (exceptionHandlerPathFeature?.Error is UnauthorizedAccessException)
        {
            context.Response.Redirect("/Identity/Account/Login"); ;
        }
        else
        {
            context.Response.Redirect("/Home/Error"); ;
        }

        return Task.CompletedTask;
    });
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
