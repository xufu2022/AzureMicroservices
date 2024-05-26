using PetMedicine.Hospital.Api.Commands;
using PetMedicine.Hospital.Domain.Entities;
using PetMedicine.Hospital.Domain.Repositories;
using PetMedicine.Hospital.Domain.ValueObjects;

namespace PetMedicine.Hospital.Api.ApplicationServices
{
    public class HospitalApplicationService
    {
        private readonly IPatientAggregateStore _patientAggregateStore;

        public HospitalApplicationService(IPatientAggregateStore patientAggregateStore)
        {
            this._patientAggregateStore = patientAggregateStore;
        }

        public async Task HandleAsync(SetWeightCommand command)
        {
            var patient = await _patientAggregateStore.LoadAsync(PatientId.Create(command.Id));
            patient.SetWeight(PatientWeight.Create(command.Weight));
            await _patientAggregateStore.SaveAsync(patient);
        }

        public async Task HandleAsync(SetBloodTypeCommand command)
        {
            var patient = await _patientAggregateStore.LoadAsync(PatientId.Create(command.Id));
            patient.SetBloodType(PatientBloodType.Create(command.BloodType));
            await _patientAggregateStore.SaveAsync(patient);
        }

        public async Task HandleAsync(AdmitPatientCommand command)
        {
            var patient = await _patientAggregateStore.LoadAsync(PatientId.Create(command.Id));
            patient.AdmitPatient();
            await _patientAggregateStore.SaveAsync(patient);
        }

        public async Task HandleAsync(DischargePatientCommand command)
        {
            var patient = await _patientAggregateStore.LoadAsync(PatientId.Create(command.Id));
            patient.DischargePatient();
            await _patientAggregateStore.SaveAsync(patient);
        }
        
        public async Task HandleAsync(AddProcedureCommand command)
        {
            var patient = await _patientAggregateStore.LoadAsync(PatientId.Create(command.Id));
            patient.AddProcedure(Procedure.Create(command.Procedure));
            await _patientAggregateStore.SaveAsync(patient);
        }
    }
}