using Microsoft.EntityFrameworkCore;

namespace DAL.Core.Configurators.Interfaces
{
    public interface IConfigurator
    {
        public Type Type { get; }
        public Type[] DependsOn { get; }

        public void Configure(ModelBuilder modelBuilder);
        public void Seed(DbContext dbContext);
    }
}