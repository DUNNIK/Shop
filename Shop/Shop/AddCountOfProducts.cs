
namespace Shop.Shop
{
        public class ShopProductCountBuilder : ShopBuilder
    {
        public ShopProductCountBuilder(Shop shop) : base(shop){}
        
        public ShopProductCountBuilder New(string productId, float newCount)
        {
            Product.Product product 
                = Shop.ManagerOfShopProducts.Build().TrackedProducts[productId];
            product.Count = newCount;
            return this;
        }
        public ShopProductCountBuilder New(Product.Product product, float newCount)
        {
            Product.Product shopProduct 
                = Shop.ManagerOfShopProducts.Build().TrackedProducts[product.Id];
            shopProduct.Count = newCount;
            return this;
        }
        public ShopProductCountBuilder ChangeOn(Product.Product product, 
            float countChange)
        {
            Product.Product shopProduct 
                = Shop.ManagerOfShopProducts.Build().TrackedProducts[product.Id];
            shopProduct.Count += countChange;
            return this;
        }
        public ShopProductCountBuilder ChangeOn(string productId, float countChange)
        {
            Product.Product shopProduct 
                = Shop.ManagerOfShopProducts.Build().TrackedProducts[productId];
            shopProduct.Count += countChange;
            return this;
        }
    }
    public class ShopProductPriceBuider : ShopBuilder
    {
        public ShopProductPriceBuider(Shop shop) : base(shop){}

        public ShopProductPriceBuider New(string productId, float newPrice)
        {
            Product.Product product 
                = Shop.ManagerOfShopProducts.Build().TrackedProducts[productId];
            product.Price = newPrice;
            return this;
        }
        public ShopProductPriceBuider New(Product.Product product, float newPrice)
        {
            Product.Product shopProduct 
                = Shop.ManagerOfShopProducts.Build().TrackedProducts[product.Id];
            shopProduct.Price = newPrice;
            return this;
        }
        public ShopProductPriceBuider ChangeOn(Product.Product product, 
            float priceChange)
        {
            Product.Product shopProduct 
                = Shop.ManagerOfShopProducts.Build().TrackedProducts[product.Id];
            shopProduct.Price += priceChange;
            return this;
        }
        public ShopProductPriceBuider ChangeOn(string productId, float priceChange)
        {
            Product.Product shopProduct 
                = Shop.ManagerOfShopProducts.Build().TrackedProducts[productId];
            shopProduct.Price += priceChange;
            return this;
        }
    }
}