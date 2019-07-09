using API.RomanDate.Mappings.Interfaces;

namespace API.RomanDate.Mappings
{
    public class Mapper : IMapper
    {
        private readonly AutoMapper.IMapper _mapper;

        public Mapper(AutoMapper.IMapper mapper)
        {
            this._mapper = mapper;
        }

        public T Map<T>(object source) => this._mapper.Map<T>(source);
    }
}
