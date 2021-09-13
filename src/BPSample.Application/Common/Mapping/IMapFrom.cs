namespace BPSample.Application.Common.Mapping
{
    using AutoMapper;

    public interface IMapFrom<TEntity>
    {
        void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(TEntity), GetType());
        }
    }
}
