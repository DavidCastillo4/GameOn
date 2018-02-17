//  --------------------------------------------------------------------------------------
// GameOn.Web.ProductSummaryViewModel.cs
// 2018/02/16
//  --------------------------------------------------------------------------------------

using System;
using GameOn.Model;

namespace GameOn.Web.ViewModel
{
    public class ProductSummaryViewModel
    {
        public delegate ProductSummaryViewModel Factory(Product product);

        const int MaxLength = 50;

        readonly int descriptionLength;
        readonly Product product;

        public ProductSummaryViewModel(Product product)
        {
            this.product = product;
            descriptionLength = Math.Min(MaxLength, product.Description.Length);
        }

        public string Description => product.Description.Substring(0, descriptionLength);

        public int Id => product.Id;

        public string Name => product.Name;

        public double Price => product.Price;
    }
}