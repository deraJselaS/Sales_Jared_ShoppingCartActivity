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

        public double GetItemTotal(int quantity)
        {
            return Price * quantity;
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
        public double Subtotal { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product[] menu = {
                new Product(1, "Laptop", 35000, 5),
                new Product(2, "Mouse", 500, 20),
                new Product(3, "Keyboard", 1200, 10),
                new Product(4, "Monitor", 7000, 0)
            };

            CartItem[] cart = new CartItem[10];
            int cartCount = 0;
            string choice;

            do
            {
                Console.WriteLine("\n--- STORE MENU ---");
                foreach (var p in menu) p.DisplayProduct();

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
                            bool found = false;
                            for (int i = 0; i < cartCount; i++)
                            {
                                if (cart[i].ProductInfo.Id == selected.Id)
                                {
                                    cart[i].Quantity += qty;
                                    cart[i].Subtotal += selected.GetItemTotal(qty); 
                                    selected.DeductStock(qty);
                                    Console.WriteLine("Cart updated (Quantity increased).");
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                if (cartCount < cart.Length)
                                {
                                    cart[cartCount] = new CartItem 
                                    { 
                                        ProductInfo = selected, 
                                        Quantity = qty,
                                        Subtotal = selected.GetItemTotal(qty)
                                    };
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

                while (true)
                {
                    Console.Write("Add more items? (Y/N): ");
                    choice = Console.ReadLine().ToUpper();
                    if (choice == "Y" || choice == "N") break;
                    Console.WriteLine("Invalid input. Please enter Y or N only.");
                }

            } while (choice == "Y");

            double grandTotal = 0;
            Console.WriteLine("\n--- FINAL RECEIPT ---");
            for (int i = 0; i < cartCount; i++)
            {
                Console.WriteLine($"{cart[i].ProductInfo.Name} x{cart[i].Quantity} - P{cart[i].Subtotal}");
                grandTotal += cart[i].Subtotal;
            }

            Console.WriteLine($"Grand Total: P{grandTotal}");
            if (grandTotal >= 5000)
            {
                double discount = grandTotal * 0.10;
                Console.WriteLine($"Discount (10%): -P{discount}");
                grandTotal -= discount;
            }
            Console.WriteLine($"Final Total: P{grandTotal}");
        }
    }
}
