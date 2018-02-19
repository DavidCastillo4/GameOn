//  --------------------------------------------------------------------------------------
// GameOn.Web.CartCalculator.cs
// 2018/02/18
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using GameOn.Web.ViewModel;

namespace GameOn.Web.Infrastructure
{
    public class CartCalculator
    {
        const double TaxRate = 0.07;

        public double CalculateSubtotal(IEnumerable<CartListItemViewModel> input)
        {
            double result = 0;
            foreach (var cartListItemViewModel in input)
                result += cartListItemViewModel.Price * cartListItemViewModel.Quantity;
            return result;
        }

        public double CalculateTax(IEnumerable<CartListItemViewModel> input)
        {
            return TaxRate * CalculateSubtotal(input);
        }
    }
}