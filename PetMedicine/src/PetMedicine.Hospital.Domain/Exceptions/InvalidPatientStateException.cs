namespace PetMedicine.Hospital.Domain.Exceptions
{
    public class InvalidPatientStateException : Exception
    {
        public InvalidPatientStateException(string message) : base(message)
        {
        }
    }
}