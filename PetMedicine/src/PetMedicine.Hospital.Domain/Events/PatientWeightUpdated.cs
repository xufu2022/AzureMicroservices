using PetMedicine.Common;

namespace PetMedicine.Hospital.Domain.Events
{
    public class PatientWeightUpdated : IDomainEvent
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
    }
}