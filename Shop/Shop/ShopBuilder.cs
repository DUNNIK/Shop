using System;
using System.Collections.Generic;
using Shop.Exeptions;
using Shop.Product;

namespace Shop.Shop
{
    public class ShopBuilder
    {
        public Shop Shop;
        public ShopBuilder() => Shop = new Shop();
        protected ShopBuilder(Shop shop) => Shop = shop;

        public ShopBuilder AddName(string name)
        {
            Shop.Name = name;
            return this;
        }

        public ShopBuilder AddId()
        {
            Shop.Id = Guid.NewGuid().ToString();
            return this;
        }

        public ShopBuilder AddProduct(string id, ProductManager allProducts)
        {
            try
            {
                Product.Product
                    product = allProducts.TrackedProducts[id].Clone();
                Shop.ManagerOfShopProducts.AddProduct(product);
            }
            catch
            {
                throw new IdExeption();
            }
            return this;
        }

        public ShopBuilder AddProduct(Product.Product product)
        {
            Shop.ManagerOfShopProducts.AddProduct(product.Clone());
            return this;
        }

        public ShopProductPriceBuider Prices => new ShopProductPriceBuider(Shop);
        public ShopProductCountBuilder Count => new ShopProductCountBuilder(Shop);
        public FindProductsForSpecifyAmount SpecifyAmount 
            => new FindProductsForSpecifyAmount(Shop);
        public BuyProducts BuyProducts => new BuyProducts(Shop);
        public override string ToString() => Shop.ToString();
        public Shop Build() => Shop;

        public static implicit operator Shop(ShopBuilder builder)
            => builder.Shop;
    }

}