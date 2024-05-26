using PetMedicine.Common;

namespace PetMedicine.Hospital.Domain.Events
{
    public class PatientBloodTypeUpdated : IDomainEvent
    {
        public Guid Id { get; set; }
        public string BloodType { get; set; }
    }
}