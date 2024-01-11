using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Setting Database Sql Server
var connectionString = builder.Configuration.GetConnectionString("SignInSystem") ??
    throw new InvalidOperationException("Connection string 'SignInSystem' not found.");

builder.Services.AddDbContext<SignInSystemContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCors");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
