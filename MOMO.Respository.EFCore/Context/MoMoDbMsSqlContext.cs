using Microsoft.EntityFrameworkCore;
using MOMO.Domain;

namespace MOMO.Respository.EFCore.Context
{
    public class MoMoDbMsSqlContext:DbContext
    {
		public MoMoDbMsSqlContext(DbContextOptions<MoMoDbMsSqlContext> options)
		    : base(options)
	    {
		}


        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
		    base.OnModelCreating(modelBuilder);
		    Mappings.UserMapping.Map(modelBuilder.Entity<User>());
	    }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    optionsBuilder.UseSqlServer(@"Server=.;Database=MOMO;Trusted_Connection=True;");

		}
	}
}
