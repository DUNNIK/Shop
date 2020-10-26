namespace Shop.Shop.Methods
{
    public class FindProductsForSpecifyAmount : OrdinaryShopBuilder
    {
        public FindProductsForSpecifyAmount(OrdinaryShop ordinaryShop) : base(ordinaryShop){}

        private static string MakeStr(Product.Product product, int count)
        {
            string result;
            if (product.IsKilograms())
            {
                result = product.Name + " - " + count + " kilograms" + "\n";
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
            foreach (var product in OrdinaryShop.ManagerOfShopProducts.
                Build().TrackedProducts.Values)
            {
                var count = HowManyProducts(product.Price, amount);
                resultProducts += MakeStr(product, count);
            }

            return resultProducts;
        }
        public static string Find(float amount, OrdinaryShop ordinaryShop)
        {
            string resultProducts = "";
            foreach (var product in ordinaryShop.ManagerOfShopProducts.Build().
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