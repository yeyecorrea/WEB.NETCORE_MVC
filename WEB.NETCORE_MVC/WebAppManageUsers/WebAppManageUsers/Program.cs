using Microsoft.EntityFrameworkCore;
using WebAppManageUsers.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Añadimos el DataContex al servicios del contenedor
builder.Services.AddDbContext<DataContext>(o =>
{
    // Indicamos que el DbContex usara Sql y pasamos el nombre de la cadena de conexion
    // que se creo en el archivo appsettings.json
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetion"));
});

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
