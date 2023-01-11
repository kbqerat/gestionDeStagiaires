using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_stagaire
{
    class Functions
    {
        private SqlConnection con;
        private SqlCommand cmd;
        public DataTable dt;
        public DataTable publicDt
        {
            get { return dt; }
        }
        private SqlDataAdapter sda;
        private string connectionString;

        public Functions()
        {
            connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=gestion_stagaire;Integrated Security=True";
            con = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, connectionString);
            sda.Fill(dt);
            return dt;
        }
        public int SetData(string Query)
        {
            int cnt = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = Query;
            cmd.ExecuteNonQuery();
            con.Close();
            return cnt;
        }
    }
}
