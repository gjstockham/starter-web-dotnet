namespace BPSample.Application.Common.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BPSample.Application.Common.Mapping;
    using BPSample.Domain.Common;

    public interface IRepository<T> where T : EntityBase
    {
        void Add(T entity);

        Task<T> GetAsync(Guid id);

        Task<IEnumerable<T>> GetAsync();

        Task<IEnumerable<TDto>> GetProjectedAsync<TDto>() where TDto : IMapFrom<T>;

        IUnitOfWork UnitOfWork { get; }
    }
}
