using System.Collections.Generic;

namespace Shop.Shop
{
    public class ShopManager
    {
        public Dictionary<string, OrdinaryShop> TrackedShops 
            = new Dictionary<string, OrdinaryShop>();
    }
}