using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace progettomvceEsame.Models
{
    public class Violazione
    {
        public int IDviolazione { get; set; }
        public string descrizione {  get; set; }

        public static List<Violazione> tutteViolazioni()
        {
            List<Violazione> Listaviolazioni = new List<Violazione>();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM TIPO_VIOLAZIONE", conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Violazione v = new Violazione
                    {
                        IDviolazione = Convert.ToInt16(reader["IDviolazione"].ToString()),
                        descrizione = reader["descrizione"].ToString(),
                       

                    };

                    Listaviolazioni.Add(v);
                }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

            return Listaviolazioni;
        }

        public static void CreaViolazione(string descrizione)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TIPO_VIOLAZIONE(descrizione) VALUES(@descrizione)", conn);
                cmd.Parameters.AddWithValue("descrizione",descrizione);
             
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }
        }

    }
}