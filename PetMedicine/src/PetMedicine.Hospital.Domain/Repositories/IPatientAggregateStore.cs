using PetMedicine.Hospital.Domain.Entities;
using PetMedicine.Hospital.Domain.ValueObjects;

namespace PetMedicine.Hospital.Domain.Repositories
{
    public interface IPatientAggregateStore
    {
        Task SaveAsync(Patient patient);
        Task<Patient> LoadAsync(PatientId patient);
    }
}