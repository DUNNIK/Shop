
namespace Shop.Shop.Methods
{
    public class OrdinaryShopProductCountBuilder : OrdinaryShopBuilder
    {
        public OrdinaryShopProductCountBuilder(OrdinaryShop ordinaryShop) : base(ordinaryShop)
        {
        }

        public OrdinaryShopProductCountBuilder New(string productId, float newCount)
        {
            var product
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[productId];
            product.Count = newCount;
            return this;
        }

        public OrdinaryShopProductCountBuilder New(Product.Product product, float newCount)
        {
            var shopProduct
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[product.Id];
            shopProduct.Count = newCount;
            return this;
        }

        public OrdinaryShopProductCountBuilder ChangeOn(Product.Product product,
            float countChange)
        {
            var shopProduct
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[product.Id];
            shopProduct.Count += countChange;
            return this;
        }

        public OrdinaryShopProductCountBuilder ChangeOn(string productId, float countChange)
        {
            var shopProduct
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[productId];
            shopProduct.Count += countChange;
            return this;
        }
    }

    public class OrdinaryShopProductPriceBuilder : OrdinaryShopBuilder
    {
        public OrdinaryShopProductPriceBuilder(OrdinaryShop ordinaryShop) : base(ordinaryShop)
        {
        }

        public OrdinaryShopProductPriceBuilder New(string productId, float newPrice)
        {
            var product
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[productId];
            product.Price = newPrice;
            return this;
        }

        public OrdinaryShopProductPriceBuilder New(Product.Product product, float newPrice)
        {
            var shopProduct
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[product.Id];
            shopProduct.Price = newPrice;
            return this;
        }

        public OrdinaryShopProductPriceBuilder ChangeOn(Product.Product product,
            float priceChange)
        {
            var shopProduct
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[product.Id];
            shopProduct.Price += priceChange;
            return this;
        }

        public OrdinaryShopProductPriceBuilder ChangeOn(string productId, float priceChange)
        {
            var shopProduct
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[productId];
            shopProduct.Price += priceChange;
            return this;
        }
    }
}