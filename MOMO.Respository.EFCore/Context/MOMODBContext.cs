using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MOMO.Domain;

namespace MOMO.Respository.EFCore.EF
{
    public class MoMoDBContext:DbContext
    {
	    public MoMoDBContext(DbContextOptions<MoMoDBContext> options)
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
		    optionsBuilder.UseSqlServer(@"Server=.;Database=MOMO;Trusted_Connection=True;");

		}
	}
}
