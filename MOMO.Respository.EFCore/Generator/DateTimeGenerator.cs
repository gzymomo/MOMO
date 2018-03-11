using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using MOMO.Domain;

namespace MOMO.Respository.EFCore.Generator
{
	
	public partial class GeneratorFactory
	{
		/// <summary>
		/// DateTime生成器
		/// </summary>
		public static ValueGenerator DateTimeFactory(IProperty property, IEntityType entityType)
		{
			return new DateTimeValueGenerator();
		}

	}

	public class DateTimeValueGenerator : ValueGenerator
	{
		public DateTimeValueGenerator(bool generatesTemporaryValues = false)
		{
			GeneratesTemporaryValues = generatesTemporaryValues;
		}
		protected override object NextValue(EntityEntry entry)
		{
			return DateTime.Now;
		}
		public override bool GeneratesTemporaryValues { get; }
	}
}
