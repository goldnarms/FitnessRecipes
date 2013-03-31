using AutoMapper;

namespace FitnessRecipes.Helpers
{
    public static class AutoMapperExtensions
    {
        public static void Bidirectional<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            Mapper.CreateMap<TDestination, TSource>();
        }
    }
}