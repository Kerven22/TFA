using System.Reflection;
using TFA.Domain.Authentication;
using TFA.Domain.DependencyInjection;
using TFA.Storage.DependencyInjection; 

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddStorageServices(builder.Configuration.GetConnectionString("sqlconnection")!);
builder.Services.AddDomainServices();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.Configure<AuthenticationConfiguration>(
    builder.Configuration.GetSection("AuthenticationConfiguration").Bind);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
