namespace BPSample.Domain.Shared
{
    using System.Collections.Generic;
    using Ardalis.GuardClauses;
    using BPSample.Domain.Common;

    public class ChiNumber : ValueObject
    {
        protected ChiNumber()
        {
        }

        public ChiNumber(string value)
        {
            Guard.Against.NullOrWhiteSpace(value, nameof(value));
            Guard.Against.InvalidFormat(value, nameof(value), @"^\d{10}$|^\w{2}\d{8}$", $"CHI must be only 10 characters: {value}");
            Guard.Against.InvalidInput(value, nameof(value), x => ValidateChecksum(x), $"Invalid CHI: {value}");

            Value = value;
        }

        public string Value { get; } = null!;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private static bool ValidateChecksum(string input)
        {
            if (input == null || input.Length == 0)
            {
                return false;
            }

            var total = 0;

            for (var i = 0; i < input.Length - 1; i++)
            {
                var factor = 10 - i;
                var digit = int.Parse(input.Substring(i, 1));
                total += factor * digit;
            }

            var mod11 = total % 11;

            var result = 11 - mod11;

            if (result > 11)
            {
                result = 0;
            }

            var checksum = int.Parse(input.Substring(9, 1));
            return result == checksum;
        }
    }
}

