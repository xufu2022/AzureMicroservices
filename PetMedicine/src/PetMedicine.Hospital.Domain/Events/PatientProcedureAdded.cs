using PetMedicine.Common;

namespace PetMedicine.Hospital.Domain.Events
{
    public class PatientProcedureAdded : IDomainEvent
    {
        public Guid PatientId { get; set; }
        public Guid Id { get; set; }
        public string ProcedureName { get; set; }
    }
}