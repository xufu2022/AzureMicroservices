using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using PetMedicine.Rescue.Api.ApplicationServices;
using PetMedicine.Rescue.Api.Infrastructure;
using PetMedicine.Rescue.Api.IntegrationEvents;
using PetMedicine.Rescue.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRescueDb(builder.Configuration);
builder.Services.AddScoped<AdopterApplicationService>();
builder.Services.AddScoped<IRescueRepository, RescueRepository>();
builder.Services.AddHostedService<PetFlaggedForAdoptionIntegrationEventHandler>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PetMedicine.Rescue.Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.EnsureRescueDbIsCreated();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
