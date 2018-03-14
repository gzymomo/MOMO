using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using MOMO.Domain;
using MOMO.Respository.EFCore.Generator;

namespace MOMO.Respository.EFCore.Mappings
{
	public sealed class UserMapping
    {
	    public static void Map(EntityTypeBuilder<User> builder)
	    {
		    builder.ToTable("T_User");
		    builder.HasKey(t => t.Id);

		    builder.Property(t => t.Id)
				.HasColumnName("U_Id")
				.UseSqlServerIdentityColumn()
				.ValueGeneratedOnAdd()
				.HasValueGenerator(GeneratorFactory.SnowflakeIdFactory);

			builder.Property(t => t.Account)
				.IsRequired()
				.HasColumnName("U_Account");
		    builder.Property(t => t.Password)
				.IsRequired()
				.HasColumnName("U_Password");
            builder.Property(s => s.Name)
                .HasColumnName("U_Name")
                .IsRequired();
	        builder.Property(s => s.Sex).IsRequired().HasColumnName("U_Sex");
	        builder.Property(s => s.Status).IsRequired().HasColumnName("U_Status");
	        builder.Property(s => s.Type).IsRequired().HasColumnName("U_Type");
	        builder.Property(s => s.BizCode).IsRequired().HasColumnName("U_BizCode");
	        builder.Property(s => s.CreateId).IsRequired().HasColumnName("U_CreateId");



            builder.Property(t => t.RecoredTime)
				.IsRequired()
				.ValueGeneratedOnAdd()
				.HasValueGenerator(GeneratorFactory.DateTimeFactory)
				.HasColumnName("U_RecoredTime");
		}
		
	   
	}
}
