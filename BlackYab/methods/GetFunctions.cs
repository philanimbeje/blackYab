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
        //List<string> inputString = new List<string>();
        Sqlfunctions sql = new Sqlfunctions();
        StoredProcedureFunctions ProcedureFunctions = new StoredProcedureFunctions();

        public DataTable getLogin(Model model)
        {
            var inputString = new List<string>();
            return ProcedureFunctions.getData(inputString, model, WordList.LoginTable);
        }

        public void TournamentDetails(Model model)
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

            var inputString = new List<string>();
            inputString.Add(""+model.TournamentID+"");

            model.TeamTable = ProcedureFunctions.getData(inputString, model, WordList.adminTeam);
            model.SpeakerTable = ProcedureFunctions.getData(inputString, model, WordList.adminSpeakers);
            model.AdjTable = ProcedureFunctions.getData(inputString, model, WordList.adminAdjudicators);
            model.InstitutionTable = ProcedureFunctions.getData(inputString, model, WordList.adminInstitutions);
            model.VenueTable = ProcedureFunctions.getData(inputString, model, WordList.adminVenue);
            model.OrgcomTable = ProcedureFunctions.getData(inputString, model, WordList.adminOrgcom);

            model.AdjReport= ProcedureFunctions.getData(inputString, model, WordList.reportAdjudicators);
            model.SpeakerReport = ProcedureFunctions.getData(inputString, model, WordList.reportSpeakers);
            model.TeamReport = ProcedureFunctions.getData(inputString, model, WordList.reportTeams);
            model.VenueReport = ProcedureFunctions.getData(inputString, model, WordList.reportVenues);
            model.InstitutionReport = ProcedureFunctions.getData(inputString, model, WordList.reportInstitutions);
            model.RoundReport = ProcedureFunctions.getData(inputString, model, WordList.reportRounds);
            //model.GeneralReport = ProcedureFunctions.getData(inputString, model, WordList.reportGeneral);
            model.AdminReport = ProcedureFunctions.getData(inputString, model, WordList.reportAdmins);
        }

        public string RequestInfo(Model model, WordList request, string Qvariable)
        {
            string info = "";
            var infoList = new List<string>();
            switch (request)
            {
                case WordList.getTeamID: infoList = sql.CompileList("select teamID from team where tournamentID='" + model.TournamentID + "' and teamName='"+ Qvariable[0] +"'");
                    info=Item(infoList); break;
            }
            return info;
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
