using PetMedicine.Pet.Domain.ValueObjects;

namespace PetMedicine.Pet.Domain.Services
{
    public class FakeBreedService : IBreedService
    {
        private readonly List<PetBreed> breeds = new();
        public FakeBreedService()
        {
            breeds.Add(new PetBreed("Beagle"));
            breeds.Add(new PetBreed("Pitbull"));
        }
        public PetBreed Find(string name)
        {
            return breeds.FirstOrDefault(b => b.Value == name);
        }
    }
}