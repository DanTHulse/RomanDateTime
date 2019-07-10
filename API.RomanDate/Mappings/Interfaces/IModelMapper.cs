using System;
using System.Linq.Expressions;

namespace API.RomanDate.Mappings.Interfaces
{
    public interface IModelMapper<TSourceModel, TDestModel>
    {
        void RegisterMap<TDest, TSource>(Expression<Func<TDestModel, TDest>> dest, Expression<Func<TSourceModel, TSource>> source);
    }
}
