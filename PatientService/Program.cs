using Microsoft.EntityFrameworkCore;
using PatientService.Data; // Replace with your actual namespace for AppDbContext
using PatientService.Services; // Replace with your actual namespace for PatientService & IPatientService

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPatientService, PatientService.Services.PatientService>();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  // Add if using HTTPS
app.UseAuthorization();
app.MapControllers();

app.Run();
