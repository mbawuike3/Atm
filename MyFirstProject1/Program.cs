using System.Text.RegularExpressions;

int pinAttempt = 3;
int pin = 0;
double Balance = 10000;
while(pinAttempt > 0)
{
    Console.Write("Enter a 4-Digit pin: ");
    string? pinInput = Console.ReadLine();
    if(string.IsNullOrEmpty(pinInput))
    {
        Console.WriteLine("Pin can't be empty");
    }
    else if(Regex.IsMatch(pinInput, @"^\d{4}$"))
    {
        pin = int.Parse(pinInput);
        break;
    }
    else
    {
        Console.WriteLine("Invalid input, please enter a 4-Digit pin");
        pinAttempt--;
    }
}
if(pinAttempt == 0)
{
    Console.WriteLine("Too many Attempts, your account is locked temporary");
    return;
}
else
{
    Console.WriteLine($"Welcome! your account balance is {Balance}");
    while(true)
    {
        Console.Write("Enter amount you want to withdraw or (Enter 0 to exit): $");
        string? amountInput = Console.ReadLine();
        if(string.IsNullOrEmpty(amountInput) || string.IsNullOrWhiteSpace(amountInput))
        {
            Console.WriteLine("Amount can't be empty");
        }
        if(Regex.IsMatch(amountInput!, @"^\d+(\.\d{1,2})?$"))
        {
            double amountToWithdraw = double.Parse(amountInput!);
            if(amountToWithdraw == 0)
            {
                Console.WriteLine("Thank you for banking with us, bye!");
                break;
            }
            else if(amountToWithdraw == Balance)
            {
                Balance -= amountToWithdraw;
                Console.WriteLine("Withdrawal is successful, your balance is $0");
                break;
            }
            else if(amountToWithdraw > Balance)
            {
                Console.WriteLine("Insufficient fund, please reduce your amount");
            }
            else
            {
                Balance -= amountToWithdraw;
                Console.WriteLine($"Withdrawal is successful, your new balance is ${Balance}");
            }
        }
        else
        {
            Console.WriteLine("Transaction failed, please enter a valid amount");
        }
    }
}
