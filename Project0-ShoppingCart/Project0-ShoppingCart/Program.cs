using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp
{
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Name} - ${Price} ({Category})";
        }
    }

    class Cart
    {
        private List<Product> items = new List<Product>();
        private List<Product> _allProducts;
        private decimal discount = 0.10M;
        private decimal salesTaxRate = 0.08M;
        private DateTime _createdAt;
        private TimeSpan _expiryDuration;

        public Cart(List<Product> allProducts, TimeSpan expiryDuration)
        {
            _allProducts = allProducts;
            _createdAt = DateTime.Now;
            _expiryDuration = expiryDuration;
        }

        private void ShowRecommendations(Product addedProduct)
        {
            var recommendedProducts = _allProducts
                .Where(p => p.Category == addedProduct.Category && p.Name != addedProduct.Name)
                .Take(3)
                .ToList();

            if (recommendedProducts.Any())
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\t\t\t\t\tYou may also be interested in:");
                foreach (var recommendation in recommendedProducts)
                {
                    Console.WriteLine($"\t\t\t\t\t- {recommendation.Name} (${recommendation.Price})");
                }
                Console.ResetColor();
            }
        }

        public bool IsExpired()
        {
            return DateTime.Now > _createdAt + _expiryDuration;
        }

        public void ResetCartTimer()
        {
            _createdAt = DateTime.Now;
        }

        public TimeSpan GetRemainingTime()
        {
            DateTime expirationTime = _createdAt + _expiryDuration;
            return expirationTime - DateTime.Now;
        }

        public void AddProduct(Product product)
        {
            if (IsExpired())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour cart has expired. Please restart shopping.");
                Console.ResetColor();
                items.Clear();
            }
            else
            {
                items.Add(product);
                ResetCartTimer();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\t\t\t\t\t{product.Name} added to the cart.");
                ShowRecommendations(product);
                Console.ResetColor();
            }
        }

        public void RemoveProductByIndex(int index)
        {
            if (IsExpired())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour cart has expired. Please restart shopping.");
                Console.ResetColor();
                items.Clear();
                return;
            }

            if (index >= 0 && index < items.Count)
            {
                var product = items[index];
                items.RemoveAt(index);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\t\t\t\t\t{product.Name} removed from the cart.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tInvalid selection. Please choose a valid item number.");
                Console.ResetColor();
            }
        }

        public void ProductRecommendation()
        {
            if (IsExpired())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour cart has expired. Please restart shopping.");
                Console.ResetColor();
                items.Clear();
                return;
            }

            var recommendedProducts = _allProducts.Where(p => p.Price <= 800M).ToList();

            if (!recommendedProducts.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tSorry, no products are available for recommendation under $800.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t\t\t\t\tRecommended Products with a special discount:");

            foreach (var product in recommendedProducts)
            {
                decimal discountedPrice = product.Price * (1 - discount);
                Console.WriteLine($"\t\t\t\t\t- {product.Name} - Original Price: ${product.Price}, Discounted Price: ${discountedPrice:F2}");
            }

            Console.ResetColor();
        }

        public void ViewCartWithIndices()
        {
            if (IsExpired())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour cart has expired. Please restart shopping.");
                Console.ResetColor();
                items.Clear();
                return;
            }

            if (items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t\t\tYour cart is empty.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"\t\t\t\t\t{i + 1}. {items[i]}");
                }
                Console.ResetColor();

                TimeSpan remainingTime = GetRemainingTime();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"\t\t\t\t\tYou have {remainingTime.Minutes} minute(s) and {remainingTime.Seconds} second(s) until your cart expires.");
                Console.ResetColor();
            }
        }

        public int ItemsCount()
        {
            return items.Count;
        }

        public decimal CalculateTotal()
        {
            if (IsExpired())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour cart has expired. Please restart shopping.");
                Console.ResetColor();
                items.Clear();
                return 0;
            }

            decimal subtotal = items.Sum(p => p.Price);
            decimal discountAmount = subtotal * discount;
            decimal salesTax = (subtotal - discountAmount) * salesTaxRate;
            decimal total = subtotal - discountAmount + salesTax;



            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n");
            Console.WriteLine($"\t\t\t\t\tSubtotal: ${subtotal}");
            Console.WriteLine($"\t\t\t\t\tDiscount (10%): -${discountAmount}");
            Console.WriteLine($"\t\t\t\t\tSales Tax (8%): +${salesTax}");
            Console.WriteLine($"\t\t\t\t\tTotal: ${total}");
            Console.ResetColor();

            return total;
        }

        public void Checkout()
        {
            if (IsExpired())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour cart has expired. Please restart shopping.");
                Console.ResetColor();
                items.Clear();
                return;
            }

            if (items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour cart is empty, please add some products before checkout.");
                Console.ResetColor();
                return;
            }

            CalculateTotal();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t\t\t\tProceeding to checkout...");
            Console.WriteLine("\t\t\t\t\tThank you for your purchase!");
            Console.ResetColor();
            items.Clear();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan expiryDuration = TimeSpan.FromMinutes(10);

            DisplayWelcomeTitle();
            DisplayWelcome();
            Console.Title = "\t\t\t\t\tGroup 17 Shopping Cart Application";

            bool continueShopping = true;
            List<Product> allProducts = new List<Product>()
            {
                new Product("HP Spectre x360", 1300M, "Electronics"),
                new Product("Mechanical Keyboard", 120M, "Stationary"),
                new Product("OnePlus 11", 899M, "Electronics"),
                new Product("Apple Watch Series 7", 399M, "Electronics"),
                new Product("Kitchen Knife Set", 50M, "Kitchen Products"),
                new Product("Notebook", 10M, "Stationary"),
                new Product("Microwave", 100M, "Kitchen Products"),
                new Product("Painting Supplies", 25M, "Stationary"),
                new Product("Cookware Set", 150M, "Kitchen Products"),
                new Product("Spatula Set", 15M, "Utensils"),
                new Product("Paper Clips", 5M, "Office Supplies"),
                new Product("Stand Mixer", 200M, "Appliances"),
                new Product("Fountain Pen", 20M, "Writing Instruments"),
                new Product("Gel Pens", 10M, "Writing Instruments"),
                new Product("Stainless Steel Utensil Set", 30M, "Utensils"),
                new Product("Blender", 70M, "Appliances")
            };

            Cart cart = new Cart(allProducts, expiryDuration);

            while (continueShopping)
            {
                Console.Clear();
                Header();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n\t\t\t\t\t1. Add Product\n\t\t\t\t\t2. Remove Product\n\t\t\t\t\t3. View Cart\n\t\t\t\t\t4. Checkout\n\t\t\t\t\t5. Product Recommendation\n\t\t\t\t\t6. Exit");
                Console.ResetColor();

                string choice = GetValidInput("\t\t\t\t\tSelect an option: ", new string[] { "1", "2", "3", "4", "5", "6" });

                switch (choice)
                {
                    case "1":
                        AddProduct(cart);
                        break;

                    case "2":
                        RemoveProduct(cart);
                        break;

                    case "3":
                        cart.ViewCartWithIndices();
                        PauseScreen();
                        break;

                    case "4":
                        cart.Checkout();
                        continueShopping = false;
                        break;

                    case "5":
                        cart.ProductRecommendation();
                        PauseScreen();
                        break;

                    case "6":
                        continueShopping = false;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\t\t\t\t\tExiting the shopping cart. Goodbye!");
                        Console.ResetColor();
                        PauseScreen();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t\t\t\tInvalid option. Please try again.");
                        Console.ResetColor();
                        PauseScreen();
                        break;
                }
            }
        }

        static void AddProduct(Cart cart)
        {
            Console.Clear();
            Header();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t\t\t\t\tSelect a category to add a product:\n\t\t\t\t\t1. Electronics\n\t\t\t\t\t2. Kitchen Products\n\t\t\t\t\t3. Stationary\n\t\t\t\t\t4. Food Items\n\t\t\t\t\t5. Back");
            string categoryChoice = GetValidInput("\t\t\t\t\tSelect a category: ", new string[] { "1", "2", "3", "4" });

            switch (categoryChoice)
            {
                case "1":
                    ChooseElectronics(cart);
                    break;

                case "2":
                    ChooseKitchenProducts(cart);
                    break;

                case "3":
                    ChooseStationary(cart);
                    break;

                case "4":
                    ChooseFoodItems(cart);
                    break;
                case "5":
                    return;

                default:
                    Console.WriteLine("\t\t\t\t\tInvalid category choice.");
                    break;
            }
        }
        static void ChooseFoodItems(Cart cart)
        {
            Console.Clear();
            Header();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t\t\t\t\tSelect a subcategory:\n\t\t\t\t\t1. Fruits\n\t\t\t\t\t2. Vegetables\n\t\t\t\t\t3. Snacks\n\t\t\t\t\t4. Beverages\n\t\t\t\t\t5. Back\n\t\t\t\t\t6. Exit");
            string subcategoryChoice = GetValidInput("\t\t\t\t\tSelect a subcategory: ", new string[] { "1", "2", "3", "4", "5", "6" });

            switch (subcategoryChoice)
            {
                case "1":
                    DisplayAndAddProduct(cart, new List<Product>
            {
                new Product("Apple", 3M, "Fruits"),
                new Product("Banana", 1M, "Fruits"),
                new Product("Grapes", 4M, "Fruits"),
                new Product("Orange", 2.5M, "Fruits"),
                new Product("Mango", 5M, "Fruits"),
                   new Product("Pineapple", 3.5M, "Fruits"),
               new Product("Strawberries", 3M, "Fruits"),
               new Product("Blueberries", 4.5M, "Fruits"),
               new Product("Watermelon", 6M, "Fruits"),
               new Product("Kiwi", 2M, "Fruits"),
               new Product("Peach", 2.75M, "Fruits"),
               new Product("Plum", 1.5M, "Fruits"),
               new Product("Cherry", 5M, "Fruits"),
               new Product("Pomegranate", 4M, "Fruits"),
               new Product("Lemon", 1.25M, "Fruits")
            });
                    break;

                case "2":
                    DisplayAndAddProduct(cart, new List<Product>
            {
                new Product("Carrot", 1.5M, "Vegetables"),
                new Product("Broccoli", 3M, "Vegetables"),
                new Product("Lettuce", 2M, "Vegetables"),
                new Product("Potato", 1M, "Vegetables"),
                new Product("Tomato", 2M, "Vegetables"),
                  new Product("Spinach", 2.5M, "Vegetables"),
               new Product("Cucumber", 1.75M, "Vegetables"),
               new Product("Bell Pepper", 2.25M, "Vegetables"),
               new Product("Zucchini", 1.5M, "Vegetables"),
               new Product("Cauliflower", 3.5M, "Vegetables"),
               new Product("Onion", 0.75M, "Vegetables"),
               new Product("Garlic", 0.5M, "Vegetables"),
               new Product("Eggplant", 2.5M, "Vegetables"),
               new Product("Green Beans", 2M, "Vegetables"),
               new Product("Radish", 1M, "Vegetables")
            });
                    break;

                case "3":
                    DisplayAndAddProduct(cart, new List<Product>
            {
                new Product("Chips", 2M, "Snacks"),
                new Product("Chocolate Bar", 1.5M, "Snacks"),
                new Product("Popcorn", 3M, "Snacks"),
                new Product("Cookies", 4M, "Snacks"),
                new Product("Pretzels", 2.5M, "Snacks"),
                   new Product("Trail Mix", 3.5M, "Snacks"),
               new Product("Granola Bars", 2M, "Snacks"),
               new Product("Rice Cakes", 1.75M, "Snacks"),
               new Product("Beef Jerky", 5M, "Snacks"),
               new Product("Fruit Snacks", 1.25M, "Snacks"),
               new Product("Nut Butter Packets", 2.25M, "Snacks"),
               new Product("Pita Chips", 3M, "Snacks"),
               new Product("Seaweed Snacks", 1.5M, "Snacks"),
               new Product("Muffins", 2.75M, "Snacks"),
               new Product("Tortilla Chips", 2.5M, "Snacks")
            });
                    break;

                case "4":

                    DisplayAndAddProduct(cart, new List<Product>
            {
                new Product("Orange Juice", 3M, "Beverages"),
                new Product("Water Bottle", 1M, "Beverages"),
                new Product("Soda", 1.5M, "Beverages"),
                new Product("Milk", 2M, "Beverages"),
                new Product("Coffee", 5M, "Beverages"),
                   new Product("Iced Tea", 2.5M, "Beverages"),
               new Product("Lemonade", 3M, "Beverages"),
               new Product("Sparkling Water", 1.75M, "Beverages"),
               new Product("Energy Drink", 2.5M, "Beverages"),
               new Product("Coconut Water", 4M, "Beverages"),
               new Product("Protein Shake", 3.5M, "Beverages"),
               new Product("Herbal Tea", 2M, "Beverages"),
               new Product("Fruit Smoothie", 4.5M, "Beverages"),
               new Product("Hot Chocolate", 2.25M, "Beverages"),
               new Product("Almond Milk", 3M, "Beverages")
            });
                    break;

                case "5":
                    return; // Go back to adding products menu

                case "6":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\t\t\t\t\tExiting the shopping cart. Goodbye!");
                    Console.ResetColor();
                    Environment.Exit(0); // Exit program
                    break;

                default:
                    Console.WriteLine("\t\t\t\t\tInvalid subcategory choice.");
                    break;
            }
        }
        static void ChooseElectronics(Cart cart)
        {
            Console.Clear();
            Header();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t\t\t\t\tSelect a subcategory:\n\t\t\t\t\t1. Mobile Phones\n\t\t\t\t\t2. Mobile Phone Accessories\n\t\t\t\t\t3. Laptops\n\t\t\t\t\t4. Computer Accessories\n\t\t\t\t\t5. Smart Watches\n\t\t\t\t\t6. Back\n\t\t\t\t\t7. Exit");
            string subcategoryChoice = GetValidInput("\t\t\t\t\tSelect a subcategory: ", new string[] { "1", "2", "3", "4", "5", "6", "7" });

            switch (subcategoryChoice)
            {
                case "1":
                    ChooseMobilePhone(cart);
                    break;

                case "2":
                    ChooseMobilePhoneAccessory(cart);
                    break;

                case "3":
                    DisplayAndAddProduct(cart, new List<Product>
                    {
                        new Product("Dell XPS 13", 999M, "Laptops"),
                        new Product("HP Spectre x360", 1300M, "Laptops"),
                        new Product("MacBook Air", 999M, "Laptops"),
                        new Product("Lenovo ThinkPad X1", 1200M, "Laptops"),
                           new Product("Razer Blade 15", 1999M, "Laptops"),
                       new Product("Microsoft Surface Laptop 4", 999M, "Laptops"),
                       new Product("Acer Swift 3", 699M, "Laptops"),
                       new Product("Lenovo IdeaPad Flex 5", 649M, "Laptops"),
                       new Product("Dell Inspiron 15", 749M, "Laptops"),
                       new Product("HP Envy 13", 899M, "Laptops"),
                       new Product("LG Gram 14", 1499M, "Laptops"),
                       new Product("Alienware m15", 1999M, "Laptops"),
                       new Product("Samsung Galaxy Book Pro", 999M, "Laptops"),
                       new Product("Asus ROG Zephyrus G14", 1499M, "Laptops"),
                       new Product("HP Pavilion 15", 749M, "Laptops"),
                        new Product("Asus ZenBook 14", 849M, "Laptops"),
                    });
                    break;

                case "4":
                    DisplayAndAddProduct(cart, new List<Product>
                    {
                        new Product("Logitech Mouse", 25M, "Computer Accessories"),
                        new Product("USB Hub", 15M, "Computer Accessories"),
                        new Product("Mechanical Keyboard", 120M, "Computer Accessories"),
                        new Product("Laptop Stand", 40M, "Computer Accessories"),
                         new Product("Wireless Charger", 30M, "Computer Accessories"),
                       new Product("HDMI Cable", 12M, "Computer Accessories"),
                       new Product("Webcam", 50M, "Computer Accessories"),
                       new Product("Mouse Pad", 10M, "Computer Accessories"),
                       new Product("Noise-Canceling Headphones", 80M, "Computer Accessories"),
                       new Product("Portable Bluetooth Speaker", 45M, "Computer Accessories"),
                       new Product("Docking Station", 100M, "Computer Accessories"),
                       new Product("Keyboard Cleaner", 5M, "Computer Accessories"),
                       new Product("Surge Protector", 20M, "Computer Accessories"),
                       new Product("Screen Protector", 15M, "Computer Accessories"),
                       new Product("Microphone", 70M, "Computer Accessories"),
                        new Product("External Hard Drive", 60M, "Computer Accessories"),
                    });
                    break;

                case "5":
                    DisplayAndAddProduct(cart, new List<Product>
                    {
                        new Product("Apple Watch Series 7", 399M, "Smart Watches"),
                        new Product("Fitbit Charge 5", 149M, "Smart Watches"),
                        new Product("Galaxy Watch 4", 249M, "Smart Watches"),
                        new Product("Garmin Forerunner 245", 299M, "Smart Watches"),
                          new Product("Amazfit GTR 3", 199M, "Smart Watches"),
                       new Product("Huawei Watch GT 3", 249M, "Smart Watches"),
                       new Product("Suunto 7", 399M, "Smart Watches"),
                       new Product("Withings Steel HR", 179M, "Smart Watches"),
                       new Product("Fossil Gen 5", 249M, "Smart Watches"),
                       new Product("Garmin Venu Sq", 199M, "Smart Watches"),
                       new Product("Samsung Galaxy Watch Active 2", 249M, "Smart Watches"),
                       new Product("Amazfit Bip U Pro", 69M, "Smart Watches"),
                       new Product("Polar Vantage M", 299M, "Smart Watches"),
                       new Product("Skagen Falster 3", 275M, "Smart Watches"),
                       new Product("Mobvoi TicWatch E3", 199M, "Smart Watches"),
                        new Product("TicWatch Pro 3", 299M, "Smart Watches"),
                    });
                    break;

                case "6":
                    return; // Go back to adding products menu

                case "7":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\t\t\t\t\tExiting the shopping cart. Goodbye!");
                    Console.ResetColor();
                    Environment.Exit(0); // Exit program
                    break;

                default:
                    Console.WriteLine("\t\t\t\t\tInvalid subcategory choice.");
                    break;
            }
            PauseScreen();
        }

        static void ChooseKitchenProducts(Cart cart)
        {
            Console.Clear();
            Header();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t\t\t\t\tSelect a subcategory:\n\t\t\t\t\t1. Cookware\n\t\t\t\t\t2. Utensils\n\t\t\t\t\t3. Appliances\n\t\t\t\t\t4. Back\n\t\t\t\t\t5. Exit");
            string subcategoryChoice = GetValidInput("\t\t\t\t\tSelect a subcategory: ", new string[] { "1", "2", "3", "4", "5" });

            switch (subcategoryChoice)
            {
                case "1":
                    DisplayAndAddProduct(cart, new List<Product>
                    {
                        new Product("Cookware Set", 150M, "Cookware"),
                        new Product("Cast Iron Skillet", 45M, "Cookware"),
                         new Product("Non-Stick Frying Pan", 30M, "Cookware"),
                       new Product("Saucepan Set", 35M, "Cookware"),
                       new Product("Dutch Oven", 60M, "Cookware"),
                       new Product("Stock Pot", 40M, "Cookware"),
                       new Product("Wok", 28M, "Cookware"),
                       new Product("Roasting Pan", 32M, "Cookware"),
                       new Product("Grill Pan", 38M, "Cookware"),
                       new Product("Steamer Basket", 15M, "Cookware"),
                       new Product("Pressure Cooker", 70M, "Cookware"),
                       new Product("Oven Safe Bakeware Set", 50M, "Cookware"),
                       new Product("Paella Pan", 45M, "Cookware"),
                        new Product("Baking Sheet Set", 25M, "Cookware"),
                    });
                    break;

                case "2":
                    DisplayAndAddProduct(cart, new List<Product>
                    {
                        new Product("Silicone Baking Mat", 12M, "Utensils"),
                        new Product("Whisk", 8M, "Utensils"),
                       new Product("Measuring Cups", 10M, "Utensils"),
                       new Product("Spatula Set", 15M, "Utensils"),
                       new Product("Wooden Spoon Set", 9M, "Utensils"),
                       new Product("Can Opener", 6M, "Utensils"),
                       new Product("Peeler", 5M, "Utensils"),
                       new Product("Colander", 12M, "Utensils"),
                       new Product("Grater", 10M, "Utensils"),
                       new Product("Ladle", 7M, "Utensils"),
                       new Product("Rolling Pin", 11M, "Utensils"),
                       new Product("Pastry Brush", 4M, "Utensils"),
                        new Product("Kitchen Tongs", 7M, "Utensils"),
                    });
                    break;

                case "3":
                    DisplayAndAddProduct(cart, new List<Product>
                    {
                        new Product("Stand Mixer", 200M, "Appliances"),
                        new Product("Toaster Oven", 80M, "Appliances"),
                        new Product("Coffee Maker", 60M, "Appliances"),
                          new Product("Blender", 45M, "Appliances"),
                       new Product("Toaster", 25M, "Appliances"),
                       new Product("Electric Kettle", 30M, "Appliances"),
                       new Product("Rice Cooker", 40M, "Appliances"),
                       new Product("Food Processor", 70M, "Appliances"),
                       new Product("Microwave Oven", 90M, "Appliances"),
                       new Product("Air Fryer", 80M, "Appliances"),
                       new Product("Induction Cooktop", 65M, "Appliances"),
                       new Product("Stand Mixer", 120M, "Appliances"),
                       new Product("Deep Fryer", 55M, "Appliances"),
                       new Product("Juicer", 50M, "Appliances"),
                        new Product("Slow Cooker", 50M, "Appliances"),
                    });
                    break;

                case "4":
                    return; // Go back to adding products menu

                case "5":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\t\t\t\t\tExiting the shopping cart. Goodbye!");
                    Console.ResetColor();
                    Environment.Exit(0); // Exit program
                    break;

                default:
                    Console.WriteLine("\t\t\t\t\tInvalid subcategory choice.");
                    break;
            }
        }

        static void ChooseStationary(Cart cart)
        {
            Console.Clear();
            Header();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t\t\t\t\tSelect a subcategory:\n\t\t\t\t\t1. Art Supplies\n\t\t\t\t\t2. Office Supplies\n\t\t\t\t\t3. Writing Instruments\n\t\t\t\t\t4. Back\n\t\t\t\t\t5. Exit");
            string subcategoryChoice = GetValidInput("\t\t\t\t\tSelect a subcategory: ", new string[] { "1", "2", "3", "4", "5" });

            switch (subcategoryChoice)
            {
                case "1":
                    DisplayAndAddProduct(cart, new List<Product>
                    {
                        new Product("Painting Supplies", 25M, "Art Supplies"),
                        new Product("Canvas", 15M, "Art Supplies"),
                        new Product("Watercolor Set", 30M, "Art Supplies"),
                        new Product("Sketch Pad", 8M, "Art Supplies"),
                         new Product("Acrylic Paint Set", 25M, "Art Supplies"),
                       new Product("Watercolor Paint Set", 18M, "Art Supplies"),
                       new Product("Charcoal Pencils", 10M, "Art Supplies"),
                       new Product("Canvas Panels", 15M, "Art Supplies"),
                       new Product("Oil Pastels", 12M, "Art Supplies"),
                       new Product("Drawing Pencils", 7M, "Art Supplies"),
                       new Product("Palette Knives", 8M, "Art Supplies"),
                       new Product("Easel", 30M, "Art Supplies"),
                       new Product("Blending Stumps", 5M, "Art Supplies"),
                       new Product("Artist Palette", 6M, "Art Supplies"),
                       new Product("Drawing Paper", 10M, "Art Supplies"),
                        new Product("Brush Set", 20M, "Art Supplies"),
                    });
                    break;

                case "2":
                    DisplayAndAddProduct(cart, new List<Product>
                    {

                            new Product("Stapler", 15M, "Office Supplies"),
                            new Product("Post-it Notes", 10M, "Office Supplies"),
                            new Product("Highlighters", 12M, "Office Supplies"),
                            new Product("Paper Clips", 3M, "Office Supplies"),
                           new Product("Desk Organizer", 15M, "Office Supplies"),
                           new Product("Sticky Notes", 5M, "Office Supplies"),
                           new Product("Push Pins", 4M, "Office Supplies"),
                           new Product("File Folders", 8M, "Office Supplies"),
                           new Product("Whiteboard Eraser", 7M, "Office Supplies"),
                           new Product("Scissors", 6M, "Office Supplies"),
                           new Product("Tape Dispenser", 9M, "Office Supplies"),
                           new Product("Clipboard", 6M, "Office Supplies"),
                           new Product("Correction Tape", 3M, "Office Supplies"),
                           new Product("Binder Clips", 6M, "Office Supplies"),
                    });
                    break;

                case "3":
                    DisplayAndAddProduct(cart, new List<Product>
                    {
                        new Product("Fountain Pen", 20M, "Writing Instruments"),
                        new Product("Gel Pens", 10M, "Writing Instruments"),
                        new Product("Ballpoint Pen", 1M, "Writing Instruments"),
                        new Product("Colored Pencils", 15M, "Writing Instruments"),
                        new Product("Highlighter Set", 10M, "Writing Instruments"),
                        new Product("Ballpoint Pen Pack", 8M, "Writing Instruments"),
                        new Product("Fountain Pencil", 25M, "Writing Instruments"),
                        new Product("Mechanical Pencil", 5M, "Writing Instruments"),
                        new Product("Gel Pen Set", 14M, "Writing Instruments"),
                        new Product("Calligraphy Pen Set", 20M, "Writing Instruments"),
                        new Product("Fine Line Pen Set", 18M, "Writing Instruments"),
                        new Product("Permanent Marker Set", 15M, "Writing Instruments"),
                        new Product("Whiteboard Markers", 12M, "Writing Instruments"),
                        new Product("Brush Pen Set", 22M, "Writing Instruments"),
                        new Product("Erasable Pen Set", 10M, "Writing Instruments"),
                        new Product("Colored Gel Pens", 16M, "Writing Instruments"),
                        new Product("Marker Set", 12M, "Writing Instruments"),
                    });
                    break;

                case "4":
                    return; // Go back to adding products menu

                case "5":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\t\t\t\t\tExiting the Shopping Cart. Goodbye!");
                    Console.ResetColor();
                    Environment.Exit(0); // Exit program
                    break;

                default:
                    Console.WriteLine("\t\t\t\t\tInvalid Subcategory Choice.");
                    break;
            }
        }

        static void RemoveProduct(Cart cart)
        {
            cart.ViewCartWithIndices();
            if (cart.ItemsCount() > 0)
            {
                int index = GetValidIndex(cart.ItemsCount(), "\t\t\t\t\tSelect the Product number to Remove: ");
                cart.RemoveProductByIndex(index - 1); // Convert to 0-based index
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tYour Cart is Empty. No Products to Remove.");
                Console.ResetColor();
            }
            PauseScreen();
        }

        static void DisplayAndAddProduct(Cart cart, List<Product> products)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t\tSelect a product to add to your cart:");
            Console.ResetColor();

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"\t\t\t\t\t{i + 1}. {products[i]}");
            }

            Console.WriteLine($"\t\t\t\t\t{products.Count + 1}. Back");
            Console.WriteLine($"\t\t\t\t\t{products.Count + 2}. Exit");

            int productChoice = GetValidIndex(products.Count + 2, "\t\t\t\t\tSelect a product: ");

            if (productChoice == products.Count + 1)
            {
                return; // Go back to the previous menu
            }
            else if (productChoice == products.Count + 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\t\t\t\t\tExiting the Shopping Cart. Goodbye!!!");
                Console.ResetColor();
                Environment.Exit(0); // Exit program
            }
            else
            {
                int quantity = GetValidQuantity("\t\t\t\t\tEnter the quantity (1-100): ");

                for (int i = 0; i < quantity; i++)
                {
                    cart.AddProduct(products[productChoice - 1]);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\t\t\t\t\t\nSuccessfully added {quantity} unit(s) of {products[productChoice - 1].Name} to your cart.");
                Console.ResetColor();

                TimeSpan remainingTime = cart.GetRemainingTime();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\t\t\t\tAlert!!!\nYou have {remainingTime.Minutes} minute(s) and {remainingTime.Seconds} second(s) until your cart expires.");
                Console.ResetColor();
            }
        }

        static int GetValidQuantity(string prompt)
        {
            int quantity;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 1 && quantity <= 100)
                {
                    return quantity;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t\t\tInvalid input. Quantity must be between 1 and 100.");
                    Console.ResetColor();
                }
            }
        }

        static string GetValidInput(string prompt, string[] validOptions)
        {
            int attempts = 3;
            while (attempts > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(prompt);
                Console.ResetColor();
                string input = Console.ReadLine().ToLower();
                if (validOptions.Contains(input))
                {
                    return input;
                }

                attempts--;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\t\t\t\tInvalid input. {attempts} attempts remaining.");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\tToo many invalid attempts. Exiting the program.");
            Console.ResetColor();
            Environment.Exit(0);
            return null;
        }

        static int GetValidIndex(int maxIndex, string prompt)
        {
            int attempts = 3;
            while (attempts > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(prompt);
                Console.ResetColor();
                if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= maxIndex)
                {
                    return index;
                }

                attempts--;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\t\t\t\tInvalid selection. {attempts} attempts remaining.");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\tToo many invalid attempts. Exiting the program.");
            Console.ResetColor();
            Environment.Exit(0);
            return -1;
        }

        static void PauseScreen()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t\t\tPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey(true);
        }

        static void Header()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"   




                                                  ____  _    _   ___   ____   ____   ___   _   _   ____     ____     _     ____   _____  
                                                 / ___|| |  | | / _ \ |  _ \ |  _ \ |_ _| | \ | | / ___|   / ___|   / \   |  _ \ |_   _|
                                                 \___ \| |__| || | | || |_) || |_) | | |  |  \| || |  _   | |      / _ \  | |_) |  | |
                                                  ___) |  __  || |_| ||  __/ |  __/  | |  | . ` || |_| |  | |___  / ___ \ |  _ <   | |
                                                 |____/|_|  |_| \___/ |_|    |_|    |___| |_|\\_| \____|   \____|/_/   \_\|_| \_\  |_|   



                     ");


        }
        static void DisplayWelcomeTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"   
                                     

 

                                      ____  _    _   ___   ____   ____   ___   _   _   ____     ____     _     ____   _____    ____ _    __  ____  _____  _____   __  __  
                                     / ___|| |  | | / _ \ |  _ \ |  _ \ |_ _| | \ | | / ___|   / ___|   / \   |  _ \ |_   _|  / ___ \\  / / / ___||_   _|| ____| |  \/  | 
                                     \___ \| |__| || | | || |_) || |_) | | |  |  \| || |  _   | |      / _ \  | |_) |  | |    \___ \ \ V /  \___ \  | |  |  _|   | |\/| |
                                      ___) |  __  || |_| ||  __/ |  __/  | |  | . ` || |_| |  | |___  / ___ \ |  _ <   | |     ___)   \_/    ___)   | |  | |___  | |  | | 
                                     |____/|_|  |_| \___/ |_|    |_|    |___| |_|\\_| \____|   \____|/_/   \_\|_| \_\  |_|    |____/  |_|   |____/  |_|  |_____| |_|  |_| 
                                                                                                                                        
   
  

      
