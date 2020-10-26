using System;
using System.Collections.Generic;
using Shop.Exeptions;
using Shop.Product;
using Shop.Shop;
using Shop.Shop.Methods;
using static System.Console;

namespace Shop
{
    internal class Program
    {
        private static void Main()
        {
            var apple = new ProductKilogramsBuider();
            apple.AddId().AddName("Apple").AddCount(300)
                .AddPrice((float) 56.35643);
            var chocolate = new ProductPiecesBuider();
            chocolate.AddId().AddName("Chocolate").AddCount(1000);
            var oranges = new ProductPiecesBuider();
            oranges.AddId().AddName("Orange").AddCount(120);
            var cucumbers = new ProductKilogramsBuider();
            cucumbers.AddId().AddName("Cucumber").AddCount((float) 325.4);
            var tomatoes = new ProductKilogramsBuider();
            tomatoes.AddId().AddName("Tomato").AddCount(50)
                .AddPrice(100);
            var socks = new ProductPiecesBuider();
            socks.AddId().AddName("Socks").AddCount(20);
            var bottleOfWater = new ProductPiecesBuider();
            bottleOfWater.AddId().AddName("Bottle of water").AddCount(120);
            var vodka = new ProductPiecesBuider();
            vodka.AddId().AddName("Vodka").AddCount(300);
            var sausage = new ProductPiecesBuider();
            sausage.AddId().AddName("Sausage").AddCount(120);
            var cheese = new ProductPiecesBuider();
            cheese.AddId().AddName("Cheese").AddCount(120);
            
            var allProducts = new ProductManagerBuilder();
            allProducts.AddProduct(apple).AddProduct(chocolate).AddProduct(oranges)
                .AddProduct(cucumbers).AddProduct(tomatoes).AddProduct(socks)
                .AddProduct(bottleOfWater).AddProduct(vodka).AddProduct(sausage)
                .AddProduct(cheese);
            
            var shopMagnit = new OrdinaryShopBuilder();
            shopMagnit.AddId().AddName("Magnit")
                .AddProduct(apple).Count.New(apple, 200).Prices.New(apple, 47)
                .AddProduct(bottleOfWater).Count.ChangeOn(bottleOfWater, 45).Prices.New(bottleOfWater, 50)
                .AddProduct(sausage).Count.ChangeOn(sausage, 300).Prices.New(sausage, (float)299.9)
                .AddProduct(vodka).Count.ChangeOn(vodka, 100).Prices.ChangeOn(vodka, 300)
                .AddProduct(socks).Count.ChangeOn(socks, 10).Prices.New(socks,100)
                .AddProduct(tomatoes).Count.New(tomatoes, 200).Prices.New(tomatoes, 47)
                .AddProduct(cheese).Count.ChangeOn(cheese, 45).Prices.New(cheese, 50)
                .AddProduct(cucumbers).Count.ChangeOn(cucumbers, 300).Prices.New(cucumbers, (float)299.9)
                .AddProduct(oranges).Count.ChangeOn(oranges, 100).Prices.ChangeOn(oranges, 300);
            var shopFive = new OrdinaryShopBuilder();
            shopFive.AddId().AddName("Five")
                .AddProduct(apple).Count.New(apple, 600).Prices.New(apple, 10)
                .AddProduct(bottleOfWater).Count.ChangeOn(bottleOfWater, 50).Prices.New(bottleOfWater, 50)
                .AddProduct(sausage).Count.ChangeOn(sausage, 300).Prices.New(sausage, (float) 299.9)
                .AddProduct(vodka).Count.ChangeOn(vodka, 30).Prices.ChangeOn(vodka, 300)
                .AddProduct(socks).Count.ChangeOn(socks, 10).Prices.New(socks, 80)
                .AddProduct(chocolate).Count.New(chocolate, 24500).Prices.New(chocolate, 300)
                .AddProduct(cheese).Count.ChangeOn(cheese, 452).Prices.New(cheese, 500);
            var shopLenta = new OrdinaryShopBuilder();
            shopLenta.AddId().AddName("Lenta")
                .AddProduct(apple).Count.New(apple, 460).Prices.New(apple, 1)
                .AddProduct(bottleOfWater).Count.ChangeOn(bottleOfWater, 34).Prices.New(bottleOfWater, 65)
                .AddProduct(sausage).Count.ChangeOn(sausage, 34).Prices.New(sausage, (float) 299.9)
                .AddProduct(vodka).Count.ChangeOn(vodka, 24).Prices.ChangeOn(vodka, 800)
                .AddProduct(socks).Count.ChangeOn(socks, 563).Prices.New(socks, 767)
                .AddProduct(chocolate).Count.New(chocolate, 342).Prices.New(chocolate, 432)
                .AddProduct(cheese).Count.ChangeOn(cheese, 343).Prices.New(cheese, 300)
                .AddProduct(cucumbers).Count.ChangeOn(cucumbers, 7564).Prices.New(cucumbers, (float) 299.9)
                .AddProduct(oranges).Count.ChangeOn(oranges, 685).Prices.ChangeOn(oranges, 450);
            
            WriteLine("Demonstration of the search for the store where the product is the cheapest");
            WriteLine();
            var allShops = new ShopManagerBuilder();
            allShops.AddShop(shopMagnit).AddShop(shopFive).AddShop(shopLenta);
            foreach (var product in allProducts.Build().TrackedProducts)
            {
                WriteLine($"The store that has the cheapest {product.Value.Name}:");
                WriteLine(FindShopWithCheapestProduct.Find(product.Value.Id, allShops));
            }
            WriteLine("Demonstration of the search quantity of goods to buy at a given price");
            WriteLine();
            WriteLine(FindProductsForSpecifyAmount.Find(100, shopFive));
            WriteLine();
            WriteLine(FindProductsForSpecifyAmount.Find(200, shopLenta));
            WriteLine();
            WriteLine(FindProductsForSpecifyAmount.Find(150, shopMagnit));
            WriteLine();
            WriteLine("Demonstration of purchasing products from a list of products");
            WriteLine();
            try
            {
                WriteLine("The purchase cost " + shopLenta.BuyProducts.Buy(new Dictionary<string, int>()
                {
                    {apple.Build().Id, 4},
                    {oranges.Build().Id, 30},
                    {cheese.Build().Id, 70}
                }) + "$");
            }
            catch (BuyException e)
            {
                WriteLine(e.Message);
            }
            WriteLine();
            WriteLine("Finding a store where it is cheaper to buy the products you are looking for");
            WriteLine();
            try
            {
                WriteLine("The specified products are the cheapest to buy in " + allShops.CheapestBuyProducts.Find(
                    new Dictionary<string, int>()
                    {
                        {apple.Build().Id, 4},
                        {oranges.Build().Id, 30},
                        {cheese.Build().Id, 3},
                        {vodka.Build().Id, 10},
                        {cucumbers.Build().Id, 7}
                    }));
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
    }
}