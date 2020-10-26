using System.Collections.Generic;

namespace Shop.Product
{
    public class ProductManager
    {
        public readonly Dictionary<string, Product> TrackedProducts 
            = new Dictionary<string, Product>();
    }
}