");

            PauseScreen();
        }
        static void ChooseMobilePhone(Cart cart)
        {

            Console.Clear();
            Header();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t\t\t\t\tChoose a mobile phone brand:\n\t\t\t\t\t1. Samsung\n\t\t\t\t\t2. Apple\n\t\t\t\t\t3. Xiaomi\n\t\t\t\t\t4. Huawei\n\t\t\t\t\t5. OnePlus\n\t\t\t\t\t6. Back\n\t\t\t\t\t7. Exit");
            Console.ResetColor();
            string brandChoice = GetValidInput("\t\t\t\t\tSelect a brand: ", new string[] { "1", "2", "3", "4", "5", "6", "7" });

            if (brandChoice == "6")
                return;
            if (brandChoice == "7")
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\t\t\t\t\tExiting the shopping cart. Goodbye!");
                Console.ResetColor();
                Environment.Exit(0);
            }

            List<Product> mobilePhones = new List<Product>();

            switch (brandChoice)
            {
                case "1":
                    mobilePhones.AddRange(new List<Product>
                {
                    new Product("Samsung Galaxy S24 Ultra", 1299M, "Mobile Phones"),
                    new Product("Samsung Galaxy S24", 1099M, "Mobile Phones"),
                    new Product("Samsung Galaxy Z Fold 6", 1999M, "Mobile Phones"),
                    new Product("Samsung Galaxy Z Flip 6", 1299M, "Mobile Phones"),
                    new Product("Samsung Galaxy A74", 499M, "Mobile Phones"),
                    new Product("Samsung Galaxy A54", 399M, "Mobile Phones"),
                    new Product("Samsung Galaxy S23", 999M, "Mobile Phones"),
                    new Product("Samsung Galaxy S22", 799M, "Mobile Phones"),
                    new Product("Samsung Galaxy S21", 699M, "Mobile Phones"),
                    new Product("Samsung Galaxy S20", 599M, "Mobile Phones")
                });
                    break;

                case "2":
                    mobilePhones.AddRange(new List<Product>
                {
                    new Product("iPhone 16 Pro Max", 1499M, "Mobile Phones"),
                    new Product("iPhone 16 Pro", 1399M, "Mobile Phones"),
                    new Product("iPhone 16", 1299M, "Mobile Phones"),
                    new Product("iPhone 16 Plus", 1199M, "Mobile Phones"),
                    new Product("iPhone 15 Pro Max", 1299M, "Mobile Phones"),
                    new Product("iPhone 15 Pro", 1199M, "Mobile Phones"),
                    new Product("iPhone 15", 1099M, "Mobile Phones"),
                    new Product("iPhone 15 Plus", 999M, "Mobile Phones"),
                    new Product("iPhone 14 Pro Max", 1199M, "Mobile Phones"),
                    new Product("iPhone 14 Pro", 1099M, "Mobile Phones")
                });
                    break;

                case "3":
                    mobilePhones.AddRange(new List<Product>
                {
                    new Product("Xiaomi 14 Pro", 999M, "Mobile Phones"),
                    new Product("Xiaomi 14", 899M, "Mobile Phones"),
                    new Product("Xiaomi 13 Pro", 899M, "Mobile Phones"),
                    new Product("Xiaomi 13", 799M, "Mobile Phones"),
                    new Product("Xiaomi 12 Pro", 699M, "Mobile Phones"),
                    new Product("Xiaomi 12", 599M, "Mobile Phones"),
                    new Product("Xiaomi 11 Pro", 499M, "Mobile Phones"),
                    new Product("Xiaomi 11", 399M, "Mobile Phones"),
                    new Product("Xiaomi Mi 10 Pro", 599M, "Mobile Phones"),
                    new Product("Xiaomi Mi 10", 499M, "Mobile Phones")
                });
                    break;

                case "4":
                    mobilePhones.AddRange(new List<Product>
                {
                    new Product("Huawei Mate 60 Pro", 1099M, "Mobile Phones"),
                    new Product("Huawei Mate 60", 999M, "Mobile Phones"),
                    new Product("Huawei P60 Pro", 899M, "Mobile Phones"),
                    new Product("Huawei P60", 799M, "Mobile Phones"),
                    new Product("Huawei P50 Pro", 699M, "Mobile Phones"),
                    new Product("Huawei P50", 599M, "Mobile Phones"),
                    new Product("Huawei Nova 11 Pro", 499M, "Mobile Phones"),
                    new Product("Huawei Nova 11", 399M, "Mobile Phones"),
                    new Product("Huawei Nova 10 Pro", 299M, "Mobile Phones"),
                    new Product("Huawei Nova 10", 199M, "Mobile Phones")
                });
                    break;

                case "5":
                    mobilePhones.AddRange(new List<Product>
                {
                    new Product("OnePlus 12 Pro", 1099M, "Mobile Phones"),
                    new Product("OnePlus 11", 899M, "Mobile Phones"),
                    new Product("OnePlus 10 Pro", 799M, "Mobile Phones"),
                    new Product("OnePlus 12", 999M, "Mobile Phones"),
                    new Product("OnePlus 10T", 699M, "Mobile Phones"),
                    new Product("OnePlus 9 Pro", 599M, "Mobile Phones"),
                    new Product("OnePlus 9", 499M, "Mobile Phones"),
                    new Product("OnePlus 8 Pro", 399M, "Mobile Phones"),
                    new Product("OnePlus 8T", 349M, "Mobile Phones"),
                    new Product("OnePlus 8", 299M, "Mobile Phones")
                });
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t\t\tInvalid brand choice.");
                    Console.ResetColor();
                    break;
            }

            DisplayAndAddProduct(cart, mobilePhones);
        }
        static void ChooseMobilePhoneAccessory(Cart cart)
        {
            Console.Clear();
            Header();
            Console.WriteLine("\t\t\t\t\tSelect a subcategory for mobile phone accessories:\n\t\t\t\t\t1. Samsung Accessories\n\t\t\t\t\t2. iPhone Accessories\n\t\t\t\t\t3. Xiaomi Accessories\n\t\t\t\t\t4. Huawei Accessories\n\t\t\t\t\t5. OnePlus Accessories\n\t\t\t\t\t6. Charging Cables & Adapters\n\t\t\t\t\t7. Back\n\t\t\t\t\t8. Exit");
            string categoryChoice = GetValidInput("\t\t\t\t\t\t\t\t\t\tSelect a subcategory: ", new string[] { "1", "2", "3", "4", "5", "6", "7", "8" });
            switch (categoryChoice)
            {
                case "1":
                    List<Product> samsungAccessories = new List<Product>
            {
                new Product("Samsung Wireless Charger", 49M, "Samsung Accessories"),
                new Product("Samsung Phone Case", 29M, "Samsung Accessories"),
                new Product("Samsung Screen Protector", 19M, "Samsung Accessories"),
                 new Product("Samsung Fast Charger", 35M, "Samsung Accessories"),
               new Product("Samsung Galaxy Buds", 149M, "Samsung Accessories"),
               new Product("Samsung USB-C Cable", 12M, "Samsung Accessories"),
               new Product("Samsung Leather Case", 39M, "Samsung Accessories"),
               new Product("Samsung Tempered Glass Screen Protector", 18M, "Samsung Accessories"),
               new Product("Samsung Car Charger", 24M, "Samsung Accessories"),
               new Product("Samsung Gaming Controller", 59M, "Samsung Accessories"),
               new Product("Samsung Multi-Device Charging Station", 45M, "Samsung Accessories"),
               new Product("Samsung Smartwatch Charger", 15M, "Samsung Accessories"),
               new Product("Samsung Portable Power Bank", 39M, "Samsung Accessories")
            };
                    DisplayAndAddProduct(cart, samsungAccessories);
                    break;

                case "2":
                    List<Product> iphoneAccessories = new List<Product>
            {
                  new Product("iPhone Fast Charger", 29M, "iPhone Accessories"),
                   new Product("iPhone Leather Wallet Case", 49M, "iPhone Accessories"),
                   new Product("iPhone AirPods Pro", 249M, "iPhone Accessories"),
                   new Product("iPhone Lightning to USB Cable", 19M, "iPhone Accessories"),
                   new Product("iPhone Tempered Glass Screen Protector", 15M, "iPhone Accessories"),
                   new Product("iPhone Wireless Charging Pad", 34M, "iPhone Accessories"),
                   new Product("iPhone Car Charger", 25M, "iPhone Accessories"),
                   new Product("iPhone Gaming Controller", 59M, "iPhone Accessories"),
                   new Product("iPhone Multi-Device Charging Station", 39M, "iPhone Accessories"),
                   new Product("iPhone Selfie Ring Light", 22M, "iPhone Accessories")
            };
                    DisplayAndAddProduct(cart, iphoneAccessories);
                    break;

                case "3":
                    List<Product> xiaomiAccessories = new List<Product>
            {
                  new Product("Xiaomi Power Bank", 25M, "Xiaomi Accessories"),
                   new Product("Xiaomi Car Charger", 20M, "Xiaomi Accessories"),
                   new Product("Xiaomi USB-C Cable", 10M, "Xiaomi Accessories"),
                   new Product("Xiaomi Bluetooth Earbuds", 45M, "Xiaomi Accessories"),
                   new Product("Xiaomi Tempered Glass Screen Protector", 12M, "Xiaomi Accessories"),
                   new Product("Xiaomi Fitness Tracker", 40M, "Xiaomi Accessories"),
                   new Product("Xiaomi Leather Wallet Case", 30M, "Xiaomi Accessories"),
                   new Product("Xiaomi Fast Charger", 22M, "Xiaomi Accessories"),
                   new Product("Xiaomi Gaming Trigger", 14M, "Xiaomi Accessories"),
                   new Product("Xiaomi Smart Band", 50M, "Xiaomi Accessories")
            };
                    DisplayAndAddProduct(cart, xiaomiAccessories);
                    break;

                case "4":
                    List<Product> huaweiAccessories = new List<Product>
            {
                new Product("Huawei Wireless Charger", 45M, "Huawei Accessories"),
                new Product("Huawei Phone Case", 22M, "Huawei Accessories"),
                new Product("Huawei Screen Protector", 17M, "Huawei Accessories"),
                  new Product("OnePlus Car Charger", 30M, "OnePlus Accessories"),
               new Product("OnePlus Power Bank", 40M, "OnePlus Accessories"),
               new Product("OnePlus Bluetooth Earbuds", 60M, "OnePlus Accessories"),
               new Product("OnePlus USB-C Cable", 12M, "OnePlus Accessories"),
               new Product("OnePlus Leather Wallet Case", 35M, "OnePlus Accessories"),
               new Product("OnePlus Fast Charger", 25M, "OnePlus Accessories"),
               new Product("OnePlus Gaming Triggers", 15M, "OnePlus Accessories"),
               new Product("OnePlus Fitness Band", 50M, "OnePlus Accessories"),
               new Product("OnePlus Travel Adapter", 18M, "OnePlus Accessories"),
               new Product("OnePlus Tempered Glass Screen Protector", 22M, "OnePlus Accessories")
            };
                    DisplayAndAddProduct(cart, huaweiAccessories);
                    break;

                case "5":
                    List<Product> oneplusAccessories = new List<Product>
            {
                new Product("OnePlus Wireless Charger", 50M, "OnePlus Accessories"),
                new Product("OnePlus Phone Case", 27M, "OnePlus Accessories"),
                new Product("OnePlus Screen Protector", 20M, "OnePlus Accessories"),
                new Product("OnePlus Warp Charge 30W Charger", 35M, "OnePlus Accessories"),
               new Product("OnePlus USB-C to HDMI Adapter", 18M, "OnePlus Accessories"),
               new Product("OnePlus Bluetooth Earbuds", 60M, "OnePlus Accessories"),
               new Product("OnePlus Tempered Glass Screen Protector", 15M, "OnePlus Accessories"),
               new Product("OnePlus Car Charger", 22M, "OnePlus Accessories"),
               new Product("OnePlus Smart Watch", 199M, "OnePlus Accessories"),
               new Product("OnePlus Power Bank (10000mAh)", 30M, "OnePlus Accessories"),
               new Product("OnePlus Protective Flip Cover", 25M, "OnePlus Accessories"),
               new Product("OnePlus Gaming Triggers", 15M, "OnePlus Accessories"),
               new Product("OnePlus Wireless Neckband", 45M, "OnePlus Accessories")
            };
                    DisplayAndAddProduct(cart, oneplusAccessories);
                    break;

                case "6":
                    ChooseChargingCablesAndAdapters(cart);
                    break;

                case "7":
                    return;

                case "8":
                    Console.WriteLine("\t\t\t\t\tExiting the shopping cart. Goodbye!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("\t\t\t\t\tInvalid subcategory choice.");
                    break;
            }
        }
        static void ChooseChargingCablesAndAdapters(Cart cart)
        {
            Console.Clear();
            Header();
            Console.WriteLine("\t\t\t\t\tSelect a type of charging cable or adapter:\n\t\t\t\t\t1. Type-C Cables\n\t\t\t\t\t2. Micro USB Cables\n\t\t\t\t\t3. Lightning USB Cables\n\t\t\t\t\t4. Mini USB Cables\n\t\t\t\t\t5. Adapters\n\t\t\t\t\t6. Back\n\t\t\t\t\t7. Exit");
            string cableChoice = GetValidInput("\t\t\t\t\tSelect a type: ", new string[] { "1", "2", "3", "4", "5", "6", "7" });

            switch (cableChoice)
            {
                case "1":
                    List<Product> typeCCables = new List<Product>
            {
                new Product("Type-C Fast Charging Cable (USB 3.0)", 15M, "Charging Cables & Adapters"),
                new Product("Type-C Standard Charging Cable (USB 2.0)", 10M, "Charging Cables & Adapters"),
                  new Product("Type-C Braided Charging Cable", 12M, "Charging Cables & Adapters"),
                   new Product("Type-C to Type-C Cable (6FT)", 14M, "Charging Cables & Adapters"),
                   new Product("Type-C to HDMI Cable", 25M, "Charging Cables & Adapters"),
                   new Product("USB-C Power Delivery Charger", 20M, "Charging Cables & Adapters"),
                   new Product("USB-C Multi-Port Adapter", 30M, "Charging Cables & Adapters"),
                   new Product("USB-C to DisplayPort Adapter", 22M, "Charging Cables & Adapters"),
                   new Product("Type-C to Micro USB Adapter (2-Pack)", 8M, "Charging Cables & Adapters"),
                   new Product("USB-C Car Charger", 18M, "Charging Cables & Adapters"),
                   new Product("Type-C Magnetic Charging Cable", 16M, "Charging Cables & Adapters"),
                   new Product("Type-C Data Transfer Cable", 12M, "Charging Cables & Adapters")
            };
                    DisplayAndAddProduct(cart, typeCCables);
                    break;

                case "2":
                    List<Product> microUSBCables = new List<Product>
            {
                new Product("Micro USB Fast Charging Cable (USB 3.0)", 12M, "Charging Cables & Adapters"),
                new Product("Micro USB Standard Charging Cable (USB 2.0)", 8M, "Charging Cables & Adapters"),
                 new Product("Short Micro USB Cable (3FT)", 6M, "Charging Cables & Adapters"),
               new Product("Long Micro USB Cable (10FT)", 15M, "Charging Cables & Adapters"),
               new Product("Micro USB 2-in-1 Charging Cable", 10M, "Charging Cables & Adapters"),
               new Product("Heavy-Duty Micro USB Cable", 14M, "Charging Cables & Adapters"),
               new Product("Micro USB Car Charger", 12M, "Charging Cables & Adapters"),
               new Product("USB-C to Micro USB Adapter", 5M, "Charging Cables & Adapters"),
               new Product("Micro USB OTG Adapter", 9M, "Charging Cables & Adapters"),
               new Product("Micro USB Charging Dock", 20M, "Charging Cables & Adapters"),
               new Product("Reversible Micro USB Cable", 11M, "Charging Cables & Adapters"),
               new Product("Micro USB to HDMI Adapter", 18M, "Charging Cables & Adapters")
            };
                    DisplayAndAddProduct(cart, microUSBCables);
                    break;

                case "3":
                    List<Product> lightningCables = new List<Product>
            {
                new Product("Lightning USB Fast Charging Cable (USB 3.0)", 20M, "Charging Cables & Adapters"),
                new Product("Lightning USB Standard Charging Cable (USB 2.0)", 15M, "Charging Cables & Adapters"),
                new Product("USB-C to USB-C Fast Charging Cable", 18M, "Charging Cables & Adapters"),
               new Product("Lightning to USB-C Cable", 22M, "Charging Cables & Adapters"),
               new Product("Standard Micro USB Charging Cable", 5M, "Charging Cables & Adapters"),
               new Product("USB-C to USB-A Charging Cable", 10M, "Charging Cables & Adapters"),
               new Product("Type-C to USB-C Charging Cable", 12M, "Charging Cables & Adapters"),
               new Product("USB-C to 3.5mm Adapter", 8M, "Charging Cables & Adapters"),
               new Product("10FT USB-C Charging Cable", 15M, "Charging Cables & Adapters"),
               new Product("High-Speed Lightning Charging Cable (3-Pack)", 25M, "Charging Cables & Adapters"),
               new Product("Wireless Charging Stand", 30M, "Charging Cables & Adapters"),
               new Product("Multi-Device Charging Station", 40M, "Charging Cables & Adapters")
            };
                    DisplayAndAddProduct(cart, lightningCables);
                    break;

                case "4":
                    List<Product> miniUSBCables = new List<Product>
            {
                new Product("Mini USB Charging Cable (USB 2.0)", 10M, "Charging Cables & Adapters"),
                new Product("Mini USB Fast Charging Cable (USB 3.0)", 14M, "Charging Cables & Adapters"),
                   new Product("Type-C to Lightning Cable", 12M, "Charging Cables & Adapters"),
               new Product("USB-C to Micro USB Adapter (2-Pack)", 8M, "Charging Cables & Adapters"),
               new Product("Braided USB-C Cable", 15M, "Charging Cables & Adapters"),
               new Product("30W USB-C Power Delivery Charger", 22M, "Charging Cables & Adapters"),
               new Product("3-in-1 Charging Cable", 10M, "Charging Cables & Adapters"),
               new Product("USB-C to Ethernet Adapter", 18M, "Charging Cables & Adapters"),
               new Product("3.5mm to RCA Audio Adapter", 6M, "Charging Cables & Adapters"),
               new Product("USB-C to VGA Adapter", 25M, "Charging Cables & Adapters"),
               new Product("Portable Charger with Built-in Cables", 35M, "Charging Cables & Adapters"),
               new Product("Cable Management Organizer", 8M, "Charging Cables & Adapters")
            };
                    DisplayAndAddProduct(cart, miniUSBCables);
                    break;

                case "5":
                    List<Product> adapters = new List<Product>
            {
                new Product("Type-C to Micro USB Adapter", 5M, "Charging Cables & Adapters"),
                new Product("Lightning to USB Adapter", 7M, "Charging Cables & Adapters"),
                  new Product("USB-C Charging Cable", 10M, "Charging Cables & Adapters"),
                   new Product("Fast Charging Wall Charger", 15M, "Charging Cables & Adapters"),
                   new Product("Multi-Port USB Charger", 30M, "Charging Cables & Adapters"),
                   new Product("Micro USB Charging Cable", 5M, "Charging Cables & Adapters"),
                   new Product("USB-C to HDMI Adapter", 20M, "Charging Cables & Adapters"),
                   new Product("Wireless Charging Pad", 25M, "Charging Cables & Adapters"),
                   new Product("Lightning to 3.5mm Audio Adapter", 12M, "Charging Cables & Adapters"),
                   new Product("USB-C to USB-A Adapter", 8M, "Charging Cables & Adapters"),
                   new Product("Car Charger with Dual USB Ports", 18M, "Charging Cables & Adapters"),
                   new Product("Magnetic Charging Cable", 14M, "Charging Cables & Adapters"),
                new Product("USB Hub (USB 3.0)", 25M, "Charging Cables & Adapters")
            };
                    DisplayAndAddProduct(cart, adapters);
                    break;

                case "6":
                    return;

                case "7":
                    Console.WriteLine("\t\t\t\t\tExiting the shopping cart. Goodbye!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\tInvalid choice.");
                    break;
            }
        }

        static void DisplayWelcome()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"   
                                     



                                                                             __        __   _                                                   
                                                                             \ \      / /__| | ___ ___  _ __ ___   ___  
                                                                              \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \ 
                                                                               \ V  V /  __/ | (_| (_) | | | | | |  __/ 
                                                                                \_/\_/ \___|_|\___\___/|_| |_| |_|\___|                                    
                                  



");
            Console.ResetColor();
            Console.Write("\t\t\t\t\tPlease Enter your Name: ");
            string customerName = Console.ReadLine();
            Console.WriteLine("\n\n\t\t\t\t\tHello, " + customerName + "! Let's Start Shopping!!!");
            PauseScreen();
        }
    }
}
