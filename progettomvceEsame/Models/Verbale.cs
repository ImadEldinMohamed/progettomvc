using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace progettomvceEsame.Models
{
    public class Verbale
    {
        public int IDverbale { get; set; }

        public DateTime dataviolazione { get; set; }

        public string indirizzoViolazione { get; set; }

        public string nominativo_agente { get; set; }

        public DateTime DataTrascrizioneVerbale { get; set; }

        public double importo { get; set; }

        public int DecurtamentoPunti { get; set; }

        public int IDanagrafica { get; set; }   

        public int  IDviolazione { get; set; }

        public static List<Verbale> tuttiVerbali()
        {
            List<Verbale> Listaverbali = new List<Verbale>();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM VERBALE", conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Verbale v = new Verbale
                    {
                        IDverbale = Convert.ToInt16(reader["IDverbale"].ToString()),
                        dataviolazione = Convert.ToDateTime(reader["dataviolazione"].ToString()),
                        indirizzoViolazione = reader["indirizzoViolazione"].ToString(),
                        nominativo_agente = reader["nominativo_agente"].ToString(),
                        DataTrascrizioneVerbale = Convert.ToDateTime(reader["DataTrascrizioneVerbale"].ToString()),
                        importo=Convert.ToDouble(reader["importo"].ToString()),
                        DecurtamentoPunti = Convert.ToInt16(reader["DecurtamentoPunti"].ToString()),
                        IDanagrafica = Convert.ToInt16(reader["IDanagrafica"].ToString()),
                        IDviolazione= Convert.ToInt16(reader["IDviolazione"].ToString()),


                    };

                   Listaverbali.Add(v);
                }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

            return Listaverbali;
        }
        public static void CreaVerbale(DateTime dataviolazione,string indirizzoViolazione, string nominativo_agente, DateTime DataTrascrizioneVerbale, double importo, int DecurtamentoPunti,int IDanagrafica,int IDviolazione)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO VERBALE(dataviolazione,indirizzoViolazione,nominativo_agente,DataTrascrizioneVerbale,importo,Decurtamentopunti,IDanagrafica,IDviolazione) VALUES(@dataviolazione,@indirizzoViolazione,@nominativo_agente,@DataTrascrizioneVerbale,@importo,@Decurtamentopunti,@IDanagrafica,@IDviolazione)", conn);
                cmd.Parameters.AddWithValue("dataviolazione",dataviolazione );
                cmd.Parameters.AddWithValue("indirizzoViolazione", indirizzoViolazione);
                cmd.Parameters.AddWithValue("nominativo_agente", nominativo_agente);
                cmd.Parameters.AddWithValue("DataTrascrizioneVerbale", DataTrascrizioneVerbale);
                cmd.Parameters.AddWithValue("importo", importo);
                cmd.Parameters.AddWithValue("Decurtamentopunti", DecurtamentoPunti);
                cmd.Parameters.AddWithValue("IDanagrafica", IDanagrafica);
                cmd.Parameters.AddWithValue("IDviolazione", IDviolazione );
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