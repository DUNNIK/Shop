using System;

namespace Shop.Product
{
    public abstract class ProductBuilder
    {
        protected Product Product;
        public ProductBuilder(){}
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

    public class ProductKilogramsBuider : ProductBuilder
    {
        public ProductKilogramsBuider() => Product = new ProductKilogramms();
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

    public class ProductPiecesBuider : ProductBuilder
    {
        public ProductPiecesBuider() => Product = new ProductPieces();
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