using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlackYab
{
    class Sqlfunctions
    {
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
        }//establish sql connection

        public bool Login(string name, string password)
        {
            int count = 0;
            string Username = "";
            string Pass = "";
            string Fullname = "";
            int Tid = 0;
            int role = 0;
            char Access = 'N';

            using (SqlConnection connection = getConnection())
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
                    return false;
                }
                
            }


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

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
