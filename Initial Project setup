using System;

namespace ShoppingCartSystem
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int RemainingStock { get; set; }

        public Product(int id, string name, double price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            RemainingStock = stock;
        }

        public void DisplayProduct()
        {
            Console.WriteLine($"{Id}. {Name} - P{Price} (Stock: {RemainingStock})");
        }

        public bool HasEnoughStock(int quantity)
        {
            return RemainingStock >= quantity;
        }

        public void DeductStock(int quantity)
        {
            RemainingStock -= quantity;
        }
    }

    class CartItem
    {
        public Product ProductInfo { get; set; }
        public int Quantity { get; set; }
        public double ItemTotal => ProductInfo.Price * Quantity;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Store Menu
            Product[] menu = {
                new Product(1, "Laptop", 35000, 5),
                new Product(2, "Mouse", 500, 20),
                new Product(3, "Keyboard", 1200, 10),
                new Product(4, "Monitor", 7000, 0) // Out of stock example
            };

            CartItem[] cart = new CartItem[10];
            int cartCount = 0;
            string choice;

            do
            {
                Console.WriteLine("\n--- STORE MENU ---");
                foreach (var p in menu) p.DisplayProduct();

                // 2 & 4. Input & Validation
                Console.Write("\nEnter product number: ");
                if (!int.TryParse(Console.ReadLine(), out int prodNum) || prodNum < 1 || prodNum > menu.Length)
                {
                    Console.WriteLine("Invalid product number.");
                }
                else
                {
                    Product selected = menu[prodNum - 1];

                    if (selected.RemainingStock == 0)
                    {
                        Console.WriteLine("Product is out of stock.");
                    }
                    else
                    {
                        Console.Write("Enter quantity: ");
                        if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
                        {
                            Console.WriteLine("Invalid quantity.");
                        }
                        else if (!selected.HasEnoughStock(qty))
                        {
                            Console.WriteLine("Not enough stock available.");
                        }
                        else
                        {
                            // 5 & 6. Add to cart / Handle Duplicates
                            bool found = false;
                            for (int i = 0; i < cartCount; i++)
                            {
                                if (cart[i].ProductInfo.Id == selected.Id)
                                {
                                    cart[i].Quantity += qty;
                                    selected.DeductStock(qty);
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                if (cartCount < cart.Length)
                                {
                                    cart[cartCount] = new CartItem { ProductInfo = selected, Quantity = qty };
                                    selected.DeductStock(qty);
                                    cartCount++;
                                    Console.WriteLine("Added to cart.");
                                }
                                else
                                {
                                    Console.WriteLine("Cart is full.");
                                }
                            }
                        }
                    }
                }

                Console.Write("Add more items? (Y/N): ");
                choice = Console.ReadLine().ToUpper();
            } while (choice == "Y");

            // 9, 10, 11. Receipt and Totals
            double grandTotal = 0;
            Console.WriteLine("\n--- FINAL RECEIPT ---");
            for (int i = 0; i < cartCount; i++)
            {
                Console.WriteLine($"{cart[i].ProductInfo.Name} x{cart[i].Quantity} - P{cart[i].ItemTotal}");
                grandTotal += cart[i].ItemTotal;
            }

            Console.WriteLine($"Grand Total: P{grandTotal}");
            if (grandTotal >= 5000)
            {
                double discount = grandTotal * 0.10;
                Console.WriteLine($"Discount (10%): -P{discount}");
                grandTotal -= discount;
            }
            Console.WriteLine($"Final Total: P{grandTotal}");

            // 12. Updated Stock
            Console.WriteLine("\n--- UPDATED STOCK ---");
            foreach (var p in menu) p.DisplayProduct();
        }
    }
}
