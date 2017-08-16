using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BlackYab
{
    class Model
    {
        //fields
        #region Fields
        public string AdminName { get; set; }
        public string UserName { get; set; }
        public string TournamentName { get; set; }
        public int TournamentID { get; set; }
        public int RoleID { get; set; }
        public string Role { get; set; }
        public int CurrentRound { get; set; }
        public int Rounds { get; set; }
        public int BreakRound { get; set; }
        public string RoundMotion { get; set; }
        public int TotalTeams { get; set; }
        public int TotalSpeakers { get; set; }
        public int TotalAdjudicators { get; set; }
        public char canAccess { get; set; }

        public List<string> Teams =new List<string>();
        public List<string> Speakers = new List<string>();
        public List<string> Adjudicators = new List<string>();
        public List<string> Venues = new List<string>();
        public List<string> Institutions = new List<string>();
        public List<string> Orgcom = new List<string>();

        public DataTable TeamTable = new DataTable();
        public DataTable SpeakerTable = new DataTable();
        public DataTable AdjTable = new DataTable();
        public DataTable VenueTable = new DataTable();
        public DataTable InstitutionTable = new DataTable();
        public DataTable OrgcomTable = new DataTable();

        public DataTable GeneralReport = new DataTable();
        public DataTable SpeakerReport = new DataTable();
        public DataTable TeamReport = new DataTable();
        public DataTable AdjReport = new DataTable();
        public DataTable RoundReport = new DataTable(); 
        public DataTable VenueReport = new DataTable();
        public DataTable InstitutionReport = new DataTable();
        public DataTable AdminReport = new DataTable();

        public string session { get; set; }
        #endregion
    }
}