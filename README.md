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

