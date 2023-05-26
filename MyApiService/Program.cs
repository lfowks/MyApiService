using DataAccess;
using MyApiService;
using Services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

// Add External Dependencies
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

//Seeder Service
builder.Services.AddScoped<DataSeeder>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

//Seeding Data for Testing
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider.GetRequiredService<DataSeeder>;
    services.Invoke().Seed();
}

app.MapControllers();

app.Run();
