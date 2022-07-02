using Microsoft.EntityFrameworkCore;
using TelepathyLabs.ShowReels.Api.RequestHandlers;
using TelepathyLabs.ShowReels.DataAccess;
using TelepathyLabs.ShowReels.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<CreateShowReelHandler>();
builder.Services.AddTransient<GetShowReelsHandler>();
builder.Services.AddTransient<GetVideoDefinitionsHandler>();
builder.Services.AddTransient<GetVideoStandardsHandler>();
builder.Services.AddTransient<IShowReelRepository, ShowReelRepository>();

builder.Services.AddDbContext<TelepathyLabsDbContext>(options =>
    options.UseNpgsql("Host=localhost;Database=ShowReels;Username=evoting;Password=evotingadmin"));


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

