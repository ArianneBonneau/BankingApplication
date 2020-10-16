using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BankingApplication
{
    enum Status
    {
        active, inactive
    }
    abstract class Account : IAccount
    {
        public double startingBalance; 
        public double currentBalance;
        double totalDeposits = 0;
        int numDeposit = 0;
        double totalWithdrawals = 0;
        public int numWithdrawals = 0;
        double interestRate;
        public double serviceCharge = 0;
        public Status accountStatus = Status.active;

        public Account(double cb, double ir)
        {
            this.startingBalance = this.currentBalance = cb;
            this.interestRate = ir;

            this.numDeposit = 0;
        }

        public virtual void MakeDeposit(double td)
        {
            this.totalDeposits += td;
            this.currentBalance += td;
            this.numDeposit += 1;
        }
        public virtual void MakeWithdraw(double tw)
        {
            this.totalWithdrawals += tw;
            this.currentBalance -= tw;
            this.numWithdrawals += 1;
        }
        public void CalculateInterest()
        {
            double monthlyInterestRate = (interestRate / 12);
            double montlyInterest = currentBalance * monthlyInterestRate;
            currentBalance = currentBalance + montlyInterest;
        }

        public virtual double getPercentageChange()
        {
            return ((currentBalance - startingBalance) * 100 / startingBalance);
        }

        public virtual string toNAMoneyFormat(double amt, bool roundUp)
        {
            double d = amt;
            if (roundUp)
            {
               d =  Math.Round(d, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                d = Math.Round(d, 2, MidpointRounding.ToEven);
            }
            return d.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        }


        public virtual string CloseAndReport()
        {
            string report = "";

            CalculateInterest();

            report = "previous balance : " + toNAMoneyFormat(startingBalance, true)
                  + " \nNew balance : " + toNAMoneyFormat(currentBalance, true) +
                  "\nYou did " + numDeposit + " deposit(s) for a total of " + toNAMoneyFormat(totalDeposits, true) + "\nand "
                  + numWithdrawals + " whitdraw(als) for a total of (" + toNAMoneyFormat(totalWithdrawals, true) + ") this month."
                  + "\n% change of the account : "
                  + Math.Round(getPercentageChange(), 2)
                  + "%\nInterest Rate : " + interestRate + "%\n";

            currentBalance -= serviceCharge;
            startingBalance = currentBalance;
            numDeposit = 0;
            numWithdrawals = 0;
            serviceCharge = 0;
            totalDeposits = 0;
            totalWithdrawals = 0;

            return report;
        }




    }
}
