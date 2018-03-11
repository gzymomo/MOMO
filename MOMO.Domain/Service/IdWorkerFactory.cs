using System;
using System.Collections.Generic;
using System.Text;
using Snowflake.Core;

namespace MOMO.Domain
{
    public static class IdWorkerFactory
    {
	    public static IdWorker IdWorker = null;
	    static IdWorkerFactory()
	    {
		    if (IdWorker == null)
		    {
			    IdWorker = new IdWorker(1,1); 
			}
	    }
    }
}
