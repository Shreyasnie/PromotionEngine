using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PromotionEngine
{
    public class PromotionType1 : PromotionBaseType<List<char>>
    {
        public override PromotionType PromotionType => PromotionType.AAA;

        /// <summary>
        /// Method used to get count number of matching instances.
        /// </summary>
        /// <param name="productCombination">The products.</param>
        /// <returns></returns>
        public override int GetCountofMatchingValue(List<char> productCombination)
        {
            char[] promotionTypeTobeChecked = PromotionType.ToString().ToCharArray();
            string productCombinationStr = new string(productCombination.ToArray());
            int promotionTypeCount = Regex.Matches
                (productCombinationStr, promotionTypeTobeChecked[0].ToString()).Count;

            //// Calculate Non Promoted Items
            UpdateNonPromotedItems(productCombination, promotionTypeTobeChecked, promotionTypeCount);

            int result = (int)Math.Floor(Convert.ToDecimal(promotionTypeCount / promotionTypeTobeChecked.Count()));
            IsPromotionApplied = result > 0;
            return result;
        }

        /// <summary>
        /// Method used to update non promoted items.
        /// </summary>
        /// <param name="productCombination"></param>
        /// <param name="promotionTypeTobeChecked"></param>
        /// <param name="promotionTypeCount"></param>
        private void UpdateNonPromotedItems(List<char> productCombination, char[] promotionTypeTobeChecked, int promotionTypeCount)
        {
            List<char> nonPromotedItems = new List<char>();
            int remainder = promotionTypeCount % promotionTypeTobeChecked.Count();
            for (int i = 0; i < remainder; i++)
            {
                nonPromotedItems.Add(promotionTypeTobeChecked[0]);
            }

            nonPromotedItems.AddRange(productCombination.Where(x=>x.Equals(promotionTypeTobeChecked[0]) == false));
            NonPromotedItems = new List<char>(nonPromotedItems);
        }
    }
}
