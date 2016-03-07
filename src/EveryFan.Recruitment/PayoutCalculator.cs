using System;
using System.Collections.Generic;
using EveryFan.Recruitment.PayoutCalculators;

namespace EveryFan.Recruitment
{
    public class PayoutCalculator
    {
        public IReadOnlyList<TournamentPayout> Calculate(Tournament tournament)
        {           
            if (tournament.PayoutScheme == PayoutScheme.FIFTY_FIFY)
            {
                FiftyFiftyPayoutCalculator calculator = new FiftyFiftyPayoutCalculator();
                return calculator.Calculate(tournament);
            }

            if (tournament.PayoutScheme == PayoutScheme.WINNER_TAKES_ALL)
            {
                WinnerTakesAllPayoutCalculator calculator = new WinnerTakesAllPayoutCalculator();
                return calculator.Calculate(tournament);
            }

            throw new ArgumentOutOfRangeException(nameof(tournament.PayoutScheme));
        }
    }
}
