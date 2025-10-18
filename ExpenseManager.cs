class ExpenseManager
{
    private List<Expense> expenses;

    public ExpenseManager()
    {
        expenses = new List<Expense>();
    }

    public void AddExpense(string description, decimal amount)
    {
        var existing = expenses.FirstOrDefault(e => e.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
        if (existing != null)
        {
            existing.Amount += amount;
            Console.WriteLine("Existing expense updated with new amount!");
        }
        else
        {
            expenses.Add(new Expense(description, amount));
            Console.WriteLine("Expense added successfully!");
        }
    }

    public void ViewExpenses()
    {
        if (expenses.Count == 0)
        {
            Console.WriteLine("No expenses recorded yet.");
            return;
        }

        Console.WriteLine("\nExpenses:");
        foreach (var e in expenses)
            Console.WriteLine($"{e.Description} - ₹{e.Amount}");
    }

    public decimal GetTotalExpense()
    {
        decimal total = 0;
        foreach (var e in expenses)
            total += e.Amount;
        return total;
    }
}
