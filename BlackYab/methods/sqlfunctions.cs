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
    class Sqlfunctions
    {
        public SqlConnection getConnection()
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

        public DataTable CompileTable(string query)
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
        }//returns datatable from sent query

        public List<string> CompileList(string query)
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
        }//returns list from sent query

    }
}
