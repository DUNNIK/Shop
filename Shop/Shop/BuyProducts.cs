using System.Collections.Generic;
using Shop.Exeptions;

namespace Shop.Shop
{
    public class BuyProducts : ShopBuilder
    {

        public BuyProducts(Shop shop) : base(shop)
        {
            Shop = shop;
        }

        public bool TryToBuyProduct(KeyValuePair<string, int> product)
        {
            bool result = false;
            var productId = product.Key;
            var productAmount = product.Value;
            if (Shop.ManagerOfShopProducts.Build().TrackedProducts.ContainsKey(productId))
            {
                if (Shop.ManagerOfShopProducts.Build().TrackedProducts[productId].Count - productAmount >= 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public float Buy(Dictionary<string, int> products)
        {
            float checkAmount = 0;
            foreach (var product in products)
            {
                checkAmount += BuyOrdinaryProduct(product);
            }

            return checkAmount;
        }
        public float BuyOrdinaryProduct(KeyValuePair<string, int> product)
        {
            float checkAmount = 0;
            if (TryToBuyProduct(product))
            {
                var productId = product.Key;
                var productAmount = product.Value;
                Shop.ManagerOfShopProducts.Build()
                    .TrackedProducts[productId].Count -= productAmount;
                checkAmount += Shop.ManagerOfShopProducts.Build()
                    .TrackedProducts[productId].Price * productAmount;
            }
            else
            {
                throw new BuyException();
            }

            return checkAmount;
        }
        public static float BuyOrdinaryProduct(KeyValuePair<string, int> product,
            Shop shop)
        {
            float checkAmount = 0;
            if (TryToBuyProduct(product, shop))
            {
                var productId = product.Key;
                var productAmount = product.Value;
                shop.ManagerOfShopProducts.Build()
                    .TrackedProducts[productId].Count -= productAmount;
                checkAmount += shop.ManagerOfShopProducts.Build()
                    .TrackedProducts[productId].Price * productAmount;
            }
            else
            {
                throw new BuyException();
            }

            return checkAmount;
        }
        public static bool TryToBuyProduct(KeyValuePair<string, int> product, Shop shop)
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
        public static float Buy(Dictionary<string, int> products, Shop shop)
        {
            float checkAmount = 0;
            foreach (var product in products)
            {
                checkAmount += BuyOrdinaryProduct(product, shop);
            }

            return checkAmount;
        }
    }
}