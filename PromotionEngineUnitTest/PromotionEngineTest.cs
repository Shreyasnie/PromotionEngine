using System.Collections.Generic;
using PromotionEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PromotionEngineUnitTest
{
    [TestClass]
    public class PromotionEngineTest
    {
        [TestMethod]
        [TestCategory("No Promotion Applied")]
        public void Promotion_Is_Not_Applied_On_Products()
        {
            int expected = 100;
            IPromotionEngine<List<char>> promotionEngine = new PromotionEngine.PromotionEngine();
            ICartEngine<List<char>> cartEngine = new CartEngine();

            Billing billing = new Billing(promotionEngine, cartEngine);

            List<char> orderedProducts = new List<char>
            {
                'A',
                'B',
                'C'
            };

            int actual = billing.CalculateTotalPrice(orderedProducts);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Promotion Applied")]
        public void Promotion1_Is_Applied_On_Products()
        {
            int expected = 180;
            IPromotionEngine<List<char>> promotionEngine = new PromotionEngine.PromotionEngine();
            ICartEngine<List<char>> cartEngine = new CartEngine();

            Billing billing = new Billing(promotionEngine, cartEngine);

            List<char> orderedProducts = new List<char>
            {
                'A',
                'A',
                'A',
                'B',
                'C'
            };

            int actual = billing.CalculateTotalPrice(orderedProducts);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Promotion Applied")]
        public void Promotion1_only_Applied_On_Products_Eventhough_Multiple_Promotions_Are_Valid()
        {
            int expected = 195;
            IPromotionEngine<List<char>> promotionEngine = new PromotionEngine.PromotionEngine();
            ICartEngine<List<char>> cartEngine = new CartEngine();

            Billing billing = new Billing(promotionEngine, cartEngine);

            List<char> orderedProducts = new List<char>
            {
                'A',
                'A',
                'A',
                'B',
                'C',
                'D'
            };

            int actual = billing.CalculateTotalPrice(orderedProducts);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Invalid Cart Item")]
        public void Promotion_Is_Not_Applied_On_Products_When_Products_Has_Invalid_CartItem()
        {
            int expected = 50;
            IPromotionEngine<List<char>> promotionEngine = new PromotionEngine.PromotionEngine();
            ICartEngine<List<char>> cartEngine = new CartEngine();

            Billing billing = new Billing(promotionEngine, cartEngine);

            List<char> orderedProducts = new List<char>
            {
                'A',
                'Z'
            };

            int actual = billing.CalculateTotalPrice(orderedProducts);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Invalid Cart Item")]
        public void Promotion_Is_Not_Applied_When_Products_Has_Invalid_CartItem()
        {
            int expected = 0;
            IPromotionEngine<List<char>> promotionEngine = new PromotionEngine.PromotionEngine();
            ICartEngine<List<char>> cartEngine = new CartEngine();

            Billing billing = new Billing(promotionEngine, cartEngine);

            List<char> orderedProducts = new List<char>
            {
                'Z'
            };

            int actual = billing.CalculateTotalPrice(orderedProducts);

            Assert.AreEqual(expected, actual);
        }
    }
}
