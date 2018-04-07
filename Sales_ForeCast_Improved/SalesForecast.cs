using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales_ForeCast_Improved
{
    delegate decimal Calculate(params decimal[] vals);
    class SalesForecast
    {
        public int TicketsSold { get; private set; }
        public int TVCover { get; private set; }
        public int SportsVisitors { get; private set; }
        public int FitnessSubscribers { get; private set; }
        public int VisitorsAppear { get; private set; }
        public SalesForecast(List<int> validatedInput)
        {
            TicketsSold = validatedInput[0];
            TVCover = validatedInput[1];
            SportsVisitors = validatedInput[2];
            FitnessSubscribers = validatedInput[3];
            VisitorsAppear = validatedInput[4];

            CalculateIncome();
            CalculateExpenses();
            CalculateEarnings();

        }
        public decimal TotalSales { get; private set; }
        public decimal TotalEarnings { get; private set; }
        public decimal TotalExpenses { get; private set; }
        private void CalculateIncome()
        {
            TotalSales = SumUp(
                  Mult(Constants.BILLET_PRIS_GENNEMSNIT, TicketsSold),
                  Mult(Constants.TV_RETTIGHEDER_PR_KANAL, TVCover),
                  Mult(SportsVisitors, Constants.SALG_SPORTS_VARE_GENNEMSNIT, Constants.SALG_FRA_BUTIK_BESOEG_PCT),
                  Mult(Constants.ABONNEMENT_PRIS_6_MAANEDER, FitnessSubscribers),
                  Mult(Constants.SALG_DRIKKEVARE_GENNEMSNIT, TicketsSold, (Convert.ToDecimal(VisitorsAppear) / 100))
             );
        }
        private void CalculateEarnings()
        {
            TotalEarnings = TotalSales - TotalExpenses;
        }
        private void CalculateExpenses()
        {
            TotalExpenses = TotalSales * Constants.TOTAL_OMK_I_PCT;
        }
        Calculate Mult = vals => vals.Aggregate((a, b) => a * b);
        Calculate SumUp = vals => vals.Sum();
    }
}
