using PetMedicine.Common;

namespace PetMedicine.Rescue.Domain.Events
{
    public static class DomainEvents
    {
        public static readonly DomainEvent<AdoptionRequestCreated> AdoptionRequestCreated = new();
    }
}