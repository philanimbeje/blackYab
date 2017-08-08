using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BlackYab
{
    class InputFunctions
    {

        private List<string> inputString { get; set; }
        private Model info { get; set; }
        private string commandString { get; set; }
        Sqlfunctions sql = new Sqlfunctions();

        public void data(List<string> details, Model information, string cmdAction)
        {
            this.inputString = details;
            this.info = information;
            this.commandString = cmdAction;
            commandFunction();
        }
        
        private SqlCommand Action(SqlCommand cmd)
        {

            switch(this.commandString)
            {
                case "addTeam":  addTeamCommands(cmd); break;
                case "addAdjDebate": addAdjDebateCommands(cmd); break;
                case "addAdjScore": addAdjScoreCommands(cmd); break;
                case "addAdjudicator": addAdjudicatorCommands(cmd); break;
                case "addAdmin": addAdminCommands(cmd); break;
                case "addDebate": addDebateCommands(cmd); break;
                case "addInstitution": addInstitutionCommands(cmd); break;
                case "addMotion": addMotionCommands(cmd); break;
                case "addNewRole": addNewRoleCommands(cmd); break;
                case "addNewTournament": addNewTournamentCommands(cmd); break;
                case "addNewVenue": vCommands(cmd); break;
                case "addRound": addRoundCommands(cmd); break;
                case "addRoundTab": addRoundTabCommands(cmd); break;
                case "addSpeaker": addSpeakerCommands(cmd); break;
                case "addpeakerScore": addpeakerScoreCommands(cmd); break;
                case "addTeamDebate": addTeamDebateCommands(cmd); break;
                case "adminADJUDICATORE": adminADJUDICATORECommands(cmd); break;
                case "adminINSTITUTIONS": adminINSTITUTIONSCommands(cmd); break;
                case "adminORGCOM": adminORGCOMCommands(cmd); break;
                case "adminSPEAKERS": adminSPEAKERSCommands(cmd); break;
                case "adminTEAM": adminTEAMCommands(cmd); break;
                case "adminVENUE": adminVENUECommands(cmd); break;
                case "currentRound": currentRoundCommands(cmd); break;
                case "endSession": endSessionCommands(cmd); break;
                case "newSession": newSessionCommands(cmd); break;
                case "reportADJUDICATORS": reportADJUDICATORSCommands(cmd); break;
                case "reportADMIN": reportADMINCommands(cmd); break;
                case "reportINSTITUTIONS": reportINSTITUTIONSCommands(cmd); break;
                case "reportROUNDS": reportROUNDSCommands(cmd); break;
                case "reportSPEAKERS": reportSPEAKERSCommands(cmd); break;
                case "reportTEAMS": reportTEAMSCommands(cmd); break;
                case "reportVENUES": reportVENUESCommands(cmd); break;

            }
            return cmd;
        }

        private void commandFunction()
        {
            using (SqlConnection reg = sql.getConnection())
            {
                using (SqlCommand cmd = new SqlCommand(this.commandString, reg))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    reg.Open();
                    Action(cmd).ExecuteNonQuery();
                }
            }
        }


        #region Stored Procedure Functions
        private SqlCommand reportVENUESCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand reportTEAMSCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand reportSPEAKERSCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand reportROUNDSCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand reportINSTITUTIONSCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand reportADMINCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand reportADJUDICATORSCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand newSessionCommands(SqlCommand cmd)
        {
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = inputString[0];
            cmd.Parameters.Add("@tournamentID", SqlDbType.VarChar).Value = inputString[1];
            cmd.Parameters.Add("@sessionStart", SqlDbType.VarChar).Value = DateTime.Now;

            return cmd;
        }

        private SqlCommand endSessionCommands(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@sessionEnd", SqlDbType.VarChar).Value = DateTime.Now;

            return cmd;
        }

        private SqlCommand currentRoundCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand adminVENUECommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand adminTEAMCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand adminSPEAKERSCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand adminORGCOMCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand adminINSTITUTIONSCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand adminADJUDICATORECommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand addTeamDebateCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand addpeakerScoreCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand addSpeakerCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand addRoundTabCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand addRoundCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand vCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand addNewTournamentCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand addNewRoleCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand addMotionCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand addInstitutionCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand addDebateCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand addAdminCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand addAdjudicatorCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand addAdjScoreCommands(SqlCommand cmd)
        {
            return cmd;
        }

        private SqlCommand addAdjDebateCommands(SqlCommand cmd)
        {
            return cmd;
        }
        
        private SqlCommand addTeamCommands(SqlCommand cmd)
        {
            /*cmd.Parameters.Add("@teamName", SqlDbType.VarChar).Value = inputString[0];
            cmd.Parameters.Add("@tournamentID", SqlDbType.Int).Value = info.TournamentID;
            cmd.Parameters.Add("@canBreak", SqlDbType.Char).Value = inputString[1];
            cmd.Parameters.Add("@dateCreated", SqlDbType.DateTime).Value = DateTime.Now;*/

            return cmd;
        }
        #endregion
    }
}
