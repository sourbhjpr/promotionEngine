using System.Collections.Generic;
using Xunit;
using promotionEngineApp;

namespace promotionEngineAppTests
{
    /// <summary>
    /// Promotion Engine Unit Tests
    /// </summary>
    public class PromotionEngineUnitTests
    {
        /// <summary>
        /// Test case one
        /// </summary>
        [Fact]
        public void CheckOfferTestOne()
        {
            Dictionary<string, int> productsInput = new Dictionary<string, int>();
            productsInput.Add("A", 1);
            productsInput.Add("B", 1);
            productsInput.Add("C", 1);


            int output = 100;

            var analyzer = new PromotionOffersCheck();
            Assert.Equal(output, analyzer.GetFinalPrice(productsInput));
        }


        /// <summary>
        /// Test case two
        /// </summary>
        [Fact]
        public void CheckOfferTestTwo()
        {
            Dictionary<string, int> productsInput = new Dictionary<string, int>();
            productsInput.Add("A", 5);
            productsInput.Add("B", 5);
            productsInput.Add("C", 1);


            int output = 370;

            var analyzer = new PromotionOffersCheck();
            Assert.Equal(output, analyzer.GetFinalPrice(productsInput));
        }


        /// <summary>
        /// Test case three
        /// </summary>
        [Fact]
        public void CheckOfferTestThree()
        {
            Dictionary<string, int> productsInput = new Dictionary<string, int>();
            productsInput.Add("A", 3);
            productsInput.Add("B", 5);
            productsInput.Add("C", 1);
            productsInput.Add("D", 1);

            int output = 280;

            var analyzer = new PromotionOffersCheck();
            Assert.Equal(output, analyzer.GetFinalPrice(productsInput));
        }
    }
}