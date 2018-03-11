using System;
using System.Collections.Generic;
using System.Text;

namespace MOMO.Event
{

	 public class OrderGeneratorEvent : IEvent
	{
	    public int OrderID { get; set; }

	}
}
