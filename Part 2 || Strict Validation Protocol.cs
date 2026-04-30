string input;
while (true)
{
    Console.Write("Add another item? (Y/N): ");
    input = Console.ReadLine().ToUpper();
    if (input == "Y" || input == "N") break;
    Console.WriteLine("Invalid input. Please enter Y or N only.");
}
