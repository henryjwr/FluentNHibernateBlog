using System;
using FluentNHibernate.Automapping;
using FluentNhibernateBlog.Domain;

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