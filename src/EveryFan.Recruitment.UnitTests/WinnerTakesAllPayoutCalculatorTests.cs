using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace EveryFan.Recruitment.UnitTests
{
    
    public class WinnerTakesAllPayoutCalculatorTests
    {
        [Test]
        public void TwoEntries()
        {
            Tournament tournament = new Tournament()
            {
                BuyIn = 250,
                PrizePool = 500,
                PayoutScheme = PayoutScheme.WINNER_TAKES_ALL,
                Entries = new List<TournamentEntry>()
                {
                    new TournamentEntry()
                    {
                        Chips = 10000,
                        UserId = "roger"
                    },
                    new TournamentEntry()
                    {
                        Chips = 1000,
                        UserId = "jennifer"
                    }
                }
            };

            PayoutCalculator calculator = new PayoutCalculator();
            IReadOnlyList<TournamentPayout> payouts = calculator.Calculate(tournament);

            Assert.AreEqual(1, payouts.Count);
            Assert.AreEqual(500, payouts.Sum(p => p.Payout));
        }

        [Test]
        public void ThreeEntries()
        {
            Tournament tournament = new Tournament()
            {
                BuyIn = 250,
                PrizePool = 750,
                PayoutScheme = PayoutScheme.WINNER_TAKES_ALL,
                Entries = new List<TournamentEntry>()
                {
                    new TournamentEntry()
                    {
                        Chips = 5000,
                        UserId = "roger"
                    },
                    new TournamentEntry()
                    {
                        Chips = 3000,
                        UserId = "jennifer"
                    },
                    new TournamentEntry()
                    {
                        Chips = 1000,
                        UserId = "billy"
                    },
                }
            };

            PayoutCalculator calculator = new PayoutCalculator();
            IReadOnlyList<TournamentPayout> payouts = calculator.Calculate(tournament);

            Assert.AreEqual(1, payouts.Count);
            Assert.AreEqual(750, payouts.Sum(p => p.Payout));
            Assert.AreEqual(750, payouts[0].Payout);
        }

        [Test]
        public void SplitWinnings()
        {
            Tournament tournament = new Tournament()
            {
                BuyIn = 250,
                PrizePool = 750,
                PayoutScheme = PayoutScheme.WINNER_TAKES_ALL,
                Entries = new List<TournamentEntry>()
                {
                    new TournamentEntry()
                    {
                        Chips = 5000,
                        UserId = "roger"
                    },
                    new TournamentEntry()
                    {
                        Chips = 5000,
                        UserId = "jennifer"
                    },
                    new TournamentEntry()
                    {
                        Chips = 1000,
                        UserId = "billy"
                    },
                }
            };

            PayoutCalculator calculator = new PayoutCalculator();
            IReadOnlyList<TournamentPayout> payouts = calculator.Calculate(tournament);

            Assert.AreEqual(2, payouts.Count);
            Assert.AreEqual(750, payouts.Sum(p => p.Payout));
            Assert.AreEqual(375, payouts[0].Payout);
            Assert.AreEqual(375, payouts[1].Payout);
        }
    }
}
