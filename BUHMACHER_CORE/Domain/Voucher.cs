using System;
using System.Collections.Generic;
namespace BUKMACHER_CORE.Domain

{
    public class Voucher
    {
        public Guid Id { get; protected set; }
        public IEnumerable<Match> Matches { get; protected set; }
        public int CashToGet { get; protected set; }
        public int Tax { get; protected set; }
        public Bukmacher Bukmacher { get; protected set; }

    }
}