using System;
using System.Collections.Generic;
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
        //ErrorResponse error = new ErrorResponse();
        #region Properties
        private string username { get; set; }
        private string password { get; set; }

        private string name { get; set; }
        private string t_name { get; set; }
        private string rounds { get; set; }
        private string break_round { get; set; }
        private string start_date { get; set; }
        private string end_date { get; set; }

        public ErrorResponse error { get; set; }
        #endregion

        #region Constructors
        public DataAuthenticator(WordList AutheticateRequest, List<string> registerDetails)
        {
            

            switch(AutheticateRequest)
            {
                case WordList.Login:
                    username = registerDetails[0];
                    password = registerDetails[1];
                    error = LoginAuthenticator();
                    break;
                case WordList.Register:
                    username = registerDetails[0];
                    name = registerDetails[1];
                    password = registerDetails[2];
                    t_name = registerDetails[3];
                    rounds = registerDetails[4];
                    break_round = registerDetails[5];
                    start_date = registerDetails[6];
                    end_date = registerDetails[7];
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
            int count = 0;
            string UsernameHold = "";
            string Pass = "";
            string Fullname = "";
            int Tid = 0;
            int role = 0; 
            char Access = 'N';

            using (SqlConnection connection = sql.getConnection())
            {
                SqlCommand command = new SqlCommand("select * from admin where username=@name and password=@password", connection);
                command.Parameters.AddWithValue("@name", username);
                command.Parameters.AddWithValue("@password", password);

                if (connection != null) 
                {
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        string user_name = rdr.GetString(0);
                        string userpassword = rdr.GetString(1);
                        string fullname = rdr.GetString(2);
                        int tournamentID = rdr.GetInt32(3);
                        int roleID = rdr.GetInt32(4);
                        char canAccess = Convert.ToChar(rdr.GetString(5));


                        if (user_name == username && userpassword == password)   //check if login details are correct
                        {
                            count++;
                            UsernameHold = user_name;
                            Pass = userpassword;
                            Fullname = fullname;
                            Tid = tournamentID;
                            role = roleID;
                            Access = canAccess;
                        }
                    }
                }
                else
                {
                    error = new ErrorResponse(false, WordList.Database_connection_issue);
                    return error;
                }

            }

            if (count != 0)
            {
                if (count == 1)
                {
                    Model model = new Model();
                    GetFunctions get = new BlackYab.GetFunctions();

                    model.AdminName = Fullname;
                    model.UserName = UsernameHold;
                    model.canAccess = Access;
                    model.TournamentID = Tid;
                    model.RoleID = role;
                    get.getTournamentDetails(model);

                    Application.Current.Properties["Model"] = model;

                    error = new ErrorResponse(true);
                    return error;
                }
                else
                {
                    error = new ErrorResponse(false, WordList.User_information_inconsistancy);
                    return error;
                }
            }
            else
            {
                error = new ErrorResponse(false, WordList.User_does_not_exist);
                return error;
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
