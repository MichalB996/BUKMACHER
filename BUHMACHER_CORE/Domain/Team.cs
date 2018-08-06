using System;
using System.Collections.Generic;

namespace BUKMACHER_CORE.Domain
{
    public class Team
    {
        public Guid Id { get; protected set; }
        public string TeamName { get; protected set; }
        public IEnumerable<string> MatchHistory { get; protected set; }

        public Team(string name, IEnumerable<string> history)
        {
            TeamName = name;
            MatchHistory = history;
        }
    }
}