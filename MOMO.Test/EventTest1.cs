using System;
using MOMO.Event;
using Xunit;

namespace MOMO.Test
{
    public class EventTest1
    {
	    [Fact]
		public void SubscribeTest()
	    {
		    EventBus.Instance.Subscribe(new OrderAddedEventHandler_SendEmail());
		    EventBus.Instance.Subscribe(new OrderAddedEventHandler_Todo());

		    var entity = new OrderGeneratorEvent { OrderID = 1 };
		    Console.WriteLine("生成一个订单，单号为{0}", entity.OrderID);
		    //EventBus.Instance.Publish(entity);



		    Action<OrderGeneratorEvent, bool, Exception> sdf = (e, flog, ex) => { Console.WriteLine("q的值：" + flog); };
		    EventBus.Instance.Publish(entity, sdf);

	    }
	}
}
