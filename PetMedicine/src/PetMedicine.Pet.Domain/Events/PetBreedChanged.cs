namespace PetMedicine.Pet.Domain.Events
{
    public class PetBreedChanged : IDomainEvent
    {
        public Guid Id { get; set; }
        public string Breed { get; set; }
    }
}