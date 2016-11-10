using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Tesis_A
{
    class Mysql_Master
    {
        
        public static string conexion = string.Format(Program.server + Program.dbname + Program.dbuser + Program.dbpass);
        public MySqlConnection conectar = new MySqlConnection(conexion);
        public MySqlDataAdapter myslad;

        public List<System.Data.DataRow> msqldb_Select(string Tab, string Whe)
        {
            DataSet ds = new DataSet();
            string tabl = Tab;
            string query = "SELECT * FROM " + tabl + "" + Whe;
            myslad = new MySqlDataAdapter(query, conectar);
            myslad.Fill(ds);
            return ds.Tables[0].AsEnumerable().ToList();
        }

        public List<System.Data.DataRow> msqldb_Select_Fields(string Fields, string Tab, string Whe)
        {
            DataSet ds = new DataSet();
            string tabl = Tab;
            string query = "SELECT " + Fields + " FROM " + tabl + " " + Whe;
            myslad = new MySqlDataAdapter(query, conectar);
            myslad.Fill(ds);
            return ds.Tables[0].AsEnumerable().ToList();
        }

        public bool msqldb_insert_fields(string tabl,string fields, string val)
        {
            string query = "INSERT INTO " + tabl + " " + fields + " VALUES " + val;
            conectar.Open();
            MySqlCommand cmd = new MySqlCommand(query, conectar);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conectar.Close();
            return true;
        }


    }
}
