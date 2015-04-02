using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagMyCoins.Domain.Enumerators
{
    public enum EnumTypeTransaction
    {
        [Description("Income")]
        Income = 1,

        [Description("Expense")]
        Expense = 2
    }
}
