namespace PetMedicine.Pet.Domain.Events
{
    public class PetCreated : IDomainEvent
    {
        public Guid Id { get; set; }
    }
}