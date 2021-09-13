namespace BPSample.Fixtures
{
    using Bogus;
    using BPSample.Domain.Patients;
    using BPSample.Domain.Shared;

    public class PatientFixture : GeneratorFixture<Patient>
    {
        protected override Faker<Patient> Faker()
        {
            return new Faker<Patient>()
                .StrictMode(true)
                .CustomInstantiator(f =>
                {
                    return new Patient(new ChiNumber("1111111111"), f.Person.FirstName, f.Person.LastName, f.Person.Email, f.Phone.PhoneNumber("+447## ### ####"), f.Random.Guid());
                })
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.CHI, f => new ChiNumber("1111111111"))
                .RuleFor(x => x.GivenName, f => f.Person.FirstName)
                .RuleFor(x => x.FamilyName, f => f.Person.LastName)
                .RuleFor(x => x.EmailAddress, f => f.Person.Email)
                .RuleFor(x => x.MobileNumber, f => f.Phone.PhoneNumber("+447## ### ####"))
                .RuleFor(x => x.OrganisationId, f => f.Random.Guid())
                .RuleFor(x => x.MostRecentMeasurement, f => new BloodPressureMeasurement(f.Random.Int(100, 185), f.Random.Int(70, 100), f.Date.Past()));
        }
    }

}
