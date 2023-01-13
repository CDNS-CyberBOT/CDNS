using CDNS.DAL.Core.Configurators.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CDNS.DAL.Core.Configurators.Implementations
{
    public abstract class GenericConfigurator<T> : IGenericConfigurator<T> where T : class
    {
        public Type Type => typeof(T);
        public abstract Type[] DependsOn { get; }

        public virtual void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T>().ToTable(typeof(T).Name);
        }

        public virtual void Seed(DbContext dbContext) { }
    }
}