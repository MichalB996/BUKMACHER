using System;
using System.Collections.Generic;

namespace BUKMACHER_CORE.Domain
{
    public class Match
    {
        public Guid Id { get; protected set; }
        public IEnumerable<Team> Teams { get; protected set; }
        public IEnumerable<int> Courses { get; protected set; }
        //public IDictionary<Te>
    }
}