using PetMedicine.Common;

namespace PetMedicine.Hospital.Domain.Events
{
    public class PatientCreated : IDomainEvent
    {
        public Guid Id { get; set; }
    }
}