using AutoMapper;

namespace Invoices.Handler
{
    public interface IMapperService<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }

    public class MapperService<TSource, TDestination> : IMapperService<TSource, TDestination>
    {
        private readonly IMapper _mapper;

        public MapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}
