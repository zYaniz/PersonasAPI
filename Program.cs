// Yani Joel Solano Flores
// Harold Steven Monge Cascante
// Melvin Fernando Mora Delgado 
// Asignacion #3 API personas




#region 
using Microsoft.EntityFrameworkCore;
using PersonasAPI.Contexto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContextoBD>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion