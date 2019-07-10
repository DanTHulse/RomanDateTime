using System;
using System.Linq.Expressions;
using API.RomanDate.Mappings.Interfaces;
using API.RomanDate.Mappings.Profiles;
using AutoMapper;

namespace API.RomanDate.Mappings
{
    public class ModelMapper<TSourceModel, TDestModel> : IModelMapper<TSourceModel, TDestModel>
    {
        private readonly Profile _profile;
        private readonly IMappingExpression<TSourceModel, TDestModel> _map;

        public ModelMapper()
        {
            _profile = new DefaultProfile();
            _map = _profile.CreateMap<TSourceModel, TDestModel>();
        }

        public void RegisterMap<TDest, TSource>(Expression<Func<TDestModel, TDest>> dest, Expression<Func<TSourceModel, TSource>> source)
        {
            _map.ForMember(dest, opt => opt.MapFrom(source));
        }

        public void Ignore<TDest>(Expression<Func<TDestModel, TDest>> dest)
        {
            _map.ForMember(dest, opt => opt.Ignore());
        }

        public void ReverseMap()
        {
            _map.ReverseMap();
        }

        public Profile Build() => _profile;
    }
}
