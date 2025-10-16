using TFA.Domain.DependencyInjection;
using TFA.Storage.DependencyInjection; 

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddStorageServices(builder.Configuration.GetConnectionString("sqlconnection")!);
builder.Services.AddDomainServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
