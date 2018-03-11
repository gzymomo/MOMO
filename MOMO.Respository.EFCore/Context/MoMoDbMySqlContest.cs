using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MOMO.Domain;

namespace MOMO.Respository.EFCore.Context
{
	 public class MoMoDbMySqlContest:DbContext
    {
	    public MoMoDbMySqlContest(DbContextOptions<MoMoDbMySqlContest> options)
		    : base(options)
	    {

	    }

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
		    base.OnModelCreating(modelBuilder);
		    Mappings.UserMapping.Map(modelBuilder.Entity<User>());
	    }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    optionsBuilder.UseMySQL(@"Server=localhost;database=momo;uid=root;pwd=root;SslMode=None");
	    }
    }
}
