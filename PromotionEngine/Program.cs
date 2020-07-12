using System.Collections.Generic;

namespace PromotionEngine
{
    public class Program
    {
        static void Main(string[] args)
        {
            IPromotionEngine<List<char>> promotionEngine = new PromotionEngine();
            ICartEngine<List<char>> cartEngine = new CartEngine();

            Billing billing = new Billing(promotionEngine, cartEngine);

            //// Test Setup 1
            List<char> testScenario1 = new List<char>();
            testScenario1.Add('A');
            testScenario1.Add('B');
            testScenario1.Add('C');            

            int totalAmount = billing.CalculateTotalPrice(testScenario1);
        }
    }
}
