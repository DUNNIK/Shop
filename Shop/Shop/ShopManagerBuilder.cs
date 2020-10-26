using Shop.Shop.Methods;

namespace Shop.Shop
{
    public class ShopManagerBuilder
    {
        protected ShopManager Manager;

        public ShopManagerBuilder() => Manager = new ShopManager();
        public ShopManagerBuilder(ShopManager manager) => Manager = manager;

        public ShopManagerBuilder AddShop(OrdinaryShop ordinaryShop)
        {
            Manager.TrackedShops.Add(ordinaryShop.Id, ordinaryShop);
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