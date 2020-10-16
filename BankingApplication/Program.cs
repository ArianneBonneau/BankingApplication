using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BankingApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            SavingAccount Savings = new SavingAccount(5, 0.2);
            CheckingAccount Checking = new CheckingAccount(5, 0.2);
            GlobalSavingsAccount GlobalSavings = new GlobalSavingsAccount(5, 0.2);

            bool valid = true;

            while (valid)
            {

                Console.WriteLine("Bank Menu \n A: Savings \n B: Checking \n C: GlobalSavings \n Q: Exit");
                var ans = Console.ReadLine();


                if (ans == "A")
                {
                    bool validAns = true;
                    while (validAns)
                    {
                        Console.WriteLine("Savings Menu \n A: Deposit \n B: Withdrawal \n" +
                          " C: Close + Report \n R: Return to Bank Menu");

                        var choice = Console.ReadLine();
                        if (choice == "A")
                        {
                            Console.WriteLine("Amount of the deposit: ");
                            var amount = Console.ReadLine();

                            double num;
                            bool isNum = double.TryParse(amount, out num);
                            if (!isNum)
                            {
                                throw new Exception("Must be a number.");
                            }

                            Savings.MakeDeposit(num);
                            Console.WriteLine("Your current balance is: " + Savings.toNAMoneyFormat(Savings.currentBalance, true));

                        }
                        else if (choice == "B")
                        {
                            Console.WriteLine("Amount of the withdraw: ");
                            var amount = Console.ReadLine();

                            double num;
                            bool isNum = double.TryParse(amount, out num);
                            if (!isNum)
                            {
                                throw new Exception("Must be a number.");
                            }

                            Savings.MakeWithdraw(num);
                            Console.WriteLine("Your current balance is: " + Savings.toNAMoneyFormat(Savings.currentBalance, true));
                        }
                        else if (choice == "C")
                        {
                            Console.WriteLine(Savings.CloseAndReport());

                        }
                        else if (choice == "R")
                        {
                            validAns = false;
                        }
                        else
                        {
                            throw new System.Exception("You must enter A, B, C, or R.");
                        }
                    }
                }
                else if (ans == "B")
                {
                    bool validAns = true;
                    while (validAns)
                    {
                        Console.WriteLine("Checking Menu \n A: Deposit \n B: Withdrawal \n" +
                         " C: Close + Report \n R: Return to Bank Menu");


                        var choice1 = Console.ReadLine();
                        if (choice1 == "A")
                        {
                            Console.WriteLine("Amount of the deposit: ");
                            var amount = Console.ReadLine();

                            double num;
                            bool isNum = double.TryParse(amount, out num);
                            if (!isNum)
                            {
                                throw new Exception("Must be a number.");
                            }

                            Checking.MakeDeposit(num);
                            Console.WriteLine("Your current balance is: " + Checking.toNAMoneyFormat(Checking.currentBalance, true));
                        }
                        else if (choice1 == "B")
                        {
                            Console.WriteLine("Amount of the withdraw: ");
                            var amount = Console.ReadLine();

                            double num;
                            bool isNum = double.TryParse(amount, out num);
                            if (!isNum)
                            {
                                throw new Exception("Must be a number.");
                            }
                            Checking.MakeWithdraw(num);
                            Console.WriteLine("Your current balance is: " + Checking.toNAMoneyFormat(Checking.currentBalance, true));
                        }
                        else if (choice1 == "C")
                        {
                            Console.WriteLine(Checking.CloseAndReport());
                        }
                        else if (choice1 == "R")
                        {
                            validAns = false;
                        }
                        else
                        {
                            throw new System.Exception("You must enter A, B, C, or R.");
                        }
                    }
                }
                else if (ans == "C")
                {
                    bool validAns = true;

                    while (validAns)
                    {
                        Console.WriteLine("Global Savings Menu \n A: Deposit \n B: Withdrawal \n" +
                        " C: Close + Report \n D: Report Balance USD \n R: Return to Bank Menu");


                        var choice2 = Console.ReadLine();
                        if (choice2 == "A")
                        {
                            Console.WriteLine("Amount of the deposit: ");
                            var amount = Console.ReadLine();

                            double num;
                            bool isNum = double.TryParse(amount, out num);
                            if (!isNum)
                            {
                                throw new Exception("Must be a number.");
                            }

                            GlobalSavings.MakeDeposit(num);
                            Console.WriteLine("Your current balance is: " + GlobalSavings.toNAMoneyFormat(GlobalSavings.currentBalance, true));
                        }
                        else if (choice2 == "B")
                        {
                            Console.WriteLine("Amount of the withdraw: ");
                            var amount = Console.ReadLine();

                            double num;
                            bool isNum = double.TryParse(amount, out num);
                            if (!isNum)
                            {
                                throw new Exception("Must be a number.");
                            }
                            GlobalSavings.MakeWithdraw(num);
                            Console.WriteLine("Your current balance is: " + GlobalSavings.toNAMoneyFormat(GlobalSavings.currentBalance, true));
                        }
                        else if (choice2 == "C")
                        {
                            Console.WriteLine(GlobalSavings.CloseAndReport());
                        }
                        else if (choice2 == "D")
                        {
                            Console.WriteLine("You have " + GlobalSavings.USValue(0.71) + "(USD)");
                        }
                        else if (choice2 == "R")
                        {
                            validAns = false;
                        }
                        else
                        {
                            throw new System.Exception("You must enter A, B, C, D, or R.");
                        }
                    }
                }
                else if (ans == "Q")
                {
                    valid = false;
                }
                else
                {
                    throw new System.Exception("You must enter A, B, C, or Q.");
                }

                Console.ReadKey();
            }
            Environment.Exit(0);
        }
    }
}
