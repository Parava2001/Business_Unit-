using businessUnit.component.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<EF_DataContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("EF_Postgres_Db"))); // connection btw the DB and EF core 


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder =>
    builder.WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // middleware  ... Use , Map , Run , Next are methods used in middlewares

app.UseAuthorization();// middleware .. Use method is used to use the middleware 

app.MapControllers();// middleware

app.Run(); // this Run() method is very imp and runs the whole program.cs file and if anything is wriiten after this run method
              // then it will not execute . so it is placed at the end to run whole program


