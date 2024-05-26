using PetMedicine.Common;

namespace PetMedicine.Hospital.Domain.Events
{
    public class PatientDischarged : IDomainEvent
    {
        public Guid Id { get; set; }
    }
}