using BookingTicketCinema1._0.Repository;
using BookingTicketCinema1._0.Services.MovieInfoService;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
var _connection = Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
 static IConfiguration ConfigureAppConfiguration(WebApplicationBuilder builder)
{
    var configuration = builder.Configuration;
    configuration.AddJsonFile("appsettings.json");
    return configuration;
}
static void ConfigureServices(WebApplicationBuilder builder, IConfiguration configuration)
{
    var services = builder.Services;
    services.AddHttpClient<MovieService>();
    services.AddScoped<MovieRepository>();
    services.AddScoped<IDbConnection>(db => new MySqlConnection(configuration.GetConnectionString("DefaultConnection")));
}


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConfiguration>(Configuration);



var configuration = ConfigureAppConfiguration(builder);
ConfigureServices(builder, configuration);
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
