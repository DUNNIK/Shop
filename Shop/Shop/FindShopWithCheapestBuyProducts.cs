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
            Shop resultShop = new Shop("");
            foreach (var shop in Manager.TrackedShops.Values)
            {
                if (TryCheckProducts(products, shop))
                {
                    var checkFromEachShop = CheckProducts(products, shop);
                    if (checkFromEachShop < minCheck)
                    {
                        minCheck = checkFromEachShop;
                        resultShop = shop;
                    }
                }
            }
            string result = resultShop.Name != null ? resultShop.Name : "No shop";
            return result;
        }

        public bool TryCheckProducts(Dictionary<string, int> products, Shop shop)
        {
            bool res = true;
            try
            {
                CheckProducts(products, shop);//здесь списыывает продукты и потом списывает их в основной функции.
            }
            catch
            {
                res = false;
            }

            return res;
        }
        public float CheckProducts(Dictionary<string, int> products, Shop shop)
        {
            float checkAmount = 0;
            foreach (var product in products)
            {
                checkAmount += CheckOrdinaryProduct(product, shop);
            }

            return checkAmount;
        }
        public bool TryToCheckOrdinaryProduct(KeyValuePair<string, int> product, Shop shop)
        {
            bool result = false;
            var productId = product.Key;
            var productAmount = product.Value;
            if (shop.ManagerOfShopProducts.Build().TrackedProducts.ContainsKey(productId))
            {
                if (shop.ManagerOfShopProducts.Build().TrackedProducts[productId].Count - productAmount >= 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public float CheckOrdinaryProduct(KeyValuePair<string, int> product,
            Shop shop)
        {
            float checkAmount = 0;
            if (TryToCheckOrdinaryProduct(product, shop))
            {
                var productId = product.Key;
                var productAmount = product.Value;
                checkAmount += shop.ManagerOfShopProducts.Build()
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