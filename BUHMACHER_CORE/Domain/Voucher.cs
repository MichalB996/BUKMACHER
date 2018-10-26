using System;
using System.Collections.Generic;
namespace BUKMACHER_CORE.Domain

{
    public class Voucher
    {
        public Guid Id { get; protected set; }
        public IDictionary<Match, int> Matches;
        public int CashToGet { get; protected set; }
        public int Tax { get; protected set; }
        public Bukmacher Bukmacher { get; protected set; }
        public int CashIn { get; protected set; }
        public int TotalCourse { get; protected set; }

        protected Voucher()
        {}
        protected Voucher(IDictionary<Match, int> matches, int tax, Bukmacher bukmacher, int cash)
        {
            CashIn = cash;
            Matches = matches;
            Id = Guid.NewGuid();
            Tax = tax;
            Bukmacher = bukmacher;
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
        public static Voucher Create(IDictionary<Match, int> matches, int tax, Bukmacher bukmacher, int cash)
            => new Voucher(matches, tax, bukmacher, cash);
    }
}