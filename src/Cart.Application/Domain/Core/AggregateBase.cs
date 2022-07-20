using System;
using System.Collections.Generic;

namespace Cart.Application.Domain.Core
{
    public abstract class AggregateBase
    {
        public AggregateBase(string id)
        {
            Id = id;
            Changes = new List<EventWrapper>();
            RegisterAppliers();
        }

        public AggregateBase(string id, IEnumerable<Event> events)
            : this(id)
        {
            foreach (var @event in events)
                ApplyEvent(@event as dynamic, true);
        }

        public string Id { get; set; }
        public int Version { get; set; }
        public List<EventWrapper> Changes { get; private set; }
        private Dictionary<Type, Action<Event>> Appliers { get; } = new Dictionary<Type, Action<Event>>();
        protected void RegisterApplier<TIn>(Action<TIn> applier)
            where TIn : Event
        {
            void Applier(Event @event) => applier((TIn)@event);
            this.Appliers.Add(typeof(TIn), Applier);
        }
        protected abstract void RegisterAppliers();
        protected void ApplyEvent<TIn>(TIn @event, bool isPrevious = false)
            where TIn : Event
        {
            var type = @event.GetType();
            var applier = Appliers[type];
            applier(@event);

            Version++;

            if (isPrevious) return;

            Changes.Add(WrapEvent(@event, Version));
        }

        private EventWrapper WrapEvent(Event @event, int version)
        {
            var streamName = GetType().Name;
            return new EventWrapper(@event, version, streamName);
        }
    }
}
