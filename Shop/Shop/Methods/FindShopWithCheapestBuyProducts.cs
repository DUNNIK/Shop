using System.Collections.Generic;
using Shop.Exceptions;

namespace Shop.Shop.Methods
{
    public class CheapestBuyProducts : ShopManagerBuilder
    {
        public CheapestBuyProducts(ShopManager manager) : base(manager)
        {
        }

        public string Find(Dictionary<string, int> products)
        {
            float minCheck = float.MaxValue;
            Shop resultOrdinaryShop = new OrdinaryShop("");
            foreach (var shop in Manager.TrackedShops.Values)
            {
                if (TryCheckProducts(products, shop))
                {
                    var checkFromEachShop = CheckProducts(products, shop);
                    if (checkFromEachShop < minCheck)
                    {
                        minCheck = checkFromEachShop;
                        resultOrdinaryShop = shop;
                    }
                }
            }
            string result = resultOrdinaryShop.Name ?? "No shop";
            return result;
        }
        public static string Find(Dictionary<string, int> products, ShopManager manager)
        {
            float minCheck = float.MaxValue;
            Shop resultOrdinaryShop = new OrdinaryShop("");
            foreach (var shop in manager.TrackedShops.Values)
            {
                if (TryCheckProducts(products, shop))
                {
                    var checkFromEachShop = CheckProducts(products, shop);
                    if (checkFromEachShop < minCheck)
                    {
                        minCheck = checkFromEachShop;
                        resultOrdinaryShop = shop;
                    }
                }
            }
            string result = resultOrdinaryShop.Name ?? "No shop";
            return result;
        }

        private static bool TryCheckProducts(Dictionary<string, int> products, OrdinaryShop ordinaryShop)
        {
            bool res = true;
            try
            {
                CheckProducts(products, ordinaryShop);
            }
            catch
            {
                res = false;
            }

            return res;
        }

        private static float CheckProducts(Dictionary<string, int> products, OrdinaryShop ordinaryShop)
        {
            float checkAmount = 0;
            foreach (var product in products)
            {
                checkAmount += CheckOrdinaryProduct(product, ordinaryShop);
            }

            return checkAmount;
        }

        private static bool TryToCheckOrdinaryProduct(KeyValuePair<string, int> product, OrdinaryShop ordinaryShop)
        {
            bool result = false;
            var productId = product.Key;
            var productAmount = product.Value;
            if (ordinaryShop.ManagerOfShopProducts.Build().TrackedProducts.ContainsKey(productId))
            {
                if (ordinaryShop.ManagerOfShopProducts.Build().TrackedProducts[productId].Count - productAmount >= 0)
                {
                    result = true;
                }
            }
            return result;
        }

        private static float CheckOrdinaryProduct(KeyValuePair<string, int> product,
            OrdinaryShop ordinaryShop)
        {
            float checkAmount = 0;
            if (TryToCheckOrdinaryProduct(product, ordinaryShop))
            {
                var productId = product.Key;
                var productAmount = product.Value;
                checkAmount += ordinaryShop.ManagerOfShopProducts.Build()
                    .TrackedProducts[productId].Price * productAmount;
            }
            else
            {
                throw new BuyException();
            }

            return checkAmount;
        }
    }
}