namespace BPSample.Application.Common.Interfaces
{
    using System;

    public interface ICurrentUserService
    {
        Guid? UserId { get; }
    }
}
