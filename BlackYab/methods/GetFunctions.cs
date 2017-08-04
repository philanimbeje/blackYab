using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;


namespace BlackYab
{
    class GetFunctions
    {
        Sqlfunctions sql = new Sqlfunctions();

        public void getTournamentDetails(Model model)
        {
            var tournament = sql.CompileList("select tournamentname from tournament where tournamentID='" + model.TournamentID + "'");
            model.TournamentName = Item(tournament);

            var Role = sql.CompileList("select rolename from role where roleID='" + model.RoleID + "'");
            model.Role = Item(Role);

            var CurrentRound = sql.CompileList("select CONVERT(varchar(10),roundnumber) from round where isCurrentRound='Y' and tournamentid='" + model.TournamentID + "'");
            model.CurrentRound = Convert.ToInt32(Item(CurrentRound));

            var Rounds = sql.CompileList("select CONVERT(varchar(10),rounds) from tournament where tournamentid='" + model.TournamentID + "'");
            model.Rounds = Convert.ToInt32(Item(Rounds));

            var BreakRound = sql.CompileList("select CONVERT(varchar(10),breakround) from tournament where tournamentid='" + model.TournamentID + "'");
            model.BreakRound = Convert.ToInt32(Item(BreakRound));

            var RoundMotion = sql.CompileList("select motion from motion where roundNumber='" + model.CurrentRound + "' and  tournamentid='" + model.TournamentID + "'");
            model.RoundMotion = Item(RoundMotion);

            var TotalTeams = sql.CompileList("select teamName from team  where tournamentid='" + model.TournamentID + "'");
            model.TotalTeams = TotalTeams.Count;

            var TotalAdjudicators = sql.CompileList("select adjname from adjudicator  where tournamentid='" + model.TournamentID + "'");
            model.TotalAdjudicators = TotalAdjudicators.Count;

            var TotalSpeakers = sql.CompileList("select speakername from speaker  where tournamentid='" + model.TournamentID + "'");
            model.TotalSpeakers = TotalSpeakers.Count;

            var query = "";

            query = "select teamName, count(s.teamID) as teamMembers, canBreak   from speaker s right join team t on t.teamid = s.teamID where t.tournamentID = '" + model.TournamentID + "' group by teamName, t.teamID, canBreak";
            model.TeamTable = sql.CompileTable(query);
            
            query = "select speakerName, institutionName, teamName from Speaker s join Institution i on s.institutionID = i.institutionID left join team t on s.teamID = t.teamID where s.tournamentID='" + model.TournamentID + "'";
            model.SpeakerTable = sql.CompileTable(query);

            query = "select adjName, institutionName, canbreak from adjudicator a join institution i on i.institutionID = a.institutionID where a.tournamentID='" + model.TournamentID + "'";
            model.AdjTable = sql.CompileTable(query);

            query = "select  institutionName, count(distinct speakerName)+count(distinct adjName) as NumberOfDebators from Institution i left join Adjudicator a on a.institutionID = i.institutionID left join Speaker s on s.institutionID = i.institutionID where s.tournamentID='" + model.TournamentID + "' or a.tournamentID='" + model.TournamentID + "' group by  institutionName";
            model.InstitutionTable = sql.CompileTable(query);

            query = "select venueName as Venue from venue v where v.tournamentID='" + model.TournamentID + "'";
            model.VenueTable = sql.CompileTable(query);

            query = "select Name, rolename as Role from admin a join role r on a.roleID = r.roleID where a.tournamentID='" + model.TournamentID + "'";
            model.OrgcomTable = sql.CompileTable(query);
        }
        
        
        
        private string Item(List<string> list)
        {
            string listItem = "";
            if (list.Count == 1)
            {
                foreach (string a in list)
                {
                    listItem = a;
                }
                return listItem;
            }
            else
            {
                return null;
            }
        }
    }
}
