using Microsoft.EntityFrameworkCore;
using API_WEB.DAO;

    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); //Rota dos controlllers
builder.Services.AddDbContext<NinjaContext>(opt => opt.UseInMemoryDatabase("APINinja")); //Possivelmente equivalente aos DAO

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
