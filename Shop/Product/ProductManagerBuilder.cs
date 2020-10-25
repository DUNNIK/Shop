
namespace Shop.Product
{
    public class ProductManagerBuilder
    {
        public ProductManager Manager;

        public ProductManagerBuilder() => Manager = new ProductManager();
        public ProductManagerBuilder(ProductManager manager) 
            => Manager = manager;

        public ProductManagerBuilder AddProduct(Product product)
        {
            Manager.TrackedProducts.Add(product.Id, product);
            return this;
        }
        
        public ProductManager Build() => Manager;
        public static implicit operator 
            ProductManager(ProductManagerBuilder builder)
            => builder.Manager;
    }
}