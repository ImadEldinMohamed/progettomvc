using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace progettomvceEsame.Models
{
    public class jolnberbale
    {
        //questa è la classe che ho creato per fare la select inner join tra anagrafica e verbale(la prima select) ma segna errore nonostante la select funzioni su sql server
        public int IDanagrafica { get; set; }
        public string nome { get; set; }    

        public string cognome { get; set; }

        public string conteggioverbali { get; set; }


        public static List<jolnberbale> conteggio()
        {     
            List<jolnberbale> ListaTrasgressori = new List<jolnberbale>();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(" SELECT cognome,nome ,count(*) as conteggioverbali from VERBALE as V inner join ANAGRAFICA as A on V.IDanagrafica=A.IDanagrafica GROUP BY cognome,nome", conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    jolnberbale a = new jolnberbale
                    {
                        IDanagrafica = Convert.ToInt16(reader["IDanagrafica"].ToString()),
                        cognome = reader["cognome"].ToString(),
                        nome = reader["nome"].ToString(),
                        conteggioverbali = reader["conteggioverbali"].ToString(),

                    };

                    ListaTrasgressori.Add(a);
                }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

            return ListaTrasgressori;
        }

    }
}