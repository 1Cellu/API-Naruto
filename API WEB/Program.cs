using Microsoft.EntityFrameworkCore;
using API_WEB.DAO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var GetConfiguration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var Connection = GetConfiguration.GetConnectionString("DefaultConnection");


builder.Services.AddControllers(); //Rota dos controlllers
builder.Services.AddDbContext<NinjaContext>(opt => opt.UseMySql(Connection, ServerVersion.AutoDetect(Connection))); //Possivelmente equivalente aos DAO

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
