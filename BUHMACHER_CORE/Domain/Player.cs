using System;
using System.Collections.Generic;
using System.Text;

namespace BUKMACHER_CORE.Domain
{
    class Player
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public Voucher Voucher { get; protected set; }
    }
}
