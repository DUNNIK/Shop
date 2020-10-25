namespace Shop.Shop
{
    public class FindProductsForSpecifyAmount : ShopBuilder
    {
        public FindProductsForSpecifyAmount(Shop shop) : base(shop){}

        private static string MakeStr(Product.Product product, int count)
        {
            string result;
            if (product.isKilogramms())
            {
                result = product.Name + " - " + count + " kilogramms" + "\n";
            }
            else
            {
                result = product.Name + " - " + count + " pieces" + "\n";
            }

            return result;
        }

        private static int HowManyProducts(float productPrice, float amount)
        {
            int count = 0;
            while (productPrice < amount)
            {
                count++;
                amount -= productPrice;
            }

            return count;
        }
        public string Find(float amount)
        {
            string resultProducts = "";
            foreach (var product in Shop.ManagerOfShopProducts.
                Build().TrackedProducts.Values)
            {
                var count = HowManyProducts(product.Price, amount);
                resultProducts += MakeStr(product, count);
            }

            return resultProducts;
        }
        public static string Find(float amount, Shop shop)
        {
            string resultProducts = "";
            foreach (var product in shop.ManagerOfShopProducts.Build().
                TrackedProducts.Values)
            {
                if (product.Price < amount)
                {
                    var count = HowManyProducts(product.Price, amount);
                    resultProducts += MakeStr(product, count);
                }
            }

            return resultProducts;
        }
    }
}