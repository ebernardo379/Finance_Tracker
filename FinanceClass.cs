using System.Dynamic;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace Classes;

//Finance Class
// - Takes in Income, takes in spending, tracks overall spending.
// - Categorize spending by various types: i.e. groceries, bills, personal, subscriptions, etc.
// - Add spending goal & saving goal feature later. 
public class Finances
{
    //Define Variables
    public List<Category> income { get; }
    public List<Category> expenses { get; }

    //Getters y Setters
    public Finances()
    {
        income = [];
        expenses = [];
    }

    //Add income
    public void addIncome(string target, decimal ammount)
    {
        if(income.Any(x => x.type == target)){
            income[FindTargetType(target, income)].addItem(ammount);
            Console.WriteLine($"Target {target} found. Add successful.");
        }
        else
        {
            Console.WriteLine($"Target {target} not found.");
        }
        
    }

    public void addNewIncome(string new_type, decimal ammount)
    {
        income.Add(new Category(new_type, ammount));
    }

    //Add existing spending
    public void addSpending(string target, decimal ammount)
    {
        expenses[FindTargetType(target, expenses)].addItem(ammount);
    }

    //Add new spending
    public void addNewSpending(string new_type, decimal ammount)
    {
        expenses.Add(new Category(new_type, ammount));
    }

    //Get total income
    public decimal GetTotalIncome()
    {
        decimal sum = 0M;
        foreach(Category x in income)
        {
            sum = x.getSum();
        }
        return sum;
    }

    //Get specific income
    public decimal GetSpecificIncome(string target)
    {
        return income[FindTargetType(target, income)].getSum();
    }

    public void writeSpecificExpense(string target)
    {
        expenses[FindTargetType(target, expenses)].writeCategory();
    }


    //Check if Category is in the list before calling function.
    private int FindTargetType(string target, List<Category> list)
    {
        //Console.WriteLine("Find Income method call!!");
        int i = 0;
        foreach(Category x in list){
            if(x.getType() == target){
                //Console.WriteLine($"Return value {i}!");
                return i;
            }
            i++;
        }
        return -1;
    }
}

public struct Category
{
    //Define Variables
    public List<decimal> items;
    public string type { get; set; }

    //Getter y Setter
    public Category()
    {
        type = "";
        items = [];
    }

    public Category(string t, decimal a)
    {
        type = t;
        items = [a];
    }

    //Methods
    public void addItem(decimal ammount)
    {
        items.Add(ammount);
    }
    
    public List<decimal> GetList()
    {
        return items;
    }

    public decimal getSum()
    {
        return items.Sum();
    }

    public string getType()
    {
        return type;
    }

    public void writeCategory()
    {
        Console.WriteLine($"{type} Spending:");
        if (items.Count != 0)
        {
            decimal total = 0.0M;
            foreach(decimal x in items){
                Console.WriteLine($"${x}");
                total = total + x;
            }
            Console.WriteLine($"Total spending: ${total}");
        }
        else
        {
            Console.WriteLine("No expenses in this category.");
        }
    } 
}