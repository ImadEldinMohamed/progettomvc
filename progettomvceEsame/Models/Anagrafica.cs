using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace progettomvceEsame.Models
{
    public class Anagrafica
    {
        public int IDanagrafica { get; set; }


        public string cognome { get; set; }


        public string nome { get; set; }

        public string indirizzo { get; set; }

        public string citta { get; set; }

        public string cap { get; set; }

        public string codicefiscale { get; set; }

        public static List<Anagrafica> tuttitrasgressori()
        {
            List<Anagrafica> ListaTrasgressori = new List<Anagrafica>();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ANAGRAFICA", conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Anagrafica a = new Anagrafica
                    {
                        IDanagrafica = Convert.ToInt16(reader["IDanagrafica"].ToString()),
                        cognome = reader["cognome"].ToString(),
                        nome = reader["nome"].ToString(),
                        indirizzo = reader["indirizzo"].ToString(),
                        citta = reader["citta"].ToString(),
                        cap = reader["cap"].ToString(),
                        codicefiscale = reader["codicefiscale"].ToString(),

                    };

                    ListaTrasgressori.Add(a);
                }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

            return ListaTrasgressori;
        }

        public static void CreaTrasgressore(string cognome,string nome,string indirizzo,string citta,string cap,string codicefiscale)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ANAGRAFICA(cognome,nome,indirizzo,citta,cap,codicefiscale) VALUES(@cognome,@nome,@indirizzo,@citta,@cap,@codicefiscale)", conn);
                cmd.Parameters.AddWithValue("cognome", cognome);
                cmd.Parameters.AddWithValue("nome", nome);
                cmd.Parameters.AddWithValue("indirizzo", indirizzo);
                cmd.Parameters.AddWithValue("citta",citta);
                cmd.Parameters.AddWithValue("cap", cap);
                cmd.Parameters.AddWithValue("codicefiscale",codicefiscale);
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