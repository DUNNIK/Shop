using System;
using System.Collections.Generic;
using Shop.Exeptions;

namespace Shop.Shop
{
    public class CheapestBuyProducts : ShopManagerBuilder
    {
        public CheapestBuyProducts(ShopManager manager) : base(manager)
        {
        }

        public string Find(Dictionary<string, int> products)
        {
            float minCheck = float.MaxValue;
            OrdinaryShop resultOrdinaryShop = new OrdinaryShop("");
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
            string result = resultOrdinaryShop.Name != null ? resultOrdinaryShop.Name : "No shop";
            return result;
        }

        public bool TryCheckProducts(Dictionary<string, int> products, OrdinaryShop ordinaryShop)
        {
            bool res = true;
            try
            {
                CheckProducts(products, ordinaryShop);//здесь списыывает продукты и потом списывает их в основной функции.
            }
            catch
            {
                res = false;
            }

            return res;
        }
        public float CheckProducts(Dictionary<string, int> products, OrdinaryShop ordinaryShop)
        {
            float checkAmount = 0;
            foreach (var product in products)
            {
                checkAmount += CheckOrdinaryProduct(product, ordinaryShop);
            }

            return checkAmount;
        }
        public bool TryToCheckOrdinaryProduct(KeyValuePair<string, int> product, OrdinaryShop ordinaryShop)
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
        public float CheckOrdinaryProduct(KeyValuePair<string, int> product,
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