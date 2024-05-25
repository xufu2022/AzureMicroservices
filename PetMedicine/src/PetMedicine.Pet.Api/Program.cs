using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using PetMedicine.Pet.Api.ApplicationServices;
using PetMedicine.Pet.Api.Infrastructure;
using PetMedicine.Pet.Domain.Repositories;
using PetMedicine.Pet.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Application name constant

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PetMedicine.Pet.Api", Version = "v1" });
});
builder.Services.AddHealthChecks()
    .AddDbContextCheck<PetDbContext>();
builder.Services.AddPetDb(builder.Configuration);
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<PetApplicationService>();
builder.Services.AddScoped<IBreedService, FakeBreedService>();
builder.Services.AddOpenTelemetry().WithTracing(b =>
{
    b.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(builder.Environment.ApplicationName))
        .AddHttpClientInstrumentation();
});

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WisdomPetMedicine.Api v1"));
    app.UseDeveloperExceptionPage();
}
app.EnsurePetDbIsCreated();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapHealthChecks("health");
app.MapControllers();

app.Run();
