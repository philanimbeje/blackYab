using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackYab
{
    class Authenticator
    {
        public bool LoginAuthenticator(string username, string password)
        {
            Sqlfunctions function = new BlackYab.Sqlfunctions();
            return function.Login(username, password);
        }

        public string RegAuthenticator(string username, string name, string password, string t_name, string rounds, string break_round, string start_date, string end_date)
        {
            //empty fields
            //data validation
            //existance chack 
            return "";
        }
        
        public bool ErrorResponse(string error)
        {
            switch (error)
            {
                case "empty fields":
                    return false;
                default:
                    return false;
            }
        }
    }
}
