using Microsoft.EntityFrameworkCore;
using TelepathyLabs.ShowReels.Api.RequestHandlers;
using TelepathyLabs.ShowReels.DataAccess;
using TelepathyLabs.ShowReels.Domain;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<CreateShowReelHandler>();
builder.Services.AddTransient<GetShowReelsHandler>();
builder.Services.AddTransient<GetVideoDefinitionsHandler>();
builder.Services.AddTransient<GetVideoStandardsHandler>();
builder.Services.AddTransient<IShowReelRepository, ShowReelRepository>();


var connectionString = Environment.GetEnvironmentVariable("ShowReelsConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    connectionString = builder.Configuration.GetConnectionString("ShowReelsConnection");
}

builder.Services.AddDbContext<TelepathyLabsDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(a => a.WithOrigins("http://localhost:4200", "http://localhost:5002").AllowAnyMethod().AllowAnyHeader()) ;

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

