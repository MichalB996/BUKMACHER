using System;
using System.Collections.Generic;
namespace BUKMACHER_CORE.Domain

{
    public class Voucher
    {
        public Guid Id { get; protected set; }
        // public IEnumerable<Match, int> Matches { get; protected set; }
        public IDictionary<Match, int> Matches;
        public int CashToGet { get; protected set; }
        public int Tax { get; protected set; }
        public Bukmacher Bukmacher { get; protected set; }
        public int CashIn { get; protected set; }
        public int TotalCourse { get; protected set; }

        protected Voucher()
        {}
        public Voucher(IDictionary<Match, int> matches, int tax, Bukmacher bukmacher, int cash)
        {
            CashIn = cash;
            Matches = matches;
            Id = Guid.NewGuid();
            Tax = tax;
            Bukmacher = bukmacher;
            GenerateCashToGet();
        }
        public void GenerateCashToGet()
        {
            foreach(KeyValuePair<Match,int> match in Matches)
            {
                TotalCourse *= match.Value;
            }
            CashToGet = TotalCourse * CashIn;
        }

    }
}