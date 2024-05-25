using PetMedicine.Common;

namespace PetMedicine.Pet.Domain.Events
{
    public static class DomainEvents
    {
        public static DomainEvent<PetFlaggedForAdoption> PetFlaggedForAdoption = new();
        public static DomainEvent<PetTransferredToHospital> PetTransferredToHospital = new();
    }
}