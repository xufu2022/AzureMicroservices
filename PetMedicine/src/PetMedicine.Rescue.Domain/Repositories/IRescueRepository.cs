using PetMedicine.Rescue.Domain.Entities;
using PetMedicine.Rescue.Domain.ValueObjects;

namespace PetMedicine.Rescue.Domain.Repositories
{
    public interface IRescueRepository
    {
        Task<RescuedAnimal> GetRescuedAnimalAsync(RescuedAnimalId id);
        Task AddRescuedAnimalAsync(RescuedAnimal rescuedAnimal);
        Task UpdateRescuedAnimalAsync(RescuedAnimal rescuedAnimal);
        Task<Adopter> GetAdopterAsync(AdopterId id);
        Task AddAdopterAsync(Adopter adopter);
        Task UpdateAdopterAsync(Adopter adopter);
    }
}