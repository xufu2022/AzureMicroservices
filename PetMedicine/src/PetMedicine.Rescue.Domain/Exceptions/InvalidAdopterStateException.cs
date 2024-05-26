namespace PetMedicine.Rescue.Domain.Exceptions
{
    public class InvalidAdopterStateException : Exception
    {
        public InvalidAdopterStateException(string message) : base(message)
        {
        }
    }
}