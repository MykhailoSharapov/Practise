// <copyright file="Starter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Practise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// Starter class to demonstrate functionality.
    /// </summary>
    public class Starter
    {
        private const int Magicvalue = 500;
        private readonly Logger logger;
        private readonly TimerCallback threeSecondsCallback;
        private readonly Timer threeSecondsTimer;
        private readonly TimerCallback sevenSecondsCallback;
        private readonly Timer sevenSecondsTimer;
        private readonly Random rand;
        private Shlist<int> shlist;

        /// <summary>
        /// Initializes a new instance of the <see cref="Starter"/> class.
        /// </summary>
        public Starter()
        {
            this.rand = new Random();
            this.shlist = new Shlist<int>();
            this.logger = Logger.Instance;
            this.threeSecondsCallback = new TimerCallback(this.ThreeSecondsAction);
            this.threeSecondsTimer = new Timer(this.threeSecondsCallback, null, 0, 3000);
            this.sevenSecondsCallback = new TimerCallback(this.SevenSecondsAction);
            this.sevenSecondsTimer = new Timer(this.sevenSecondsCallback, null, 0, 7000);
            for (var i = 0; i < 100; i++)
            {
                var obj = new object();
                this.ThreeSecondsAction(obj);
            }
        }

        /// <summary>
        /// run demonstration.
        /// </summary>
        public void Run()
        {
            this.logger.LogInfo("shlist create succesfull");
            this.shlist.AddAsync(this.rand.Next());
            this.logger.LogInfo("Add async succesfull");
            this.shlist.AddRangeAsync(this.shlist);
            this.logger.LogInfo("AddRangeAsync succesfull");
            this.shlist.RemoveItemAsync(0);
            this.logger.LogInfo("RemoveItemAsync succesfull");
            this.shlist.Select(x => x > Magicvalue);
            this.logger.LogInfo("Select succesfull");
            this.shlist.Where(x => x > Magicvalue);
            this.logger.LogInfo("Where succesfull");
            this.shlist.OrderBy(x => x > Magicvalue);
            this.logger.LogInfo("OrderBy succesfull");
            this.shlist.OrderByDistinct(x => x > Magicvalue);
            this.logger.LogInfo("OrderByDistinct succesfull");
            this.shlist.GroupBy(x => x > Magicvalue);
            this.logger.LogInfo("GroupBy succesfull");
            this.shlist.Reverse();
            this.logger.LogInfo("Reverse succesfull");
            this.shlist.All(x => x > Magicvalue);
            this.logger.LogInfo("All succesfull");
            this.shlist.Any(x => x > Magicvalue);
            this.logger.LogInfo("Any succesfull");
            this.shlist.CountLinQ();
            this.logger.LogInfo("CountLinQ succesfull");
            this.shlist.Take(5);
            this.logger.LogInfo("Take succesfull");
            this.shlist.Skip(5);
            this.logger.LogInfo("Skip succesfull");
            this.shlist.Distinct();
            this.logger.LogInfo("Distinct succesfull");
            this.shlist.Expect((IEnumerable<int>)this.shlist);
            this.logger.LogInfo("Expect succesfull");
            this.shlist.Intersect((IEnumerable<int>)this.shlist);
            this.logger.LogInfo("Intersect succesfull");
            this.shlist.Concat((IEnumerable<int>)this.shlist);
            this.logger.LogInfo("Concat succesfull");
            this.shlist.First();
            this.logger.LogInfo("First succesfull");
            this.shlist.FirstOrDefault();
            this.logger.LogInfo("FirstOrDefault succesfull");
            this.shlist.Single();
            this.logger.LogInfo("Single succesfull");
            this.shlist.SingleOrDefault();
            this.logger.LogInfo("SingleOrDefault succesfull");
            this.shlist.ElementAt(0);
            this.logger.LogInfo("ElementAt succesfull");
            this.shlist.ElementAtOrDefault(0);
            this.logger.LogInfo("ElementAtOrDefault succesfull");
            this.shlist.Last();
            this.logger.LogInfo("Last succesfull");
            this.shlist.LastOrDefault();
            this.logger.LogInfo("LastOrDefault succesfull");
        }

        private void ThreeSecondsAction(object obj)
        {
            this.shlist.AddAsync(this.rand.Next());
        }

        private void SevenSecondsAction(object obj)
        {
            IReadOnlyCollection<int> bufferShlist = this.shlist.Distinct();
            this.shlist.Clear();
            this.shlist.AddRangeAsync(bufferShlist.ToArray());
        }
    }
}
