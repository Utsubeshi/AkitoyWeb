using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AkiToyWeb.Models
{
    public class ClsBD 
    {
        SqlConnection cn = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;

        public ClsBD() { }

        public ClsBD(string BD)
        {
            //cn = new SqlConnection("Data Source=ENVY;Initial Catalog=" + BD + ";Persist Security Info=True;User ID=usuarioSQL;Password=root123");
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings[ BD ].ConnectionString);

            cmd = new SqlCommand("", cn);
            da = new SqlDataAdapter(cmd);
        }

        internal DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            da.Fill(dt);
            return (dt.Rows.Count == 0 ? null : dt);
            //if (dt.Rows.Count == 0)
            //    return null;
            //return dt;
        }

        internal void Sentencia(string SQL)
        {
            cmd.CommandText = SQL;
        }

    }
}