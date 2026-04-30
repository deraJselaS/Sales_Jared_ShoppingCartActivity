# ShoppingCartSystem
An enhanced console-based Shopping Cart System developed in C# that handles product inventory, cart management, and transaction history.
Features
# Phase 1: Core System
Product Menu: Displays available items with ID, Name, Price, and Stock.
Input Validation: Uses int.TryParse() to handle non-numeric inputs and validates product IDs.
Stock Management: Prevents purchasing more than the available RemainingStock and handles out-of-stock items.
Duplicate Handling: Updates existing cart entries instead of adding new rows if the same product is selected again.
Discount Logic: Automatically applies a 10% discount if the Grand Total is 5,000 or more.
# Phase 2: Enhanced Management
Cart Management Menu: Users can view the cart, remove specific items, update quantities, or clear the entire cart.
Product Search & Filter: Allows searching for products by name and filtering by categories like Food, Electronics, or Clothing.
Payment Validation: Ensures payment is numeric and sufficient to cover the total before computing change.
Receipt Details: Generates a unique receipt number, date/time, and itemized totals.
Order History: Tracks all completed transactions during the program run.
Low Stock Alerts: Displays a warning for products with stock levels $\le$ 5 after checkout.

# AI Usage in This Project

# Parts assisted by AI:
Logic Design: Structuring the array-shifting logic for removing items from a fixed-size cart.
Validation: Implementing the robust loop for $Y/N$ prompts to ensure strict input handling.
Formatting: Designing the receipt layout and DateTime integration.
# "Why AI was used??"
To ensure professional coding standards for input validation and inventory accuracy.
To troubleshoot the logic for returning stock to the menu when an item is removed from the cart.

# Here are the improvements made after using AI:
# Case Sensitivity: 
Improved the search functionality by adding .ToLower() to make product searches more user-friendly.
# Data Integrity: 
Modified the "Clear Cart" function to ensure all reserved stock is correctly returned to the main inventory.

# Conclusion
The Enhanced Shopping Cart System serves as a practical application of core Object Oriented Programming (aka OOP) principles in C#, emphasizing the importance of data integrity and user experience. By integrating robust validation, dynamic stock management, and a comprehensive transaction history, this project demonstrates how software can handle complex real world logic within a console environment.
The addition of the Cart Management Menu and Payment Validation ensures that the system is not only functional but also resilient against invalid user inputs. Furthermore, the implementation of Low Stock Alerts and Order History provides essential feedback for both customers and administrators, bridging the gap between a simple academic exercise and a scalable software solution.
