namespace BPSample.Domain.Common
{
    using System;
    public interface IAuditModified
    {
        Guid? LastModifiedById { get; }

        DateTimeOffset LastModified { get; }
    }
}
