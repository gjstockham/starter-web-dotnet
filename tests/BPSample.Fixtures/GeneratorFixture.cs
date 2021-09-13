namespace BPSample.Fixtures
{
    using System.Collections.Generic;
    using Bogus;
    using BPSample.Domain.Common;

    public abstract class GeneratorFixture<T> where T : EntityBase
    {

        protected abstract Faker<T> Faker();


        public T Generate(string rulesets = null)
        {
            return Faker().Generate(rulesets);
        }

        public IList<T> Generate(int count, string rulesets = null)
        {
            return Faker().Generate(count, rulesets);
        }
    }
}
