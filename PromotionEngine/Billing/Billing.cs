using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class Billing : IBilling<List<char>>
    {
        private readonly IPromotionEngine<List<char>> promotionEngine = null;
        private readonly ICartEngine<List<char>> cartEngine = null;

        /// <summary>
        /// This constructor shall be used when there is no promotion.
        /// </summary>
        /// <param name="cartEngine"></param>
        public Billing(ICartEngine<List<char>> cartEngine)
        {
            this.cartEngine = cartEngine;
        }

        /// <summary>
        /// This constructor shall be used when there is promotion.
        /// </summary>
        /// <param name="promotionEngine"></param>
        /// <param name="cartEngine"></param>
        public Billing(IPromotionEngine<List<char>> promotionEngine,ICartEngine<List<char>> cartEngine)
        {
            this.promotionEngine = promotionEngine;
            this.cartEngine = cartEngine;
        }

        /// <summary>
        /// Method used to create total price for the products.
        /// </summary>
        /// <param name="products">The cart items.</param>
        /// <returns>Returns total price.</returns>
        public int CalculateTotalPrice(List<char> products)
        {
            try
            {
                if (cartEngine != null)
                {
                    //// Step 1 : Apply promotions for orders
                    if (promotionEngine != null)
                    {
                        int promotionTotalPrice = promotionEngine.ApplyPromotion(products);

                        //// Calculate billing for the non promoted items.
                        int cartProductTotalPrice = cartEngine.Calculate(promotionEngine.GetNonPromotedItems(products));
                        return promotionTotalPrice + cartProductTotalPrice;
                    }

                    //// step 2 : Calculate non promotion type if it is exists else calculate complete orders
                    return cartEngine.Calculate(products);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }
    }
}
