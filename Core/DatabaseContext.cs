using CDNS.DAL.Core.Configurators;
using Microsoft.EntityFrameworkCore;

namespace CDNS.DAL.Core
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;
            CreateDatabaseIfNotExists();
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            CreateDatabaseIfNotExists();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var configurators = ConfiguratorProvider.Provide();
            configurators.ForEach(c => c.Configure(builder));
        }

        private void CreateDatabaseIfNotExists()
        {
            var isNewDatabaseCreated = Database.EnsureCreated();
            if (isNewDatabaseCreated)
            {
                lock (this)
                {
                    var configurators = ConfiguratorProvider.Provide();
                    configurators.ForEach(c =>
                    {
                        c.Seed(this);
                        SaveChanges();
                    });
                }
            }
        }
    }
}