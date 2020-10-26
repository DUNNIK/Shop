using System.Collections.Generic;

namespace Shop.Shop
{
    public class ShopManager
    {
        public readonly Dictionary<string, OrdinaryShop> TrackedShops 
            = new Dictionary<string, OrdinaryShop>();
    }
}