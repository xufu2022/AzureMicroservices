using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetMedicine.Hospital.Domain.Repositories;
using PetMedicine.Hospital.Domain.ValueObjects;
using PetMedicine.Hospital.Infrastructure;

namespace PetMedicine.Hospital.Projector
{
    public class PatientsProjector
    {
        private readonly ILogger _logger;
        public ILoggerFactory _loggerFactory;
        public IConfiguration _configuration;
        public IPatientAggregateStore _patientAggregateStore;

        public PatientsProjector(ILoggerFactory loggerFactory, IConfiguration configuration, IPatientAggregateStore patientAggregateStore)
        {
            _logger = loggerFactory.CreateLogger<PatientsProjector>();
            _loggerFactory = loggerFactory;
            _configuration = configuration;
            _patientAggregateStore = patientAggregateStore;
        }

        [Function(nameof(PatientsProjector))]
        public async Task Run([CosmosDBTrigger(
            databaseName: "PetMedicine",
            collectionName: "Patients",
            ConnectionStringSetting = "CosmosDbConnectionString",
            CreateLeaseCollectionIfNotExists = true,
            LeaseCollectionName = "leases")] IReadOnlyList<CosmosEventData> input)
        {
            if (input == null || !input.Any())
            {
                return;
            }

            _logger.LogInformation("Items received: " + input.Count);

            using var conn = new SqlConnection(_configuration.GetConnectionString("Hospital"));
            conn.EnsurePatientsTable();

            foreach (var item in input)
            {
                var patientId = Guid.Parse(item.AggregateId.Replace("Patient-", string.Empty));
                var patient = await _patientAggregateStore.LoadAsync(PatientId.Create(patientId));

                conn.InsertPatient(patient);
                _logger.LogInformation(item.Data);
            }

            conn.Close();
        }
    }
}
