using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);
var apiCorsPolicy = "corsPolicy";

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(builder => builder
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
