namespace BPSample.Infrastructure.Implementation.Data
{
    using BPSample.Infrastructure.Persistence;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BPSample.Application.Common.Interfaces;
    using BPSample.Application.Common.Mapping;
    using BPSample.Domain.Common;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;

    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        public Repository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        public IUnitOfWork UnitOfWork => applicationDbContext;

        public void Add(T entity)
        {
            applicationDbContext.Add(entity);
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await applicationDbContext.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await applicationDbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<TDto>> GetProjectedAsync<TDto>() where TDto : IMapFrom<T>
        {
            return await applicationDbContext.Set<T>().AsNoTracking()
                                .ProjectTo<TDto>(mapper.ConfigurationProvider)
                                .ToListAsync();

        }
    }
}
