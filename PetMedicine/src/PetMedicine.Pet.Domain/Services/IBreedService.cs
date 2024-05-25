using PetMedicine.Pet.Domain.ValueObjects;

namespace PetMedicine.Pet.Domain.Services
{
    public interface IBreedService
    {
        PetBreed Find(string name);
    }
}