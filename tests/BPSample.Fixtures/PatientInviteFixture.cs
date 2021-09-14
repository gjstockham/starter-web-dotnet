namespace BPSample.Fixtures
{
    using Bogus;
    using BPSample.Domain.PatientInvites;
    using BPSample.Domain.Shared;

    public class PatientInviteFixture : GeneratorFixture<PatientInvite>
    {
        protected override Faker<PatientInvite> Faker()
        {
            return new Faker<PatientInvite>()
                .StrictMode(true)
                .CustomInstantiator(f =>
                {
                    return new PatientInvite(new ChiNumber("1111111111"), f.Person.FirstName, f.Person.LastName, f.Person.Email, f.Phone.PhoneNumber("+447## ### ####"), f.Random.Guid());
                })
                .RuleFor(x => x.Id, f => f.Random.Guid());
        }
    }
}
