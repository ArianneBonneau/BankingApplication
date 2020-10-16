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

        public virtual string USValue(double rate)
        { 
            return toNAMoneyFormat((base.currentBalance * rate), true);
        }

    }
}
