using asp.net_Proj.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Dodaj servise
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dodaj DbContext sa SQL Server konekcijom
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Konfiguriši Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirektuj root URL na Swagger
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();