//  --------------------------------------------------------------------------------------
// GameOn.Web.CartViewModel.cs
// 2018/02/18
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using GameOn.Web.Infrastructure;

namespace GameOn.Web.ViewModel
{
    public class CartViewModel
    {
        public delegate CartViewModel Factory();

        readonly CartCalculator cartCalculator;

        public CartViewModel(CartCalculator cartCalculator)
        {
            this.cartCalculator = cartCalculator;
        }

        public IEnumerable<CartListItemViewModel> Items { get; set; }

        public double Subtotal => cartCalculator.CalculateSubtotal(Items);

        public double Tax => cartCalculator.CalculateTax(Items);

        public double Total => Subtotal + Tax;
    }
}