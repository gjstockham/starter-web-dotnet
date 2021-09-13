namespace BPSample.Fixtures
{
    using Bogus;
    using BPSample.Domain.Organisations;

    public class OrganisationFixture : GeneratorFixture<Organisation>
    {
        protected override Faker<Organisation> Faker()
        {
            return new Faker<Organisation>()
                .StrictMode(true)
                .CustomInstantiator(f =>
                {
                    return new Organisation(f.Random.Guid(), f.Company.CompanyName());
                })
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => f.Company.CompanyName());
        }
    }
}
