using System;
using System.Collections.Generic;
using System.Text;
using Snowflake.Core;

namespace MOMO.Domain
{
	public abstract class Entity
	{
		public long Id { get; set; }
		public DateTime RecoredTime { get; set; }
		public Entity()
		{
			//Id = IdWorkerFactory.IdWorker.NextId();
		}
	}
}
