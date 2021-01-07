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
            Logger.Instance.LogInfo("shlist create succesfull");
            this.shlist.AddAsync(this.rand.Next());
            Logger.Instance.LogInfo("Add async succesfull");
            this.shlist.AddRangeAsync(this.shlist);
            Logger.Instance.LogInfo("AddRangeAsync succesfull");
            this.shlist.RemoveItemAsync(0);
            Logger.Instance.LogInfo("RemoveItemAsync succesfull");
            this.shlist.Select(x => x > Magicvalue);
            Logger.Instance.LogInfo("Select succesfull");
            this.shlist.Where(x => x > Magicvalue);
            Logger.Instance.LogInfo("Where succesfull");
            this.shlist.OrderBy(x => x > Magicvalue);
            Logger.Instance.LogInfo("OrderBy succesfull");
            this.shlist.OrderByDistinct(x => x > Magicvalue);
            Logger.Instance.LogInfo("OrderByDistinct succesfull");
            this.shlist.GroupBy(x => x > Magicvalue);
            Logger.Instance.LogInfo("GroupBy succesfull");
            this.shlist.Reverse();
            Logger.Instance.LogInfo("Reverse succesfull");
            this.shlist.All(x => x > Magicvalue);
            Logger.Instance.LogInfo("All succesfull");
            this.shlist.Any(x => x > Magicvalue);
            Logger.Instance.LogInfo("Any succesfull");
            this.shlist.CountLinQ();
            Logger.Instance.LogInfo("CountLinQ succesfull");
            this.shlist.Take(5);
            Logger.Instance.LogInfo("Take succesfull");
            this.shlist.Skip(5);
            Logger.Instance.LogInfo("Skip succesfull");
            this.shlist.Distinct();
            Logger.Instance.LogInfo("Distinct succesfull");
            this.shlist.Expect(this.shlist.GetSource());
            Logger.Instance.LogInfo("Expect succesfull");
            this.shlist.Intersect(this.shlist.GetSource());
            Logger.Instance.LogInfo("Intersect succesfull");
            this.shlist.Concat(this.shlist.GetSource());
            Logger.Instance.LogInfo("Concat succesfull");
            this.shlist.First();
            Logger.Instance.LogInfo("First succesfull");
            this.shlist.FirstOrDefault();
            Logger.Instance.LogInfo("FirstOrDefault succesfull");
            try
            {
                this.shlist.Single(x => x > Magicvalue);
                Logger.Instance.LogInfo("Single succesfull");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogError("single failed.", ex);
            }

            try
            {
                this.shlist.SingleOrDefault(x => x > Magicvalue);
                Logger.Instance.LogInfo("SingleOrDefault succesfull");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogError("singleOrDefault failed.", ex);
            }

            this.shlist.ElementAt(0);
            Logger.Instance.LogInfo("ElementAt succesfull");
            this.shlist.ElementAtOrDefault(0);
            Logger.Instance.LogInfo("ElementAtOrDefault succesfull");
            this.shlist.Last();
            Logger.Instance.LogInfo("Last succesfull");
            this.shlist.LastOrDefault();
            Logger.Instance.LogInfo("LastOrDefault succesfull");
        }

        private void ThreeSecondsAction(object obj)
        {
            Logger.Instance.LogInfo("add async from threeseconaction");
            this.shlist.AddAsync(this.rand.Next());
            Logger.Instance.LogInfo($"shlist count:{this.shlist.Count}");
        }

        private void SevenSecondsAction(object obj)
        {
            Logger.Instance.LogInfo("distinkt from seven secon action");
            IReadOnlyCollection<int> bufferShlist = this.shlist.Distinct();
            this.shlist.Clear();
            this.shlist.AddRangeAsync(bufferShlist.ToArray());
        }
    }
}
