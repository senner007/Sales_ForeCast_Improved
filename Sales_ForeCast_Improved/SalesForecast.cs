using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales_ForeCast_Improved
{
    delegate decimal Calculate(params decimal[] vals);
    class SalesForecast
    {
        public SalesForecast(List<int> validatedInput)
        {
           
            TotalSales = SumUp(
                 Mult(Constants.BILLET_PRIS_GENNEMSNIT, validatedInput[0]),
                 Mult(Constants.TV_RETTIGHEDER_PR_KANAL, validatedInput[1]),
                 Mult(validatedInput[2], Constants.SALG_SPORTS_VARE_GENNEMSNIT, Constants.SALG_FRA_BUTIK_BESOEG_PCT),
                 Mult(Constants.ABONNEMENT_PRIS_6_MAANEDER, validatedInput[3]),
                 Mult(Constants.SALG_DRIKKEVARE_GENNEMSNIT, validatedInput[0], (Convert.ToDecimal(validatedInput[4]) / 100))
            );

            TotalExpenses = TotalSales * Constants.TOTAL_OMK_I_PCT;
            TotalEarnings = TotalSales - TotalExpenses;

            DataInputAsList = validatedInput;
        }
        public decimal TotalSales { get; private set; }
        public decimal TotalEarnings { get; private set; }
        public decimal TotalExpenses { get; private set; }
        public List<int> DataInputAsList { get; private set; }

        Calculate Mult = vals => vals.Aggregate((a, b) => a * b);
        Calculate SumUp = vals => vals.Sum();
    }
}
