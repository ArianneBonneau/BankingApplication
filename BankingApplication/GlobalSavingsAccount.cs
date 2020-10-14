using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    class GlobalSavingsAccount : SavingAccount, IExchangeable
    {
        public GlobalSavingsAccount(double cb, double ir) : base(cb, ir)
        {
        }

        public virtual double USValue(double rate)
        {
            return (base.currentBalance * rate);
        }

    }
}
