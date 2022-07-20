using System;
using System.Collections.Generic;
using Cart.Application.Domain.CartAggregate.Events;
using Cart.Application.Domain.Core;

namespace Cart.Application.Domain.CartAggregate
{
    public class Cart : AggregateBase
    {
        public Cart() : base(Guid.NewGuid().ToString())
        {
            ApplyEvent(new CartCreated(Id));
        }

        public Cart(string id, IEnumerable<Event> events) : base(id, events)
        {
        }

        public DateTime InactivationDate { get; private set; }
        public string InactivatedBy { get; private set; }
        public bool Active { get; private set; }
        public List<CartItem> CartItems { get; private set; } = new List<CartItem>();

        public string AddItem(string skuId, int quantity, string name)
        {
            var cartItemId = Guid.NewGuid().ToString();
            var @event = new CartItemAdded(Id, cartItemId, skuId, quantity, name);
            ApplyEvent(@event);
            return cartItemId;
        }

        public bool RemoveItem(string itemId)
        {
            if (CartItems.Exists(item => item.Id.Equals(itemId)))
            {
                var @event = new CartItemRemoved(Id, itemId);
                ApplyEvent(@event);
                return true;
            }
            return false;
        }

        protected override void RegisterAppliers()
        {
            RegisterApplier<CartCreated>(Apply);
            RegisterApplier<CartItemAdded>(Apply);
            RegisterApplier<CartItemRemoved>(Apply);
            RegisterApplier<CartInactivated>(Apply);
        }
        
        private void Apply(CartInactivated obj)
        {
            InactivationDate = obj.InactivationDate;
            InactivatedBy = obj.InactivatedBy;
            Active = obj.Active;
        }

        private void Apply(CartItemRemoved @event)
        {
            var remove = CartItems.Find(c => c.Id.Equals(@event.ItemId));
            CartItems.Remove(remove);
        }

        private void Apply(CartItemAdded @event)
        {
            var cartItem = new CartItem(@event.CartItemId,
                                        @event.SkuId,
                                        @event.Quantity,
                                        @event.Name);
            CartItems.Add(cartItem);
        }

        private void Apply(CartCreated @event)
        {
            Id = @event.Id;
        }
    }
}
