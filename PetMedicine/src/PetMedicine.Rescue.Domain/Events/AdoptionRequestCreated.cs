﻿namespace PetMedicine.Rescue.Domain.Events
{
    public class AdoptionRequestCreated
    {
        public Guid RescuedAnimalId { get; set; }
        public Guid AdopterId { get; set; }
    }
}