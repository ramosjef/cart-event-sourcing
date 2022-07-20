using System;
using Cart.Application.Domain.Core;

namespace Cart.Application.Domain.CartAggregate.Events
{
    public class CartInactivated : Event
    {
        public DateTime InactivationDate { get; private set; }
        public string InactivatedBy { get; private set; }
        public bool Active { get; private set; }

        public CartInactivated(string id, string inactivatedBy, DateTime inactivationDate)
            : base(id)
        {
            InactivationDate = inactivationDate;
            InactivatedBy = inactivatedBy;
            Active = false;
        }
    }
}