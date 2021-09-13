namespace BPSample.Fixtures
{
    using Bogus;
    using BPSample.Domain.Clinicians;

    public class ClinicianFixture : GeneratorFixture<Clinician>
    {
        protected override Faker<Clinician> Faker()
        {
            return new Faker<Clinician>()
                .StrictMode(true)
                .CustomInstantiator(f =>
                {
                    return new Clinician(f.Person.FirstName, f.Person.LastName, f.Person.Email, f.Random.Guid());
                })
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.GivenName, f => f.Person.FirstName)
                .RuleFor(x => x.FamilyName, f => f.Person.LastName)
                .RuleFor(x => x.EmailAddress, f => f.Person.Email)
                .RuleFor(x => x.OrganisationId, f => f.Random.Guid());
        }
    }
}
