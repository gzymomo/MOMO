using System;
using System.Collections.Generic;
using System.Text;

namespace MOMO.Event
{
	public abstract class EventHandler<TEvent> : IEventHandler<TEvent> where TEvent : IEvent
	{
		public abstract void Handle(TEvent evt);

		public bool CanHandle(IEvent evt)
			=> typeof(TEvent).Equals(evt.GetType());
	}
}
