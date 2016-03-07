using System;
using System.Collections.Generic;
using EveryFan.Recruitment.PayoutCalculators;

namespace EveryFan.Recruitment
{
    public class PayoutEngine
    {
        public IReadOnlyList<TournamentPayout> Calculate(Tournament tournament)
        {
            IPayoutCalculator calculator;

            switch (tournament.PayoutScheme)
            {
                case PayoutScheme.FIFTY_FIFY:
                {
                    calculator = new FiftyFiftyPayoutCalculator();
                    break;
                }

                case PayoutScheme.WINNER_TAKES_ALL:
                {
                    calculator = new WinnerTakesAllPayoutCalculator();
                    break;
                }

                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(tournament.PayoutScheme));
                }
            }

            return calculator.Calculate(tournament);
        }
    }
}
