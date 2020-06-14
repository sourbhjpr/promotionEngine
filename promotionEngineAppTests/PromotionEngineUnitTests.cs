using System;
using System.Collections.Generic;
using Xunit;
using promotionEngineApp;

namespace promotionEngineAppTests
{
    public class PromotionEngineUnitTests
    {
        [Fact]
        public void CheckOfferTestOne()
        {
            Dictionary<string, int> productsInput = new Dictionary<string, int>();
            productsInput.Add("A", 1);
            productsInput.Add("B", 1);
            productsInput.Add("C", 1);


            int output = 100;

            var analyzer = new PromotionOffersCheck();
            Assert.Equal(output, analyzer.CheckData(productsInput));
        }
    }
}