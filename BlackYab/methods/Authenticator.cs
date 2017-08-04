using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlackYab
{
    class Authenticator
    {
        Sqlfunctions sql = new Sqlfunctions();

        public ErrorResponse LoginAuthenticator(string username, string password)
        {
            ErrorResponse error = new ErrorResponse();
            return Login(username, password, error);
        }

        public ErrorResponse Login(string name, string password, ErrorResponse error)
        {
            int count = 0;
            string Username = "";
            string Pass = "";
            string Fullname = "";
            int Tid = 0;
            int role = 0;
            char Access = 'N';

            using (SqlConnection connection = sql.getConnection())
            {
                SqlCommand command = new SqlCommand("select * from admin where username=@name and password=@password", connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@password", password);

                if (connection != null)
                {
                    connection.Open();
                    SqlDataReader rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        string username = rdr.GetString(0);
                        string userpassword = rdr.GetString(1);
                        string fullname = rdr.GetString(2);
                        int tournamentID = rdr.GetInt32(3);
                        int roleID = rdr.GetInt32(4);
                        char canAccess = Convert.ToChar(rdr.GetString(5));


                        if (username == name && userpassword == password)   //check if login details are correct
                        {
                            count++;
                            Username = username;
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
                    error.AccessBool = false;
                    error.ErrorType = "database connection issue";
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
                    model.UserName = Username;
                    model.canAccess = Access;
                    model.TournamentID = Tid;
                    model.RoleID = role;
                    get.getTournamentDetails(model);

                    Application.Current.Properties["Model"] = model;

                    error.AccessBool = true;
                    error.ErrorType = "Login successfull";
                    return error;
                }
                else
                {
                    error.AccessBool = false;
                    error.ErrorType = "User information inconsistancy";
                    return error;
                }
            }
            else
            {
                error.AccessBool = false;
                error.ErrorType = "User does not exist";
                return error;
            }
        }

        /*public ErrorResponse RegAuthenticator(ErrorResponse error, string username, string name, string password, string t_name, string rounds, string break_round, string start_date, string end_date)
        {
            //empty fields
            //data validation
            //existance chack 
            return error;
        }*/
    }
}
