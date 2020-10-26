using System;

namespace Shop.Product
{
    public abstract class ProductBuilder
    {
        protected Product Product;
        protected ProductBuilder(){}
        protected ProductBuilder(Product product) => Product = product;
        public abstract ProductBuilder AddName(string name);
        public abstract ProductBuilder AddPrice(float price);
        public abstract ProductBuilder AddCount(float count);
        public abstract ProductBuilder AddId();
        public override string ToString() => Product.ToString();
        public Product Build() => Product;
        public static implicit operator Product(ProductBuilder builder) 
            => builder.Product;
    }

    public class ProductKilogramsBuilder : ProductBuilder
    {
        public ProductKilogramsBuilder() => Product = new ProductKilograms();
        public override ProductBuilder AddName(string name)
        {
            Product.Name = name;
            return this;
        }
        public override ProductBuilder AddPrice(float price)
        {
            Product.Price = price;
            return this;
        }
        public override ProductBuilder AddCount(float count)
        {
            Product.Count = count;
            return this;
        }
        public override ProductBuilder AddId()
        {
            Product.Id = Guid.NewGuid().ToString();
            return this;
        }
    }

    public class ProductPiecesBuilder : ProductBuilder
    {
        public ProductPiecesBuilder() => Product = new ProductPieces();
        public override ProductBuilder AddName(string name)
        {
            Product.Name = name;
            return this;
        }

        public override ProductBuilder AddPrice(float price)
        {
            Product.Price = price;
            return this;
        }

        public override ProductBuilder AddCount(float count)
        {
            Product.Count = count;
            return this;
        }

        public override ProductBuilder AddId()
        {
            Product.Id = Guid.NewGuid().ToString();
            return this;
        }
    }
}