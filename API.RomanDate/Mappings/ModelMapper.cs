using System;
using System.Linq.Expressions;
using API.RomanDate.Mappings.Interfaces;
using API.RomanDate.Mappings.Profiles.Base;
using AutoMapper;

namespace API.RomanDate.Mappings
{
    public class ModelMapper<TSourceModel, TDestModel> : IModelMapper<TSourceModel, TDestModel>
    {
        private readonly Profile _profile;
        private readonly IMappingExpression<TSourceModel, TDestModel> _map;

        public ModelMapper()
        {
            this._profile = new DefaultProfile();
            this._map = this._profile.CreateMap<TSourceModel, TDestModel>();
        }

        public void RegisterMap<TDest, TSource>(Expression<Func<TDestModel, TDest>> dest, Expression<Func<TSourceModel, TSource>> source) => this._map.ForMember(dest, opt => opt.MapFrom(source));

        public void Ignore<TDest>(Expression<Func<TDestModel, TDest>> dest) => this._map.ForMember(dest, opt => opt.Ignore());

        public void ReverseMap() => this._map.ReverseMap();

        public Profile Build() => this._profile;
    }
}
