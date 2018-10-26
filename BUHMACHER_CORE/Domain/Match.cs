using System;
using System.Collections.Generic;
using System.Linq;

namespace BUKMACHER_CORE.Domain
{
    public class Match
    {
        public Guid Id { get; protected set; }
        public IEnumerable<Team> Teams { get; protected set; }
        public IEnumerable<int> Courses { get; protected set; }
        protected Match()
        { }
        protected Match(IEnumerable<Team> teams, IEnumerable<int> courses)
        {
            Teams = teams.ToList<Team>();
            Courses = courses.ToList<int>();                
        }
        protected Match(Team team_1, Team team_2, int course_1, int course_x, int course_2)
        {
            Teams.Append<Team>(team_1);
            Teams.Append<Team>(team_2);
            Courses.Append<int>(course_1);
            Courses.Append<int>(course_2);
            Courses.Append<int>(course_x);
        }
        public void AddTeam(Team team)
        {}
        public static Match Create(Team team_1, Team team_2, int course_1, int course_x, int course_2)
            => new Match(team_1, team_2, course_1, course_x, course_2);
    }
}