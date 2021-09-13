namespace BPSample.Infrastructure.Implementation
{
    using BPSample.Application.Common.Interfaces;
    using System;

    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
