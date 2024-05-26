using PetMedicine.Rescue.Domain.Entities;
using PetMedicine.Rescue.Domain.ValueObjects;

namespace PetMedicine.Rescue.Domain.Tests
{
    public class RescuedAnimalTests
    {
        [Fact]
        public void StatusShouldBePendingAfterRequestingAdoption()
        {
            var rescuedAnimal = new RescuedAnimal(RescuedAnimalId.Create(Guid.NewGuid()));
            rescuedAnimal.RequestToAdopt(AdopterId.Create(Guid.NewGuid()));
            Assert.Equal(RescuedAnimalAdoptionStatus.PendingReview, rescuedAnimal.AdoptionStatus);
        }
    }
}