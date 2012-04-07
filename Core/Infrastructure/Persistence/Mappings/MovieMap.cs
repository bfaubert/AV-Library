using Core.Domain.Model;
using FluentNHibernate.Mapping;

namespace Core.Infrastructure.Persistence.Mappings
{
    public class MovieMap : ClassMap<Movie>
    {
         public MovieMap()
         {
             Table("Movie");
             Id(x => x.Id).Not.Nullable().GeneratedBy.HiLo("1000");
             Map(x => x.Title).Not.Nullable().Not.LazyLoad();
         }
    }
}