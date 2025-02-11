using Avtobus1.BLL;
using Avtobus1.DAL;
using Avtobus1.DAL.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.RegisterDAL(builder.Configuration);
builder.Services.RegisterBLL(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<Avtobus1DbContext>();
    context.Database.Migrate(); 
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ShortUrl}/{action=Index}/{id?}");

app.Run();
