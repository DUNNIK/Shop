using Shop.Exceptions;
using Shop.Product;

namespace Shop.Shop
{
    public abstract class Shop
    {
        private string _id;
        private string _name;
        public readonly ProductManagerBuilder ManagerOfShopProducts;

        protected Shop() => 
            ManagerOfShopProducts = new ProductManagerBuilder();
        public Shop(string str){}
        public string Name
        {
            get => _name;
            set
            {
                if (_name != null) throw new ChangeNameException();

                _name = value;
            }
        }

        public string Id
        {
            get => _id;
            set
            {
                if (_id != null) throw new ChangeIdException();

                _id = value;
            }
        }

        public override string ToString()
        {
            return $@"Name: {Name}. Id: {Id}.";
        }
    }
    public class OrdinaryShop : Shop
    {
        public OrdinaryShop()
        {
        }

        public OrdinaryShop(string str) : base(str)
        {
        }
        
        public string ProductsToString()
        {
            string str = "";
            foreach (var products 
                in ManagerOfShopProducts.Build().TrackedProducts)
            {
                str += products.Value.ToString();
                str += "\n";
            }

            return str;
        }
    }
}