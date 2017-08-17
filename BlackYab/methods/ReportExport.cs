using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


namespace BlackYab
{
    class ExportReport
    {
        private WordList exportType { get; set; }
        private System.Data.DataTable data { get; set; }
        private Model model { get; set; }
        private string path { get; set; }

        public ExportReport(System.Data.DataTable data, string path)
        {
            this.data = data;
            this.path = path;

            exportCSV();
        }

        private void exportCSV()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Columns.Count; i++)
            {
                sb.Append(data.Columns[i]);
                if (i < data.Columns.Count - 1)
                    sb.Append(',');
            }
            sb.AppendLine();
            foreach (DataRow dr in data.Rows)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    sb.Append(dr[i].ToString());

                    if (i < data.Columns.Count - 1)
                        sb.Append(',');
                }
                sb.AppendLine();
            }
            File.WriteAllText(@"C:\desktop\BlackYAB - "+path+".csv", Convert.ToString(sb));
        }
    }
}
