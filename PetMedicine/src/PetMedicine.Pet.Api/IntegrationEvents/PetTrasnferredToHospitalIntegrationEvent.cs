using PetMedicine.Common;

namespace PetMedicine.Pet.Api.IntegrationEvents
{
    public class PetTrasnferredToHospitalIntegrationEvent : IIntegrationEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Sex { get; set; }
        public string Color { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Species { get; set; }
    }
}
