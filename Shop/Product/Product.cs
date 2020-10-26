using Shop.Exceptions;

namespace Shop.Product
{
    public abstract class Product
    {
        private float _price;

        private string _id;

        private string _name;
        public abstract Product Clone();
        public abstract bool IsPieces();
        public abstract bool IsKilograms();
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

        public abstract float Count { get; set; }

        public float Price
        {
            get => _price;
            set
            {
                float minCost = 0;
                if (value < minCost) throw new ValueException(); 

                _price = value;
            }
        }

        public override string ToString()
        {
            return $@"Name: {Name}. Id: {Id}. Cost: {Price}. Size: {Count}";
        }
    }
    public class ProductKilograms : Product
    {
        public override Product Clone()
        {
            Product clProduct = new ProductKilograms();
            clProduct.Id = Id;
            clProduct.Name = Name;
            clProduct.Price = 0;
            clProduct.Count = 0;
            return clProduct;
        }

        public override bool IsPieces()
        {
            return false;
        }

        public override bool IsKilograms()
        {
            return true;
        }

        public override float Count { get; set; }
    }
    public class ProductPieces : Product
    {
        private int _count;

        public override Product Clone()
        {
            Product clProduct = new ProductPieces();
            clProduct.Id = Id;
            clProduct.Name = Name;
            clProduct.Price = 0;
            clProduct.Count = 0;
            return clProduct;
        }

        public override bool IsPieces()
        {
            return true;
        }

        public override bool IsKilograms()
        {
            return false;
        }

        public override float Count
        {
            get => _count;
            set
            {
                if (!IsInt(value)) throw new ValueException();

                _count = (int) value;
            }
        }

        private bool IsInt(float value)
        {
            return value - (int) value == 0;
        }
    }
}