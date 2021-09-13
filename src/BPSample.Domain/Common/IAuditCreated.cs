namespace BPSample.Domain.Common
{
    using System;

    public interface IAuditCreated
    {
        Guid? CreatedById { get; }

        DateTimeOffset Created { get; }
    }
}
