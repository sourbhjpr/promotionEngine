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
            var offers = Offers();
            int divident = 0;
            int remainder = 1;
            foreach (var item in products)
            {
                switch (item.Key)
                {
                    case "A":
                        if (item.Value > 1)
                        {
                            divident = item.Value / offers[0].Units;
                            remainder = item.Value % offers[0].Units;
                        }
                        result += offers[0].Price * divident + (int)ProductSKUPrice.A * remainder;
                        break;
                    case "B":
                        if (item.Value > 1)
                        {
                            divident = item.Value / offers[1].Units;
                            remainder = item.Value % offers[1].Units;
                        }
                        result += offers[1].Price * divident + (int)ProductSKUPrice.B * remainder;
                        break;
                    case "C":
                        if (item.Value > 1)
                        {
                            divident = item.Value / offers[2].Units;
                            remainder = item.Value % offers[2].Units;
                        }
                        result += offers[2].Price * divident + (int)ProductSKUPrice.C * remainder;
                        break;
                    case "D":
                        if (item.Value > 1)
                        {
                            divident = item.Value / offers[2].Units;
                            remainder = item.Value % offers[2].Units;
                        }
                        result += offers[2].Price * divident + (int)ProductSKUPrice.D * remainder;
                        break;
                }
            }

            return result;
        }

        private (string[] Products, int Units, int Price)[] Offers()
        {
            var offerList = new (string[] Products, int Units, int Price)[]
                              {
                                  (new string[]{"A"}, 3, 130),
                                  (new string[]{"B"}, 2, 45),
                                  (new string[]{"C", "D"}, 1, 30)
                              };

            return offerList;

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
