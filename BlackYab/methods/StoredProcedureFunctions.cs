using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BlackYab
{
    class StoredProcedureFunctions
    {
        private List<string> inputString { get; set; }
        private Model info { get; set; }
        private WordList cmdAction { get; set; }

        public void InputData(List<string> inputString, Model information, WordList cmdAction)
        {
            this.inputString = inputString;
            this.info = information;
            this.cmdAction = cmdAction;
            commandFunction(); 
        }
        public DataTable getData(List<string> inputString, Model information, WordList cmdAction)
        {
            this.inputString = inputString;
            this.info = information;
            this.cmdAction = cmdAction;
            return CompileTable();
        }
        public DataTable getData(List<string> inputString, WordList cmdAction)
        {
            this.inputString = inputString;
            this.cmdAction = cmdAction;
            return CompileTable();
        }
        private DataTable CompileTable()
        {
            var sql = new Sqlfunctions();
            DataTable table = new DataTable();

            var con = sql.getConnection();
            var cmd = new SqlCommand(Convert.ToString(cmdAction), con);
            cmd.CommandType = CommandType.StoredProcedure;
            var adapter = new SqlDataAdapter(StoredProcedureAction(cmd));
            adapter.Fill(table);

            return table;
        }//returns datatable from sent query 
        private SqlCommand StoredProcedureAction(SqlCommand cmd)
        {
            switch(this.cmdAction)
            {
                case WordList.addTeam:  addTeamCommands(cmd); break;
                case WordList.addAdjDebate: addAdjDebateCommands(cmd); break;
                case WordList.addAdjScore: addAdjScoreCommands(cmd); break;
                case WordList.addAdjudicator: addAdjudicatorCommands(cmd); break;
                case WordList.addAdmin: addAdminCommands(cmd); break;
                case WordList.addDebate: addDebateCommands(cmd); break;
                case WordList.addInstitution: addInstitutionCommands(cmd); break;
                case WordList.addMotion: addMotionCommands(cmd); break;
                case WordList.addNewRole: addNewRoleCommands(cmd); break;
                case WordList.addNewTournament: addNewTournamentCommands(cmd); break;
                case WordList.addNewVenue: addNewVenueCommands(cmd); break;
                case WordList.addRound: addRoundCommands(cmd); break;
                case WordList.addRoundTab: addRoundTabCommands(cmd); break;
                case WordList.addSpeaker: addSpeakerCommands(cmd); break;
                case WordList.addpeakerScore: addpeakerScoreCommands(cmd); break;
                case WordList.addTeamDebate: addTeamDebateCommands(cmd); break;
                case WordList.adminAdjudicators: adminADJUDICATORECommands(cmd); break;
                case WordList.adminInstitutions: adminINSTITUTIONSCommands(cmd); break;
                case WordList.adminOrgcom: adminORGCOMCommands(cmd); break;
                case WordList.adminSpeakers: adminSPEAKERSCommands(cmd); break;
                case WordList.adminTeam: adminTEAMCommands(cmd); break;
                case WordList.adminVenue: adminVENUECommands(cmd); break; 
                case WordList.currentRound: currentRoundCommands(cmd); break;
                case WordList.endSession: endSessionCommands(cmd); break;
                case WordList.newSession: newSessionCommands(cmd); break;
                case WordList.reportAdjudicators: reportADJUDICATORSCommands(cmd); break;
                case WordList.reportAdmins: reportADMINCommands(cmd); break;
                case WordList.reportInstitutions: reportINSTITUTIONSCommands(cmd); break;
                case WordList.reportRounds: reportROUNDSCommands(cmd); break;
                case WordList.reportSpeakers: reportSPEAKERSCommands(cmd); break;
                case WordList.reportTeams: reportTEAMSCommands(cmd); break;
                case WordList.reportVenues : reportVENUESCommands(cmd); break;
                case WordList.Login : loginCommands(cmd); break;
                case WordList.primeModelInformation: primeModelInformation(cmd); break;
                default: break;
            }
            return cmd;
        }
        private void commandFunction()
        {
            var sql = new Sqlfunctions();
            try
            {
                using (SqlConnection con = sql.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(Convert.ToString(cmdAction), con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        StoredProcedureAction(cmd).ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
            }
        }
        #region Stored Procedure Functions
        private SqlCommand primeModelInformation(SqlCommand cmd)
        {
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = inputString[0];
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = inputString[1];
            return cmd;
        }
        private SqlCommand loginCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = inputString[0];
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = inputString[1];
            return cmd;
        }
        private SqlCommand reportVENUESCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            return cmd;
        }
        private SqlCommand reportTEAMSCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            return cmd;
        }
        private SqlCommand reportSPEAKERSCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            return cmd;
        }
        private SqlCommand reportROUNDSCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            return cmd;
        }
        private SqlCommand reportINSTITUTIONSCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            return cmd;
        }
        private SqlCommand reportADMINCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            return cmd;
        }
        private SqlCommand reportADJUDICATORSCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            return cmd;
        }
        private SqlCommand newSessionCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = inputString[0];
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[1]);
            cmd.Parameters.Add("@sessionStart", SqlDbType.VarChar).Value = DateTime.Now;
            return cmd;
        }
        private SqlCommand endSessionCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@sessionEnd", SqlDbType.VarChar).Value = DateTime.Now;
            return cmd;
        }
        private SqlCommand currentRoundCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            return cmd;
        }
        private SqlCommand adminVENUECommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            return cmd;
        }
        private SqlCommand adminTEAMCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            return cmd;
        }
        private SqlCommand adminSPEAKERSCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            return cmd;
        }
        private SqlCommand adminORGCOMCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            return cmd;
        }
        private SqlCommand adminINSTITUTIONSCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            return cmd;
        }
        private SqlCommand adminADJUDICATORECommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            return cmd;
        }
        private SqlCommand addTeamDebateCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@debateID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            cmd.Parameters.Add("@teamID", SqlDbType.Int).Value = Convert.ToInt32(inputString[1]);
            cmd.Parameters.Add("@positionID", SqlDbType.Int).Value = Convert.ToInt32(inputString[2]);
            return cmd;
        }
        private SqlCommand addpeakerScoreCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@debateID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            cmd.Parameters.Add("@speakerID", SqlDbType.Int).Value = Convert.ToInt32(inputString[1]);
            cmd.Parameters.Add("@teamDeabate", SqlDbType.Int).Value = Convert.ToInt32(inputString[2]);
            cmd.Parameters.Add("@score", SqlDbType.Int).Value = Convert.ToInt32(inputString[3]);
            return cmd;
        }
        private SqlCommand addSpeakerCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@speakerName", SqlDbType.VarChar).Value = inputString[0];
            cmd.Parameters.Add("@institutionID", SqlDbType.Int).Value = Convert.ToInt32(inputString[1]);
            cmd.Parameters.Add("@teamID", SqlDbType.Int).Value = Convert.ToInt32(inputString[2]);
            cmd.Parameters.Add("@tournamnetID", SqlDbType.Int).Value = Convert.ToInt32(inputString[3]);
            cmd.Parameters.Add("@category", SqlDbType.Char).Value = Convert.ToChar(inputString[4]);
            cmd.Parameters.Add("@dateCreated", SqlDbType.DateTime).Value = Convert.ToDateTime(inputString[5]);
            return cmd;
        }
        private SqlCommand addRoundTabCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@roundNumber", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            cmd.Parameters.Add("@venueID", SqlDbType.Int).Value = Convert.ToInt32(inputString[1]);
            cmd.Parameters.Add("@team1", SqlDbType.Int).Value = Convert.ToInt32(inputString[2]);
            cmd.Parameters.Add("@team2", SqlDbType.Int).Value = Convert.ToInt32(inputString[3]);
            cmd.Parameters.Add("@team3", SqlDbType.Int).Value = Convert.ToInt32(inputString[4]);
            cmd.Parameters.Add("@team4", SqlDbType.Int).Value = Convert.ToInt32(inputString[5]);
            cmd.Parameters.Add("@adj", SqlDbType.VarChar).Value = inputString[6];
            cmd.Parameters.Add("@tournamnetID", SqlDbType.Int).Value = Convert.ToInt32(inputString[7]);
            return cmd;
        }
        private SqlCommand addRoundCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@roundNumber", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            cmd.Parameters.Add("@tournamentID", SqlDbType.Int).Value = Convert.ToInt32(inputString[1]);
            cmd.Parameters.Add("@breakround", SqlDbType.Char).Value = Convert.ToChar(inputString[2]);
            cmd.Parameters.Add("@currentround", SqlDbType.Char).Value = Convert.ToChar(inputString[3]);
            return cmd;
        }
        private SqlCommand addNewVenueCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@venueName", SqlDbType.VarChar).Value = inputString[0];
            cmd.Parameters.Add("@tournamentID", SqlDbType.Int).Value = Convert.ToInt32(inputString[1]);
            cmd.Parameters.Add("@datecreated", SqlDbType.DateTime).Value = Convert.ToDateTime(inputString[2]);
            return cmd;
        }
        private SqlCommand addNewTournamentCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@Tname", SqlDbType.VarChar).Value = inputString[0];
            cmd.Parameters.Add("@rounds", SqlDbType.Int).Value = Convert.ToInt32(inputString[1]);
            cmd.Parameters.Add("@breakRound", SqlDbType.Int).Value = Convert.ToInt32(inputString[2]);
            cmd.Parameters.Add("@Tstart", SqlDbType.DateTime).Value = Convert.ToDateTime(inputString[3]);
            cmd.Parameters.Add("@Tend", SqlDbType.DateTime).Value = Convert.ToDateTime(inputString[4]);
            return cmd;
        }
        private SqlCommand addNewRoleCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@roleName", SqlDbType.VarChar).Value = inputString[0];
            cmd.Parameters.Add("@roleDescription", SqlDbType.VarChar).Value = inputString[1];
            cmd.Parameters.Add("@tID", SqlDbType.Int).Value = Convert.ToInt32(inputString[2]);
            return cmd;
        }
        private SqlCommand addMotionCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@roundNumber", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            cmd.Parameters.Add("@tournamentID", SqlDbType.Int).Value = Convert.ToInt32(inputString[1]);
            cmd.Parameters.Add("@motion", SqlDbType.VarChar).Value = inputString[2];
            return cmd;
        }
        private SqlCommand addInstitutionCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@institutionName", SqlDbType.VarChar).Value = inputString[0];
            cmd.Parameters.Add("@local", SqlDbType.Char).Value = Convert.ToChar(inputString[1]);
            return cmd;
        }
        private SqlCommand addDebateCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@roundNumber", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            cmd.Parameters.Add("@tournamentID", SqlDbType.Int).Value = Convert.ToInt32(inputString[1]);
            cmd.Parameters.Add("@motionID", SqlDbType.Int).Value = Convert.ToInt32(inputString[2]);
            cmd.Parameters.Add("@venueID", SqlDbType.Int).Value = Convert.ToInt32(inputString[3]);
            return cmd;
        }
        private SqlCommand addAdminCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = inputString[0];
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = inputString[1];
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = inputString[2];
            cmd.Parameters.Add("@tournamentID", SqlDbType.Int).Value = Convert.ToInt32(inputString[3]);
            cmd.Parameters.Add("@roleID", SqlDbType.Int).Value = Convert.ToInt32(inputString[4]);
            cmd.Parameters.Add("@dateCreated", SqlDbType.DateTime).Value = Convert.ToDateTime(inputString[5]);
            cmd.Parameters.Add("@access", SqlDbType.Int).Value = Convert.ToChar(inputString[6]);
            return cmd;
        }
        private SqlCommand addAdjudicatorCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@adjName", SqlDbType.VarChar).Value = inputString[0];
            cmd.Parameters.Add("@institutionID", SqlDbType.Int).Value = Convert.ToInt32(inputString[1]);
            cmd.Parameters.Add("@tournamentID", SqlDbType.Int).Value = Convert.ToInt32(inputString[2]);
            cmd.Parameters.Add("@canBreak", SqlDbType.Char).Value = Convert.ToChar(inputString[3]);
            return cmd;
        }
        private SqlCommand addAdjScoreCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@debateID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            cmd.Parameters.Add("@AdjID", SqlDbType.Int).Value = Convert.ToInt32(inputString[1]);
            cmd.Parameters.Add("@adjDebateID", SqlDbType.Int).Value = Convert.ToInt32(inputString[2]);
            cmd.Parameters.Add("@score", SqlDbType.Int).Value = Convert.ToInt32(inputString[2]);
            return cmd;
        }
        private SqlCommand addAdjDebateCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@debateID", SqlDbType.Int).Value = Convert.ToInt32(inputString[0]);
            cmd.Parameters.Add("@AdjID", SqlDbType.Int).Value = Convert.ToInt32(inputString[1]);
            cmd.Parameters.Add("@ischair", SqlDbType.Char).Value = Convert.ToChar(inputString[2]);
            return cmd;
        }
        private SqlCommand addTeamCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@teamName", SqlDbType.VarChar).Value = inputString[0];
            cmd.Parameters.Add("@tournamentID", SqlDbType.Int).Value = Convert.ToInt32(inputString[1]);
            cmd.Parameters.Add("@canBreak", SqlDbType.Char).Value = Convert.ToChar(inputString[2]);
            cmd.Parameters.Add("@dateCreated", SqlDbType.DateTime).Value = Convert.ToDateTime(inputString[3]);
            return cmd;
        }
        #endregion
    }
}
