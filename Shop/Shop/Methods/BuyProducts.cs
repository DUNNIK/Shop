using System.Collections.Generic;
using Shop.Exeptions;

namespace Shop.Shop.Methods
{
    public class BuyProducts : OrdinaryShopBuilder
    {

        public BuyProducts(OrdinaryShop ordinaryShop) : base(ordinaryShop)
        {
            OrdinaryShop = ordinaryShop;
        }

        public bool TryToBuyProduct(KeyValuePair<string, int> product)
        {
            bool result = false;
            var productId = product.Key;
            var productAmount = product.Value;
            if (OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts.ContainsKey(productId))
            {
                if (OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[productId].Count - productAmount >= 0)
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
                OrdinaryShop.ManagerOfShopProducts.Build()
                    .TrackedProducts[productId].Count -= productAmount;
                checkAmount += OrdinaryShop.ManagerOfShopProducts.Build()
                    .TrackedProducts[productId].Price * productAmount;
            }
            else
            {
                throw new BuyException();
            }

            return checkAmount;
        }
        public static float BuyOrdinaryProduct(KeyValuePair<string, int> product,
            OrdinaryShop ordinaryShop)
        {
            float checkAmount = 0;
            if (TryToBuyProduct(product, ordinaryShop))
            {
                var productId = product.Key;
                var productAmount = product.Value;
                ordinaryShop.ManagerOfShopProducts.Build()
                    .TrackedProducts[productId].Count -= productAmount;
                checkAmount += ordinaryShop.ManagerOfShopProducts.Build()
                    .TrackedProducts[productId].Price * productAmount;
            }
            else
            {
                throw new BuyException();
            }

            return checkAmount;
        }
        public static bool TryToBuyProduct(KeyValuePair<string, int> product, OrdinaryShop ordinaryShop)
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
        public static float Buy(Dictionary<string, int> products, OrdinaryShop ordinaryShop)
        {
            float checkAmount = 0;
            foreach (var product in products)
            {
                checkAmount += BuyOrdinaryProduct(product, ordinaryShop);
            }

            return checkAmount;
        }
    }
}