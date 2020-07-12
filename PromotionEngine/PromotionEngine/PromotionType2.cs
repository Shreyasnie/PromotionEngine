using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PromotionEngine
{
    public class PromotionType2 : PromotionBaseType<List<char>>
    {
        public override PromotionType PromotionType => PromotionType.CD;

        /// <summary>
        /// Method used to get count number of matching instances.
        /// </summary>
        /// <param name="productCombination">The products.</param>
        /// <returns></returns>
        public override int GetCountofMatchingValue(List<char> productCombination)
        {
            char[] promotionTypeTobeChecked = PromotionType.ToString().ToCharArray();

            List<Tuple<char, int>> numberOfOccurance = GetNumberofOcurrnace(productCombination,
                promotionTypeTobeChecked);

            UpdateNonPromotedItems(productCombination, promotionTypeTobeChecked, numberOfOccurance);

            int numberOfOcuurance = numberOfOccurance.Min(x => x.Item2);
            IsPromotionApplied = numberOfOcuurance > 0;
            return numberOfOcuurance;
        }

        private List<Tuple<char,int>> GetNumberofOcurrnace(List<char> sortedproductCombination, char[] sortedPromotionType)
        {
            List<Tuple<char, int>> numberOfOccurance = new List<Tuple<char, int>>();
            foreach (var item in sortedPromotionType)
            {
                numberOfOccurance.Add(new Tuple<char, int>(item, 
                    Regex.Matches(new string(sortedproductCombination.ToArray()), item.ToString()).Count));
            }

            return numberOfOccurance;
        }

        /// <summary>
        /// Method used to update non promoted items.
        /// </summary>
        /// <param name="productCombination"></param>
        /// <param name="promotionTypeTobeChecked"></param>
        /// <param name="promotionTypeCount"></param>
        private void UpdateNonPromotedItems(List<char> productCombination, char[] promotionTypeTobeChecked, List<Tuple<char, int>> numberofOccurances)
        {
            List<char> nonPromotedItems = new List<char>();
            int numberOfOcuur = numberofOccurances.Min(x => x.Item2);
            foreach (var tupleitem in numberofOccurances)
            {
                if (tupleitem.Item2 > numberOfOcuur)
                {
                    for (int i = 0; i < tupleitem.Item2 - numberOfOcuur; i++)
                    {
                        nonPromotedItems.Add(tupleitem.Item1);
                    }
                }
            }

            nonPromotedItems.AddRange(productCombination.Except(promotionTypeTobeChecked));
            NonPromotedItems = nonPromotedItems;
        }
    }
}
