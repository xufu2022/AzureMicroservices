
using Microsoft.OpenApi.Models;
using OpenTelemetry.Resources;
using PetMedicine.Hospital.Api.ApplicationServices;
using PetMedicine.Hospital.Api.Infrastructure;
using PetMedicine.Hospital.Api.IntegrationEvents;
using PetMedicine.Hospital.Domain.Repositories;
using PetMedicine.Hospital.Infrastructure;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
const string ServiceName = "PetMedicine.Hospital.Api";
// Add services to the container.
//builder.Services.AddOpenTelemetryTracing(config =>
//{
//    config.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(ServiceName));
//    string appinsightsCs = builder.Configuration["AppInsights:ConnectionString"];

//    if (!string.IsNullOrWhiteSpace(appinsightsCs))
//    {
//        config.AddAzureMonitorTraceExporter(c =>
//        {
//            c.ConnectionString = appinsightsCs;
//        });
//    }

//    config.AddJaegerExporter(o =>
//        {
//            o.AgentHost = builder.Configuration.GetValue<string>("Jaeger:Host");
//            o.AgentPort = builder.Configuration.GetValue<int>("Jaeger:Port");
//        }).AddSource("hospital-api")
//        .AddAspNetCoreInstrumentation()
//        .AddHttpClientInstrumentation()
//        .AddSqlClientInstrumentation(s => s.SetDbStatementForText = true);
//});
builder.Services.AddHealthChecks()
    .AddCosmosDbCheck(builder.Configuration)
    .AddDbContextCheck<HospitalDbContext>();
builder.Services.AddHospitalDb(builder.Configuration);
builder.Services.AddHospitalDb(builder.Configuration);
builder.Services.AddSingleton<IPatientAggregateStore, PatientAggregateStore>();
builder.Services.AddScoped<HospitalApplicationService>();

builder.Services.AddControllers();
builder.Services.AddHostedService<PetTransferredToHospitalIntegrationEventHandler>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PetMedicine.Hospital.Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.EnsureHospitalDbIsCreated();
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
