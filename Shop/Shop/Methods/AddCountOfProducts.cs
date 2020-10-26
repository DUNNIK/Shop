
namespace Shop.Shop.Methods
{
        public class OrdinaryShopProductCountBuilder : OrdinaryShopBuilder
    {
        public OrdinaryShopProductCountBuilder(OrdinaryShop ordinaryShop) : base(ordinaryShop){}
        
        public OrdinaryShopProductCountBuilder New(string productId, float newCount)
        {
            Product.Product product 
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[productId];
            product.Count = newCount;
            return this;
        }
        public OrdinaryShopProductCountBuilder New(Product.Product product, float newCount)
        {
            Product.Product shopProduct 
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[product.Id];
            shopProduct.Count = newCount;
            return this;
        }
        public OrdinaryShopProductCountBuilder ChangeOn(Product.Product product, 
            float countChange)
        {
            Product.Product shopProduct 
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[product.Id];
            shopProduct.Count += countChange;
            return this;
        }
        public OrdinaryShopProductCountBuilder ChangeOn(string productId, float countChange)
        {
            Product.Product shopProduct 
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[productId];
            shopProduct.Count += countChange;
            return this;
        }
    }
    public class OrdinaryShopProductPriceBuider : OrdinaryShopBuilder
    {
        public OrdinaryShopProductPriceBuider(OrdinaryShop ordinaryShop) : base(ordinaryShop){}

        public OrdinaryShopProductPriceBuider New(string productId, float newPrice)
        {
            Product.Product product 
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[productId];
            product.Price = newPrice;
            return this;
        }
        public OrdinaryShopProductPriceBuider New(Product.Product product, float newPrice)
        {
            Product.Product shopProduct 
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[product.Id];
            shopProduct.Price = newPrice;
            return this;
        }
        public OrdinaryShopProductPriceBuider ChangeOn(Product.Product product, 
            float priceChange)
        {
            Product.Product shopProduct 
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[product.Id];
            shopProduct.Price += priceChange;
            return this;
        }
        public OrdinaryShopProductPriceBuider ChangeOn(string productId, float priceChange)
        {
            Product.Product shopProduct 
                = OrdinaryShop.ManagerOfShopProducts.Build().TrackedProducts[productId];
            shopProduct.Price += priceChange;
            return this;
        }
    }
}