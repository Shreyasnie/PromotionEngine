using System.Collections.Generic;

namespace PromotionEngine
{
    public enum PromotionType
    {
        AAA = 130,
        CD = 30
    }

    public class PromotionEngine : IPromotionEngine<List<char>>
    {
        private readonly List<PromotionBaseType<List<char>>> promotionsToBeApplied;

        public PromotionEngine()
        {
            promotionsToBeApplied = new List<PromotionBaseType<List<char>>>
            {
                new PromotionType1(),
                new PromotionType2()
            };
        }

        /// <summary>
        /// Method used to get non promoted items.
        /// </summary>
        /// <param name="products">The products.</param>
        /// <returns>Returns non promoted items.</returns>
        public List<char> GetNonPromotedItems(List<char> products)
        {
            List<char> nonPromotedItemsToBeVerified = products;
            foreach (var promotion in promotionsToBeApplied)
            {
                nonPromotedItemsToBeVerified = promotion.NonPromotedItems;
                if (promotion.IsPromotionApplied) //// To Apply multiple promotion type. for each loop should be continue for all promotion type.
                {
                    break;
                }
            }

            return nonPromotedItemsToBeVerified;
        }

        /// <summary>
        /// Method used to apply promotion.
        /// </summary>
        /// <param name="products">The products.</param>
        /// <returns>Returns total value of the product after promotion is applied.</returns>
        public int ApplyPromotion(List<char> products)
        {
            if (promotionsToBeApplied != null)
            {
                int totalPromotedAmount = 0;

                //// Step 1 : Apply promotions for orders
                foreach (var promotion in promotionsToBeApplied)
                {
                    totalPromotedAmount += promotion.GetPromotionValue(products);

                    //// step 2 : If one promotions applied the other promotions will be ignored.
                    if (promotion.IsPromotionApplied) //// To Apply multiple promotion type. for each loop should be continue for all promotion type.
                    {                        
                        break;
                    }
                }

                return totalPromotedAmount;
            }

            return 0;
        }
    }
}
