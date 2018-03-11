using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using MOMO.Domain;

namespace MOMO.Respository.EFCore.Generator
{
	/// <summary>
	/// SnowflakeId生成器
	/// </summary>
	public partial class GeneratorFactory
	{
	    public static ValueGenerator SnowflakeIdFactory(IProperty property, IEntityType entityType)
	    {
		    return new SnowflakeValueGenerator();
	    }
	   
	}

	public class SnowflakeValueGenerator : ValueGenerator
	{
		public SnowflakeValueGenerator(bool generatesTemporaryValues = false)
		{
			GeneratesTemporaryValues = generatesTemporaryValues;
		}
		protected override object NextValue(EntityEntry entry)
		{
			return IdWorkerFactory.IdWorker.NextId();
		}
		public override bool GeneratesTemporaryValues { get; }
	}
}
