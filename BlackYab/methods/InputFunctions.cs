﻿using System;
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
        private string cmdAction { get; set; }
        Sqlfunctions sql = new Sqlfunctions();

        public void Data(List<string> inputString, Model information, string cmdAction)
        {
            this.inputString = inputString;
            this.info = information;
            this.cmdAction = cmdAction;
            commandFunction();
        }
        
        private SqlCommand Action(SqlCommand cmd)
        {

            switch(this.cmdAction)
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
                case "addNewVenue": addNewVenueCommands(cmd); break;
                case "addRound": addRoundCommands(cmd); break;
                case "addRoundTab": addRoundTabCommands(cmd); break;
                case "addSpeaker": addSpeakerCommands(cmd); break;
                case "addpeakerScore": addpeakerScoreCommands(cmd); break;
                case "addTeamDebate": addTeamDebateCommands(cmd); break;
                case "adminAdjudicator": adminADJUDICATORECommands(cmd); break;
                case "adminIntitution": adminINSTITUTIONSCommands(cmd); break;
                case "adminOrgcom": adminORGCOMCommands(cmd); break;
                case "adminSpeaker": adminSPEAKERSCommands(cmd); break;
                case "adminTeam": adminTEAMCommands(cmd); break;
                case "adminVenue": adminVENUECommands(cmd); break; 
                case "currentRound": currentRoundCommands(cmd); break;
                case "endSession": endSessionCommands(cmd); break;
                case "newSession": newSessionCommands(cmd); break;
                case "reportAdjudicators": reportADJUDICATORSCommands(cmd); break;
                case "reportAdmins": reportADMINCommands(cmd); break;
                case "reportInstitutions": reportINSTITUTIONSCommands(cmd); break;
                case "reportRounds": reportROUNDSCommands(cmd); break;
                case "reportSpeakers": reportSPEAKERSCommands(cmd); break;
                case "reportTeams": reportTEAMSCommands(cmd); break;
                case "reportVenues": reportVENUESCommands(cmd); break;
            }
            return cmd;
        }

        private void commandFunction()
        {
            using (SqlConnection reg = sql.getConnection())
            {
                using (SqlCommand cmd = new SqlCommand(this.cmdAction, reg))
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
