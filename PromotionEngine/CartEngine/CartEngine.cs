using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    /// <summary>
    /// This is used to define all available products with price details.
    /// </summary>
    public enum Product
    {
        A = 50,
        B = 30,
        C = 20,
        D = 15
    }

    public class CartEngine : ICartEngine<List<char>>
    {
        /// <summary>
        /// Method used to calculate total price based on product enum.
        /// </summary>
        /// <param name="products">The products to be calculated.</param>
        /// <returns>Returns total price.</returns>
        public int Calculate(List<char> products)
        {
            int total = 0;
            foreach (var orderedItem in products)
            {
                List<Product> availableProducts = Enum.GetValues(typeof(Product))
                            .Cast<Product>()
                            .ToList();
                if (availableProducts.Any(x => x.ToString().Equals(orderedItem.ToString())))
                {
                    total += (int)availableProducts.FirstOrDefault(x => x.ToString().Equals(orderedItem.ToString()));
                }
            }

            return total;
        }
    }
}
