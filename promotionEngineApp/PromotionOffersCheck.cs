using System;
using System.Collections;
using System.Collections.Generic;

namespace promotionEngineApp
{
    public class PromotionOffersCheck
    {
        /// <summary>
        /// Function for calculate price
        /// </summary>
        /// <param name="products">products list</param>
        /// <returns>return price</returns>
        public int GetFinalPrice(Dictionary<string, int> products)
        {
            int result = 0;
            List<Offer> offers = Offers();
            foreach (var item in products)
            {
                switch (item.Key)
                {
                    case "A":
                        result += CalculatePrice("A", offers, item, (int)ProductSKUPrice.A, products);
                        break;
                    case "B":
                        result += CalculatePrice("B", offers, item, (int)ProductSKUPrice.B, products);
                        break;
                    case "C":
                        result += CalculatePrice("C", offers, item, (int)ProductSKUPrice.C, products);
                        break;
                    case "D":
                        result += CalculatePrice("D", offers, item, (int)ProductSKUPrice.D, products);
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Calculate price of product
        /// </summary>
        /// <param name="ProductType">type of product like A, B</param>
        /// <param name="offers">offers for product</param>
        /// <param name="item">item in a product</param>
        /// <param name="skuPrice">sku price</param>
        /// <param name="products">products list</param>
        /// <returns>return price</returns>
        private int CalculatePrice(string ProductType, List<Offer> offers, KeyValuePair<string, int> item, int skuPrice,Dictionary<string, int> products)
        {
            int result = 0;
            double divident = 0;
            int remainder = 1;
            int offerPrice = 0;

            var product = offers.Find(i => i.Products.Contains(ProductType));

            if (product.Products.Count > 1 && products.ContainsKey("C") && products.ContainsKey("D"))
            { 
                var  nextProductC = offers.Find(i => i.Products.Contains("C"));
            
                var  nextProductD = offers.Find(i => i.Products.Contains("D"));

                int commonUnitDivident = 0;
                if (nextProductC.Units >= nextProductD.Units)
                {
                    commonUnitDivident = nextProductC.Units / nextProductD.Units;
                    divident = (double)(commonUnitDivident * nextProductD.Units)/2;

                    remainder = nextProductC.Units % nextProductD.Units;
                }
                else
                {
                    commonUnitDivident = nextProductD.Units / nextProductC.Units;
                    divident = (double)(commonUnitDivident * nextProductC.Units)/2;

                    remainder = nextProductD.Units % nextProductC.Units;
                }
                offerPrice = (int)(product.Price * divident);
            }
            else
            {
                if (item.Value > 1 && product != null)
                {
                    divident = item.Value / product.Units;
                    remainder = item.Value % product.Units;
                    offerPrice = (int)(product.Price * divident);
                }

            }

           
            result += offerPrice + skuPrice * remainder;

            return result;
        }

        /// <summary>
        /// List all the offers
        /// </summary>
        /// <returns></returns>
        private List<Offer> Offers()
        {

            var offerList = new List<Offer>();

            Offer offer1 = new Offer()
            { 
                Products = new List<string>() { "A" },
                Units = 3,
                Price = 130
            };

            Offer offer2 = new Offer()
            {
                Products = new List<string>() { "B" },
                Units = 2,
                Price = 45
            };

            Offer offer3 = new Offer()
            {
                Products = new List<string>() { "C", "D" },
                Units = 1,
                Price = 30
            };

            offerList.Add(offer1);
            offerList.Add(offer2);
            offerList.Add(offer3);

            return offerList;

        }
    }

    /// <summary>
    /// Product offer class
    /// </summary>
     class Offer
    {
       public List<string> Products
        {
            get; set;
        }

        public int Units
        {
            get; set;
        }

        public int Price
        {
            get; set;
        }
    }

    /// <summary>
    /// Product SKU Enum 
    /// </summary>
    enum ProductSKUPrice
    {
        A = 50,
        B = 30,
        C = 20,
        D = 15
    }
}
