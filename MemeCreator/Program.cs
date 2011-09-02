using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace FluentNhibernateBlog
{
    class Program
    {
        private static Configuration _configuration;
        private const string DbFile = "memedatabase.db";
        
        static void Main(string[] args)
        {
            var factory = CreateSessionFactory();
            var session = factory.OpenSession();
            Console.Write("Done");
            Console.Read();

        }

        private static ISessionFactory CreateSessionFactory()
        {
            var testing = Fluently
                .Configure().Database(SQLiteConfiguration.Standard.InMemory())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(cfg => _configuration = cfg)
                .BuildSessionFactory();
            return testing;
        }
    }
}
