using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MOMO.Event
{
    public class EventBus
    {
	    private EventBus() { }
	    private static EventBus _eventBus = null;
		private readonly object sync = new object();
		/// <summary>
		/// 事件字典
		/// </summary>
	    private static Dictionary<Type, List<object>> _eventHandlers = new Dictionary<Type, List<object>>();

	    private readonly Func<object, object, bool> eventHandlerEquals = (o1, o2) =>
	    {
		    var o1Type = o1.GetType();
		    var o2Type = o2.GetType();
		    if (o1Type.IsGenericType &&
		        o1Type.GetGenericTypeDefinition() == typeof(ActionDelegatedEventHandler<>) &&
		        o2Type.IsGenericType &&
		        o2Type.GetGenericTypeDefinition() == typeof(ActionDelegatedEventHandler<>))
			    return o1.Equals(o2);
		    return o1Type == o2Type;
	    };

		/// <summary>
		/// 获取实例
		/// </summary>
	    public static EventBus Instance
	    {
		    get { return _eventBus ?? (_eventBus = new EventBus()); }
	    }

	    /// <summary>
	    /// 通过ＸＭＬ文件初始化事件总线，订阅信自在ＸＭＬ里配置
	    /// </summary>
	    /// <returns></returns>
		public static EventBus InstanceForXml()
	    {
		    if (_eventBus == null)
		    {
			    XElement root = XElement.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EventBus.xml"));
			    foreach (var evt in root.Elements("Event"))
			    {
				    List<object> handlers = new List<object>();

				    Type publishEventType = Type.GetType(evt.Element("PublishEvent").Value);
				    foreach (var subscritedEvt in evt.Elements("SubscribedEvents"))
				    foreach (var concreteEvt in subscritedEvt.Elements("SubscribedEvent"))
					    handlers.Add(Type.GetType(concreteEvt.Value));

				    _eventHandlers[publishEventType] = handlers;
			    }

			    _eventBus = new EventBus();
		    }
		    return _eventBus;
	    }

		#region  订阅事件

	    /// <summary>
	    /// 订阅事件列表
	    /// </summary>
	    /// <param name="eventHandler"></param>
	    public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : class, IEvent
	    {
		    lock (sync)
		    {
			    var eventType = typeof(TEvent);
			    if (_eventHandlers.ContainsKey(eventType))
			    {
				    var handlers = _eventHandlers[eventType];
				    if (handlers != null)
				    {
					    if (!handlers.Exists(deh => eventHandlerEquals(deh, eventHandler)))
						    handlers.Add(eventHandler);
				    }
				    else
				    {
					    handlers = new List<object>();
					    handlers.Add(eventHandler);
				    }
			    }
			    else
				    _eventHandlers.Add(eventType, new List<object> { eventHandler });
		    }
	    }

	    /// <summary>
	    /// 订阅事件实体
	    /// </summary>
	    /// <typeparam name="TEvent"></typeparam>
	    /// <param name="eventHandlerFunc"></param>
	    public void Subscribe<TEvent>(Action<TEvent> eventHandlerFunc) where TEvent : class, IEvent
	    {
		    Subscribe(new ActionDelegatedEventHandler<TEvent>(eventHandlerFunc));
	    }
	    public void Subscribe<TEvent>(IEnumerable<IEventHandler<TEvent>> eventHandlers) where TEvent : class, IEvent
	    {
		    foreach (var eventHandler in eventHandlers)
			    Subscribe(eventHandler);
	    }
		#endregion


		#region 取消订阅事件
	    /// <summary>
	    /// 取消订阅事件
	    /// </summary>
	    /// <typeparam name="TEvent"></typeparam>
	    /// <param name="eventHandler"></param>
	    public void UnSubscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : class, IEvent
	    {
		    lock (sync)
		    {
			    var evnetType = typeof(TEvent);
			    if (_eventHandlers.ContainsKey(evnetType))
			    {
				    var handlers = _eventHandlers[evnetType];
				    if (handlers != null && handlers.Any(deh => eventHandlerEquals(deh, eventHandler)))
				    {
					    var handlerToRemove = handlers.First(deh => eventHandlerEquals(deh, eventHandler));
					    handlers.Remove(handlerToRemove);
				    }
			    }
		    }
	    }
	    public void Unsubscribe<TEvent>(IEnumerable<IEventHandler<TEvent>> eventHandlers) where TEvent : class, IEvent
	    {
		    foreach (var eventHandler in eventHandlers)
			    UnSubscribe<TEvent>(eventHandler);
	    }
	    public void Unsubscribe<TEvent>(Action<TEvent> eventHandlerFunc) where TEvent : class, IEvent
	    {
		    UnSubscribe<TEvent>(new ActionDelegatedEventHandler<TEvent>(eventHandlerFunc));
	    }
		#endregion


		#region 发布事件
		/// <summary>
		/// 发布事件
		/// </summary>
		/// <typeparam name="TEvent"></typeparam>
		/// <param name="evnt"></param>
		public void Publish<TEvent>(TEvent evnt) where TEvent : class, IEvent
		{
			if (evnt == null)
			{
				throw new ArgumentNullException("evnt is null");
			}

			var eventType = evnt.GetType();

			if (_eventHandlers.ContainsKey(eventType) &&
				_eventHandlers[eventType] != null &&
				_eventHandlers[eventType].Count > 0)
			{
				var handlers = _eventHandlers[eventType];
				foreach (var handler in handlers)
				{
					var eventHandler = handler as IEventHandler<TEvent>;
					if (eventHandler.GetType().IsDefined(typeof(HandlesAsyncAttribute), false))
					{
						Task.Factory.StartNew((e) => eventHandler.Handle((TEvent)e), evnt);
					}
					else
					{
						eventHandler.Handle(evnt);
					}
				}

			}
		}
		/// <summary>
		///  发布事件，支持异步事件
		/// </summary>
		/// <typeparam name="TEvent"></typeparam>
		/// <param name="evnt"></param>
		/// <param name="callback">回调方法</param>
		/// <param name="timeout"></param>
		public void Publish<TEvent>(TEvent evnt, Action<TEvent, bool, Exception> callback, TimeSpan? timeout = null)
			where TEvent : class, IEvent
		{
			if (evnt == null)
				throw new ArgumentNullException("evnt is null");
			var eventType = evnt.GetType();
			if (_eventHandlers.ContainsKey(eventType) &&
				_eventHandlers[eventType] != null &&
				_eventHandlers[eventType].Count > 0)
			{
				var handlers = _eventHandlers[eventType];
				List<Task> tasks = new List<Task>();
				try
				{
					foreach (var handler in handlers)
					{
						var eventHandler = handler as IEventHandler<TEvent>;
						if (eventHandler.GetType().IsDefined(typeof(HandlesAsyncAttribute), false))
						{
							tasks.Add(Task.Factory.StartNew((o) => eventHandler.Handle((TEvent)o), evnt));
						}
						else
						{
							eventHandler.Handle(evnt);
						}
					}
					if (tasks.Count > 0)
					{
						if (timeout == null)
							Task.WaitAll(tasks.ToArray());
						else
							Task.WaitAll(tasks.ToArray(), timeout.Value);
					}
					callback(evnt, true, null);
				}
				catch (Exception ex)
				{
					callback(evnt, false, ex);
				}
			}
			else
				callback(evnt, false, null);
		}
		#endregion


	}



}
