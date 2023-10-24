using ATM.Modal;
using System;

namespace ATM.Services
{
    public class User
    {
        private cardHolderDTO _cardHolderDTO;

        public User(cardHolderDTO cardHolderDTO)
        {
            _cardHolderDTO = cardHolderDTO;
        }

        public void PrintOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        public void Deposit()
        {
            Console.WriteLine("How much Rupees would you like to deposit?");
            double deposit = double.Parse(Console.ReadLine());
            double totalDeposit = Math.Abs(deposit) + _cardHolderDTO.balance;
            _cardHolderDTO.balance = totalDeposit;
            Console.WriteLine($"\nThank you for your Rupees.\nYour new balance is: {_cardHolderDTO.balance}");
            Console.ReadKey();
        }

        public void Withdraw()
        {
            Console.WriteLine("How much Rupees would you like to withdraw: ");
            double withdraw = double.Parse(Console.ReadLine());
            if (withdraw > _cardHolderDTO.balance)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                double newBalance = _cardHolderDTO.balance - withdraw;
                _cardHolderDTO.balance = newBalance;
                Console.WriteLine("You are good to go! Thank you :)");
            }
            Console.ReadKey();
        }

        public void ConsoleATM()
        {
            // Create a CardHolderDTO with initial card information
            _cardHolderDTO = new cardHolderDTO
            {
                cardNumber = "1234 5678 9012 3456",
                pin = 1234,
                firstname = "Sandeep",
                lastname = "Chauhan",
                balance = 1000.00
            };


            Console.WriteLine("**********************");
            Console.WriteLine("* Welcome to the ATM *");
            Console.WriteLine("**********************");
            Console.WriteLine("Please enter your pin:");
            int pin;
            bool isNumber = int.TryParse(Console.ReadLine(), out pin);
            if (!isNumber)
            {
                Console.WriteLine("Invalid PIN, Please enter a valid number.");
            }
            else
            {
                int balanceKey = 0;
                if (_cardHolderDTO.pin == pin)
                {
                    while (true)
                    {
                        Console.Clear(); // Clear the console for a cleaner interface
                        Console.WriteLine("***********************************");
                        Console.WriteLine("*       Welcome to the ATM        *");
                        Console.WriteLine("***********************************");
                        Console.WriteLine($"Card Number: {_cardHolderDTO.cardNumber}");
                        Console.WriteLine($"Name: {_cardHolderDTO.firstname} {_cardHolderDTO.lastname}");
                        if (balanceKey == 3)
                        {
                            Console.WriteLine($"Balance: {_cardHolderDTO.balance}");
                        }
                        Console.WriteLine("***********************************");


                        // Display available options to the user
                        PrintOptions();

                        int choice;
                        if (int.TryParse(Console.ReadLine(), out choice))
                        {
                            switch (choice)
                            {
                                case 1:
                                    Deposit();
                                    break;
                                case 2:
                                    Withdraw();
                                    break;
                                case 3:
                                    balanceKey = 3;
                                    Console.WriteLine($"Your balance: {_cardHolderDTO.balance}");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.WriteLine("Thank you. Goodbye!");
                                    return;
                                default:
                                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a number (1-4).");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect pin!");
                    Console.ReadKey();
                }
            }

        }

    }
}
