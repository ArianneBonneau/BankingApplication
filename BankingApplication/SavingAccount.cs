using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    class SavingAccount : Account
    {
        public SavingAccount(double cb, double ir) : base(cb, ir)
        {
        }
        public override void MakeDeposit(double td)
        {
            if (base.accountStatus == Status.inactive)
            {
                if(base.currentBalance > 25)
                {
                    base.accountStatus = Status.active;
                }

                base.MakeDeposit(td);
            }
            else
            {
                base.MakeDeposit(td);
            }
        }
        public override void MakeWithdraw(double tw)
        {
           if (base.accountStatus == Status.active)
            {
                base.MakeWithdraw(tw);
            }  
            
        }

        public override string CloseAndReport()
        {
            if(base.numWithdrawals > 4)
            {
                base.serviceCharge = (double) (numWithdrawals - 4);
            }

            if(base.currentBalance < 25)
            {
                base.accountStatus = Status.inactive;
            }

            return base.CloseAndReport();
        }
    }
}
