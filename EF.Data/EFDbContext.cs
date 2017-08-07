using EF.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data
{
    public class EFDbContext:DbContext
    {
        public EFDbContext() : base("name=DbConnectionString")
        {
            Database.SetInitializer<EFDbContext>(new CreateDatabaseIfNotExists<EFDbContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ZQ");
            {
                var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
               .Where(type => !String.IsNullOrEmpty(type.Namespace))
               .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                    && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
                foreach (var type in typesToRegister)
                {
                    dynamic configurationInstance = Activator.CreateInstance(type);
                    modelBuilder.Configurations.Add(configurationInstance);
                }
                base.OnModelCreating(modelBuilder);
            }
           

        }

        public DbSet<MyUser> Users { get; set; }
    }
}
