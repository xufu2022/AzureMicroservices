namespace PetMedicine.Pet.Domain.Exceptions
{
    public class InvalidPetStateException : Exception
    {
        public InvalidPetStateException(string message) : base(message)
        {
        }
    }
}