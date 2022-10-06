using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardNum, int pin, String firstName, String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public string getFirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please select one of our options.");
            Console.WriteLine("1 - Deposit");
            Console.WriteLine("2 - Withdrawal");
            Console.WriteLine("3 - Check Balance");
            Console.WriteLine("4 - Exit");
        }


        void Deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit today? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit + currentUser.getBalance());
            Console.WriteLine($"Your updated balance is ${currentUser.getBalance()} \n Thank you for using Digital Native Bank.\n Have a nice day!");
        }
        void Withdraw(cardHolder currentUser)
        {
            Console.WriteLine($"Current Balance: ${currentUser.getBalance()} \n How much would you like to withdraw? ");
            double withdraw = Double.Parse(Console.ReadLine());

            if (withdraw > currentUser.getBalance())
            {
                Console.WriteLine("Insufficient Funds");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine($"Your updated balance: ${currentUser.getBalance()}");
            }
        }

        void ViewBalance(cardHolder currentUser)
        {
            Console.WriteLine($"Your current balance: {currentUser.getBalance()}");
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("11281988", 3825, "Tyler", "Morgan", 420.69));

        Console.WriteLine("Welcome to Digital Native Bank.");
        Console.WriteLine("Please enter your debit card numbers.");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);

                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Your card number was not recognized.\n Please re-enter your debit card numbers.");
                }
            }
            catch
            {
                Console.WriteLine("Your card number was not recognized.\n Please re-enter your debit card numbers.");

            }
        }
        Console.WriteLine("Enter your pin: ");
        int pinNum = 0;
        while (true)
        {
            try
            {
                pinNum = int.Parse(Console.ReadLine());

                if (currentUser.getPin() == pinNum)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Your PIN number was not recognized.\n Please re-enter your PIN numbers");
                }
            }
            catch
            {
                Console.WriteLine("Your PIN number was not recognized.\n Please re-enter your PIN numbers");

            }
        }
        Console.WriteLine($"Welcome {currentUser.getFirstName()}!");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {

            }

            if (option == 1)
            {
                Deposit(currentUser);
            }
            else if (option == 2)
            {
                Withdraw(currentUser);
            }
            else if (option == 3)
            {
                ViewBalance(currentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else
            {
                option = 0;
            }


        } while (option != 4);
        Console.WriteLine("Thank you from Digital Native Bank.\n Have a nice day.");

    }
}