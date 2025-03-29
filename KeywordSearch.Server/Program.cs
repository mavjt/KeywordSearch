using KeywordSearch.Core.Interfaces;
using KeywordSearch.Infrastructure.Interfaces;
using KeywordSearch.Web.Config;
using Serilog;
using Serilog.Debugging;
using Serilog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServiceConfigs( builder);


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();


if (app.Environment.IsDevelopment())
{
    app.UseSerilogRequestLogging();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
