using System.Collections.Generic;
namespace BUKMACHER_CORE.Domain

{
    public class Voucher
    {
        public IEnumerable<Match> Matches { get; protected set; }
        public int CashToGet { get; protected set; }
        public int Tax { get; protected set; }

    }
}