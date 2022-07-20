using System;
using System.Collections.Generic;

namespace Cart.Application.DTO
{
    public class CartDTO
    {
        public string Id { get; set; }
        public DateTime InactivationDate { get; set; }
        public string InactivatedBy { get; set; }
        public bool Active { get; set; }
        public List<CartItemDTO> CartItems { get; set; }
        public int Version { get; set; }
    }
}
