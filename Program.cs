using CrixusJa.Data;
using CrixusJa.iRepository;
using CrixusJa.Respoitory;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<DataContext>(opts => opts.UseSqlServer(Configuration["workstation id = crixusdb.mssql.somee.com; packet size = 4096; user id = mkgenius_SQLLogin_1; pwd = ytlfpaikap; data source = crixusdb.mssql.somee.com; persist security info=False; initial catalog = crixusdb"]));

builder.Services.AddDbContext<Datacontext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

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
