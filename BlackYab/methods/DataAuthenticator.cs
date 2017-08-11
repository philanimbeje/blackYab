using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlackYab
{
    class DataAuthenticator
    {
        Sqlfunctions sql = new Sqlfunctions();
        StoredProcedureFunctions ProcedureFunction = new StoredProcedureFunctions();
        //ErrorResponse error = new ErrorResponse();
        #region Properties
        private string username { get; set; }
        private string password { get; set; }
        private List<string> loginDetails { get; set; }
        private string name { get; set; }
        private string t_name { get; set; }
        private string rounds { get; set; }
        private string break_round { get; set; }
        private string start_date { get; set; }
        private string end_date { get; set; }
        private List<string> regDetails { get; set; } 

        public ErrorResponse error { get; set; }
        #endregion

        #region Constructors
        public DataAuthenticator(WordList AutheticateRequest, List<string> inputDetails)
        {
            

            switch(AutheticateRequest) 
            {
                case WordList.Login:
                    username = inputDetails[0];
                    password = inputDetails[1];
                    loginDetails = inputDetails;
                    error = LoginAuthenticator();
                    break;
                case WordList.Register:
                    username = inputDetails[0];
                    name = inputDetails[1];
                    password = inputDetails[2];
                    t_name = inputDetails[3];
                    rounds = inputDetails[4];
                    break_round = inputDetails[5];
                    start_date = inputDetails[6];
                    end_date = inputDetails[7];
                    regDetails = inputDetails;
                    error = RegisterAuthenticator();
                    break;
                default: error= new ErrorResponse();
                    break;
            }
        }

        private DataAuthenticator()
        {
            error = new ErrorResponse();
        }
        #endregion

        #region Methods
        //not sure if i need this function, its behaving like a middle-man method---this is smelly
        private ErrorResponse LoginAuthenticator()
        {
            //TODO: checked for empty textboxes
            return Login();
        }

        private ErrorResponse RegisterAuthenticator()
        {
            return Register();
        }

        private ErrorResponse Login()
        {
            Model model = new Model();
            var loginCheck = ProcedureFunction.getData(loginDetails, WordList.Login);
            bool emptyCheckTable = loginCheck.Rows.Count == 0;
            if(emptyCheckTable)
            {
                return new ErrorResponse(false, WordList.User_does_not_exist);
            }

            var getTournamentDetails=ProcedureFunction.getData(loginDetails, model, WordList.primeModelInformation);
            bool checkTableData = loginCheck.Rows.Count == 1;
            if (checkTableData)
            {
                foreach (DataRow row in getTournamentDetails.Rows)
                {
                    model.UserName = (string)row["username"];
                    model.AdminName = (string)row["name"];
                    model.TournamentID= (int)row["tournamentID"];
                    model.TournamentName= (string)row["tournamentName"];
                    model.RoleID= (int)row["roleID"];
                    model.Role= (string)row["roleName"];
                    model.canAccess= Convert.ToChar(row["canAccessBlackYAB"]);

                    Application.Current.Properties["Model"] = model;
                }
                return new ErrorResponse(true, WordList.Login_successful);
            }
            else
            {
                return new ErrorResponse(false, WordList.Undescribed_error_detected);
            }
        }

        public ErrorResponse Register()
        {
            //empty fields
            //data validation
            //existance check 
            return error;
        }
        #endregion
    }
}
