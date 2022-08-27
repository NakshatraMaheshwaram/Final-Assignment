using Microsoft.AspNetCore.Mvc;
using ShoppingMall.MVC.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IMallService, MallService>();
builder.Services.AddTransient<IUserRegistrationService, UserRegistrationService>();
builder.Services.AddTransient<IUserRoleService, UserRoleService>();
builder.Services.AddTransient<IUserLoginService, UserLoginService>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddCors(); // Make sure you call this previous to AddMvc
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.UseCors(
       options => options.WithOrigins("https://localhost:7217").AllowAnyMethod()
   );
app.UseMvc();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserLogins}/{action=UserLogin}/{id?}");

app.Run();
