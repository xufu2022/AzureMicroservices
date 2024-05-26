using PetMedicine.Common;

namespace PetMedicine.Hospital.Domain.Events
{
    public class PatientAdmitted : IDomainEvent
    {
        public Guid Id { get; set; }
    }
}