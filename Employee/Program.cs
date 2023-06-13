using Employee.DB;
using Employee.Models.imlementation;
using Employee.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services.AddMvc(Options => Options.EnableEndpointRouting = false);
builder.Services.AddScoped<IEmployeeRepositry, SqlEmployeeRepositry>();
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeesDb")));
#endregion

var app = builder.Build();
//DefaultFilesOptions a=new DefaultFilesOptions();
//a.DefaultFileNames.Clear();
//a.DefaultFileNames.Add("ASP.net.jpg");

#region Midlware
FileServerOptions a = new FileServerOptions();
a.DefaultFilesOptions.DefaultFileNames.Clear();
a.DefaultFilesOptions.DefaultFileNames.Add("ASP.net.jpg");
app.UseFileServer(a);

app.UseMvcWithDefaultRoute();
/*app.UseMvc(routes => routes.MapRoute(
name: "Defualt",
template: "{controller}/{action}"
        )); ;*/


//app.MapGet("/", () => "Hello World!");
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Please Enter a correct URL");
}
);
#endregion
app.Run();
