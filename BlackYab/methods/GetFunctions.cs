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
        DataTable dt = new DataTable();
        #region Lists
        public List<string> AllTeams(Model info)
        {
            return
            CompileList("select teamName from team where tournamentid='" + info.TournamentID + "'");
        }

        public List<string> AllAdjudicators(Model info)
        {
            return
            CompileList("select adjname from adjudicator where tournamentid='" + info.TournamentID + "'");
        }

        public List<string> AllUsers(Model info)
        {
            return
            CompileList("select name from admin where tournamentid='" + info.TournamentID + "'");
        }

        public List<string> AllInstitutions(Model info)
        {
            return
            CompileList("select institutionName from institution");
        }

        public List<string> AllMotions(Model info)
        {
            return
            CompileList("select motion from motion where tournamentid='" + info.TournamentID + "'");
        }

        public List<string> AllRoles(Model info)
        {
            return
            CompileList("select roleName from role where tournamentid='" + info.TournamentID + "'");
        }

        public List<string> AllRounds(Model info)
        {
            return
            CompileList("select roundnumber from round where tournamentid='" + info.TournamentID + "'");
        }

        public List<string> AllSpeakers(Model info)
        {
            return
            CompileList("select speakerName from speaker where tournamentid='" + info.TournamentID + "'");
        }

        public List<string> AllTournaments(Model info)
        {
            return
            CompileList("select tournamentName from tournament where tournamentid='" + info.TournamentID + "'");
        }

        public List<string> AllVenues(Model info)
        {
            return
            CompileList("select venueName from venue where tournamentid='" + info.TournamentID + "'");
        }
        #endregion

        #region View Tables
        public DataTable V_speakers()
        {
            return
                CompileTable("select speakerName, institutionName, teamName from Speaker s join Institution i on s.institutionID = i.institutionID left join team t on s.teamID = t.teamID");
        }
        public DataTable V_teams()
        {
            return
                CompileTable("select teamName, count(t.teamID) as teamMembers, canBreak   from speaker s join team t on t.teamid = s.teamID group by teamName, t.teamID, canBreak");
        }
        public DataTable V_adjudicators()
        {
            return
                CompileTable("select adjName, institutionName, canbreak from adjudicator a join institution i on i.institutionID = a.institutionID");
        }


        public DataTable V_institutions()
        {
            return
                CompileTable("select institutionName, count(speakerName) as numberOfDebators from Institution i join speaker s on i.institutionID = s.institutionID group by institutionName");
        }
        public DataTable V_admins()
        {
            return
                CompileTable("select Name, rolename as Role from admin a join role r on a.roleID = r.roleID");
        }
        public DataTable V_venues()
        {
            return
                CompileTable("select venueName as Venue from venue");
        }
        #endregion

        #region Report Tables
        public DataTable R_speakers()
        {
            return
                CompileTable("select speakerName, teamName, institutionName from Speaker s join Institution i  on s.institutionID=i.institutionID join Team t on t.teamID=s.teamID");
        }
        public DataTable R_teams()
        {
            return
                CompileTable("select * from team");
        }
        public DataTable R_adjudicators()
        {
            return
                CompileTable("select * from adjudicator");
        }
        public DataTable R_venues()
        {
            return
                CompileTable("select * from venue");
        }
        public DataTable R_rounds()
        {
            return
                CompileTable("select * from round");
        }
        #endregion


        #region GENERAL
        private int getCount(string query)
        {
            int count = 0;

            using (SqlConnection con = getConnection())
            {
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader rdr = comm.ExecuteReader();

                    while (rdr.Read())
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private DataTable CompileTable(string query)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = getConnection())
                {
                    con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    SqlCommandBuilder comm = new SqlCommandBuilder(adapter);

                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    adapter.Fill(table);
                }
            }
            catch (SqlException)
            {

            }
            return table;
        }

        private SqlConnection getConnection()
        {
            try
            {
                var connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["BYDatabase"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionstring);
                return connection;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<string> CompileList(string query)
        {
            List<string> list = new List<string>();

            using (SqlConnection con = getConnection())
            {
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader rdr = comm.ExecuteReader();

                    while (rdr.Read())
                    {
                        list.Add(rdr.GetString(0));
                    }
                }
            }
            return list;
        }

        public void getTournamentDetails(Model model)
        {
            var tournament = this.CompileList("select tournamentname from tournament where tournamentID='" + model.TournamentID + "'");
            model.TournamentName = Item(tournament);

            var Role = this.CompileList("select rolename from role where roleID='" + model.RoleID + "'");
            model.Role = Item(Role);

            var CurrentRound = this.CompileList("select CONVERT(varchar(10),roundnumber) from round where isCurrentRound='Y' and tournamentid='" + model.TournamentID + "'");
            model.CurrentRound = Convert.ToInt32(Item(CurrentRound));

            var Rounds = this.CompileList("select CONVERT(varchar(10),rounds) from tournament where tournamentid='" + model.TournamentID + "'");
            model.Rounds = Convert.ToInt32(Item(Rounds));

            var BreakRound = this.CompileList("select CONVERT(varchar(10),breakround) from tournament where tournamentid='" + model.TournamentID + "'");
            model.BreakRound = Convert.ToInt32(Item(BreakRound));

            var RoundMotion = this.CompileList("select motion from motion where roundNumber='" + model.CurrentRound + "' and  tournamentid='" + model.TournamentID + "'");
            model.RoundMotion = Item(RoundMotion);

            var TotalTeams = this.CompileList("select teamName from team  where tournamentid='" + model.TournamentID + "'");
            model.TotalTeams = TotalTeams.Count;

            var TotalAdjudicators = this.CompileList("select adjname from adjudicator  where tournamentid='" + model.TournamentID + "'");
            model.TotalAdjudicators = TotalAdjudicators.Count;

            var TotalSpeakers = this.CompileList("select speakername from speaker  where tournamentid='" + model.TournamentID + "'");
            model.TotalSpeakers = TotalSpeakers.Count;

            var query = "";

            query = "select teamName, count(s.teamID) as teamMembers, canBreak   from speaker s right join team t on t.teamid = s.teamID where t.tournamentID = '" + model.TournamentID + "' group by teamName, t.teamID, canBreak";
            model.TeamTable = Table(query);
            
            query = "select speakerName, institutionName, teamName from Speaker s join Institution i on s.institutionID = i.institutionID left join team t on s.teamID = t.teamID where s.tournamentID='" + model.TournamentID + "'";
            model.SpeakerTable = Table(query);

            query = "select adjName, institutionName, canbreak from adjudicator a join institution i on i.institutionID = a.institutionID where a.tournamentID='" + model.TournamentID + "'";
            model.AdjTable = Table(query);

            query = "select  institutionName, count(distinct speakerName)+count(distinct adjName) as NumberOfDebators from Institution i left join Adjudicator a on a.institutionID = i.institutionID left join Speaker s on s.institutionID = i.institutionID where s.tournamentID='" + model.TournamentID + "' or a.tournamentID='" + model.TournamentID + "' group by  institutionName";
            model.InstitutionTable = Table(query);

            query = "select venueName as Venue from venue v where v.tournamentID='" + model.TournamentID + "'";
            model.VenueTable = Table(query);

            query = "select Name, rolename as Role from admin a join role r on a.roleID = r.roleID where a.tournamentID='" + model.TournamentID + "'";
            model.OrgcomTable = Table(query);

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

        private DataTable Table(string query)
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = getConnection())
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    SqlCommandBuilder comm = new SqlCommandBuilder(adapter);

                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    adapter.Fill(table);
                }
            }
            catch (SqlException)
            {
                //MessageBox.Show("something happened on team");
            }
            return table;
        }
        #endregion
    }
}
