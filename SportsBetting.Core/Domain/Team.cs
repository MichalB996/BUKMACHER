using System;
using System.Collections.Generic;

namespace SportsBetting.Core.Domain
{
    public class Team
    {
        public Guid Id { get; protected set; }
        public string TeamName { get; protected set; }
        public IEnumerable<string> MatchHistory { get; protected set; }

        protected Team(string name, IEnumerable<string> history)
        {
            TeamName = name;
            MatchHistory = history;
        }

        public static Team Create(string name, IEnumerable<string> history)
            => new Team(name, history);
    }
}