using System;
using System.Collections.Generic;
using System.Text;

namespace MOMO.Event
{
	public class ActionDelegatedEventHandler<TEvent> : IEventHandler<TEvent>
		where TEvent : IEvent
	{
		private Action<TEvent> func;
		public ActionDelegatedEventHandler(Action<TEvent> func)
		{
			this.func = func;
		}

		public void Handle(TEvent evt)
		{
			func(evt);
		}
	}
}
