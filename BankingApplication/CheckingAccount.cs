using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    class CheckingAccount : Account
    {
        public CheckingAccount(double cb, double ir) : base(cb, ir)
        {
        }
        public override void MakeDeposit(double td)
        {
            base.MakeDeposit(td);
        }
        public override void MakeWithdraw(double tw)
        {
            if ((base.currentBalance - tw) < 0)
            {
                base.currentBalance -= 15.00;
            }
            else
            {
                base.MakeWithdraw(tw);
            }
        }

        public override string CloseAndReport()
        {
            base.serviceCharge = (double) 5 + (numWithdrawals * 0.1);
         
            return base.CloseAndReport();
        }
    }
}
