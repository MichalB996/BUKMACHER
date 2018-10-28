using System;
using System.Collections.Generic;
namespace SportsBetting.Core.Domain

{
    public class Voucher
    {
        public Guid Id { get; protected set; }
        public IDictionary<Match, int> Matches;
        public int CashToGet { get; protected set; }
        public int Tax { get; protected set; }
        public Bookmaker Bookmaker { get; protected set; }
        public int CashIn { get; protected set; }
        public int TotalCourse { get; protected set; }

        protected Voucher()
        {}

        protected Voucher(IDictionary<Match, int> matches, int tax, Bookmaker bookmaker, int cash)
        {
            CashIn = cash;
            Matches = matches;
            Id = Guid.NewGuid();
            Tax = tax;
            Bookmaker = bookmaker;
        }

        public void GenerateCashToGet()
        {
            foreach(KeyValuePair<Match,int> match in Matches)
            {
                TotalCourse *= match.Value;
            }
            CashToGet = TotalCourse * CashIn;
        }

        public void AddMatch(Match match,int course)
        {
            Matches.Add(match, course);
        }

        public static Voucher Create(IDictionary<Match, int> matches, int tax, Bookmaker SportsBetting, int cash)
            => new Voucher(matches, tax, SportsBetting, cash);
    }
}