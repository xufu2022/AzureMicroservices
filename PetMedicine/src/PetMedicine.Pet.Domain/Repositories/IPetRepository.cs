using PetMedicine.Pet.Domain.ValueObjects;

namespace PetMedicine.Pet.Domain.Repositories
{
    public interface IPetRepository
    {
        Task<Entities.Pet> GetAsync(PetId id);
        Task AddAsync(Entities.Pet pet);
        Task UpdateAsync(Entities.Pet pet);
    }
}