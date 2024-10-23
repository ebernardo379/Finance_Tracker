using Classes;

//Creation and income testing.
string income_type = "earned";
decimal income_ammount = 450.00M;
var user = new Finances();
user.addNewIncome(income_type, income_ammount);
Console.WriteLine($"Finance has been created with income ${user.GetSpecificIncome(income_type)} {user.income[0].getType()} income!");

user.addIncome(income_type, 50M);
Console.WriteLine($"The user's new income is {user.GetTotalIncome()}");

//Adding expenses test.
user.addNewSpending("Food", 13.49M);
user.addSpending("Food", 10.32M);
user.addSpending("Food", 24.01M);
user.writeSpecificExpense("Food");
user.addNewSpending("Entertainment", 7.99M);
user.addSpending("Entertainment", 4.99M);
user.addSpending("Entertainment", 12.49M);
user.writeSpecificExpense("Entertainment");

// BUG FOUND ... user.writeSpecificExpense("Bills");
user.addIncome("Family", 300M);

/*
string input;
do{
    Console.WriteLine("1. Add existing income ammount.");
    Console.WriteLine("Select a menu option.");
    input = Console.ReadLine();
    if(input=="1"){
        Console.WriteLine("Please select from the type of existing income.");
        //Get all types of income
        //display options to console.
        //Ask for ammount of income to add.
        //Call AddIncome.
    }

}while(input != "exit");
Console.WriteLine("Ending program");*/