using System;
using System.Collections.Generic;
using Shop.Exeptions;

namespace Shop.Shop
{
    public class FindShopWithCheapestProduct : ShopManagerBuilder
    {
        public FindShopWithCheapestProduct(ShopManager manager) : base(manager) {}

        private static bool TryId(Shop shop, string productId)
        {
            return shop.ManagerOfShopProducts.Manager.TrackedProducts.ContainsKey(productId);
        }
        public static string Find(string productId, ShopManager manager)
        {
            float minPrice = float.MaxValue, price = float.MaxValue;
            string shopName = "";
            foreach (var shop in manager.TrackedShops.Values)
            {
                if (TryId(shop, productId))
                {
                    price = shop.ManagerOfShopProducts.Manager.TrackedProducts[productId].Price;
                }
                if (price < minPrice)
                {
                    minPrice = price;
                    shopName = shop.ToString();
                }
            }

            return shopName;
        }
        public string Find(string productId)
        {
            float minPrice = float.MaxValue, price = float.MaxValue;
            string shopName = "";
            foreach (var shop in Manager.TrackedShops.Values)
            {
                if (TryId(shop, productId))
                {
                    price = shop.ManagerOfShopProducts.Manager.TrackedProducts[productId].Price;
                }

                if (price < minPrice)
                {
                    minPrice = price;
                    shopName = shop.ToString();
                }
            }

            return shopName;
        }
    }
}