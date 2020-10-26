using System;
using Shop.Exeptions;
using Shop.Product;
using Shop.Shop.Methods;

namespace Shop.Shop
{
    public class OrdinaryShopBuilder
    {
        protected OrdinaryShop OrdinaryShop;
        public OrdinaryShopBuilder() => OrdinaryShop = new OrdinaryShop();
        protected OrdinaryShopBuilder(OrdinaryShop ordinaryShop) => OrdinaryShop = ordinaryShop;

        public OrdinaryShopBuilder AddName(string name)
        {
            OrdinaryShop.Name = name;
            return this;
        }

        public OrdinaryShopBuilder AddId()
        {
            OrdinaryShop.Id = Guid.NewGuid().ToString();
            return this;
        }

        public OrdinaryShopBuilder AddProduct(string id, ProductManager allProducts)
        {
            try
            {
                Product.Product
                    product = allProducts.TrackedProducts[id].Clone();
                OrdinaryShop.ManagerOfShopProducts.AddProduct(product);
            }
            catch
            {
                throw new IdExeption();
            }
            return this;
        }

        public OrdinaryShopBuilder AddProduct(Product.Product product)
        {
            OrdinaryShop.ManagerOfShopProducts.AddProduct(product.Clone());
            return this;
        }

        public OrdinaryShopProductPriceBuider Prices => new OrdinaryShopProductPriceBuider(OrdinaryShop);
        public OrdinaryShopProductCountBuilder Count => new OrdinaryShopProductCountBuilder(OrdinaryShop);
        public FindProductsForSpecifyAmount SpecifyAmount 
            => new FindProductsForSpecifyAmount(OrdinaryShop);
        public BuyProducts BuyProducts => new BuyProducts(OrdinaryShop);
        public override string ToString() => OrdinaryShop.ToString();
        public OrdinaryShop Build() => OrdinaryShop;

        public static implicit operator OrdinaryShop(OrdinaryShopBuilder builder)
            => builder.OrdinaryShop;
    }

}