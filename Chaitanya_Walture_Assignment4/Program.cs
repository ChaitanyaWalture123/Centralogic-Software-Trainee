using Chaitanya_Walture_Assignment4.Interfaces;
using Chaitanya_Walture_Assignment4.Services;
using Chaitanya_Walture_Assignment4.CosmosDB;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IVisitorService, VisitorService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<IOfficeService,OfficeService >();
builder.Services.AddScoped<ICosmosDBService, CosmosDBService>();

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
