using System;
		
namespace MOMO.Domain
{
	public abstract class Entity
	{
		public long Id { get; set; }
		public DateTime RecoredTime { get; set; }
	}
}
