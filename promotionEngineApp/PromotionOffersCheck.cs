using System;
using System.Collections;
using System.Collections.Generic;

namespace promotionEngineApp
{
    public class PromotionOffersCheck
    {
        public int CheckData(Dictionary<string, int> products)
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

    enum ProductSKUPrice
    {
        A = 50,
        B = 30,
        C = 20,
        D = 15
    }
}
