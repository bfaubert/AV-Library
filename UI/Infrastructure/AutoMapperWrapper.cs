using AutoMapper;

namespace UI.Infrastructure
{
    public static class AutoMapperWrapper
    {
        /// <summary>
        /// Maps a source type to a destination type.
        /// </summary>
        /// <typeparam name="TSource">Source object type.</typeparam>
        /// <typeparam name="TDestination">Destination object type.</typeparam>
        /// <param name="source">An instance of the source type to be mapped from.</param>
        /// <returns>An instance of the destination type containing the mappings.</returns>
        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
    }
}