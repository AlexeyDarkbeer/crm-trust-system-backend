using CRM.Trust.Application.Extensions;
using CRM.Trust.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddCoreContext(configuration);
builder.Services.AddScoringContext(configuration);
builder.Services.AddMathCoreHttpClient(configuration);

builder.Services.AddApplicationMappings();
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCors", policyBuilder => 
        policyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowCors");

app.UseAuthorization();
app.MapControllers();

app.Run();
