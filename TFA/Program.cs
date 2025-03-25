using TFA.Domain.UseCases.GetForum;
using TFA.Extentions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.SqlConnectionConfig(builder.Configuration); 

builder.Services.AddScoped<IGetForumUseCase, GetForumUseCase>(); 

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers(); 

app.Run();
