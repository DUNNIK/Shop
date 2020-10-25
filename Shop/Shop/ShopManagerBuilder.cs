namespace Shop.Shop
{
    public class ShopManagerBuilder
    {
        public ShopManager Manager;

        public ShopManagerBuilder() => Manager = new ShopManager();
        public ShopManagerBuilder(ShopManager manager) => Manager = manager;

        public ShopManagerBuilder AddShop(Shop shop)
        {
            Manager.TrackedShops.Add(shop.Id, shop);
            return this;
        }
        
        public ShopManager Build() => Manager;
        public static implicit operator 
            ShopManager(ShopManagerBuilder builder)
            => builder.Manager;
        public FindShopWithCheapestProduct ShopWithCheapestProduct
            => new FindShopWithCheapestProduct(Manager);
        public CheapestBuyProducts CheapestBuyProducts 
            => new CheapestBuyProducts(Manager);
    }
}