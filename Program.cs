class Program
{
    static void Main()
    {
        ExpenseManager manager = new ExpenseManager();

        while (true)
        {
            Console.WriteLine("\n1. Add Expense\n2. View All\n3. Total\n4. Exit");
            Console.Write("Choose option: ");

            string? choiceInput = Console.ReadLine();
            if (!int.TryParse(choiceInput, out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    string desc;
                    do
                    {
                        Console.Write("Enter description: ");
                        desc = Console.ReadLine()?.Trim() ?? "";
                        if (string.IsNullOrEmpty(desc))
                            Console.WriteLine("Description cannot be empty!");
                    } while (string.IsNullOrEmpty(desc));

                    decimal amt;
                    while (true)
                    {
                        Console.Write("Enter amount: ");
                        string? amtInput = Console.ReadLine();
                        if (decimal.TryParse(amtInput, out amt) && amt >= 0)
                            break;
                        Console.WriteLine("Invalid amount. Enter a positive number.");
                    }

                    manager.AddExpense(desc, amt);
                    break;

                case 2:
                    manager.ViewExpenses();
                    break;

                case 3:
                    Console.WriteLine($"Total Expense = ₹{manager.GetTotalExpense()}");
                    break;

                case 4:
                    Console.WriteLine("Exiting... Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please select 1-4.");
                    break;
            }
        }
    }
}
