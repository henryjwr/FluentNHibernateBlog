using System;
using FluentNHibernate.Automapping;

namespace FluentNhibernateBlog
{
    public class BlogConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "FluentNhibernateBlog.Domain";
        }
    }
}