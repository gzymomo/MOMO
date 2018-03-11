using System;
using System.Collections.Generic;
using System.Text;

namespace MOMO.Event
{
	[HandlesAsync]
	public class OrderAddedEventHandler_SendEmail : IEventHandler<OrderGeneratorEvent>
	{
		public void Handle(OrderGeneratorEvent evt)
		{
			Console.WriteLine("Order_Number:{0},Send a Email.", evt.OrderID);
		}
	}


	public class OrderAddedEventHandler_Todo : IEventHandler<OrderGeneratorEvent>
	{
		public void Handle(OrderGeneratorEvent evt)
		{
			Console.WriteLine("Order_Number:{0}, Todo.", evt.OrderID);
		}
	}
}
