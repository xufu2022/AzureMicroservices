using PetMedicine.Hospital.Domain.Entities;
using PetMedicine.Hospital.Domain.Exceptions;
using PetMedicine.Hospital.Domain.ValueObjects;

namespace PetMedicine.Hospital.Domain.Tests
{
    public class PatientTest
    {
        [Fact]
        public void PatientCannotBeAdmittedWithoutBloodTypeSet()
        {
            var patient = new Patient(PatientId.Create(Guid.NewGuid()));
            Assert.Throws<InvalidPatientStateException>(() =>
            {
                patient.AdmitPatient();
            });
        }

        [Fact]
        public void PatientCanBeAdmittedWithBloodTypeSet()
        {
            var patient = new Patient(PatientId.Create(Guid.NewGuid()));
            patient.SetBloodType(PatientBloodType.Create("DEA-1.1"));
            patient.AdmitPatient();
        }
    }
}
