using System;
using System.Collections.Generic;
using System.Data; // ADO:n perusluokat
using System.Data.SqlClient; // SQL-serveriä varten
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H7ADOConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // basic steps
                // 1 luodaan yhteys
                string connStr = GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // avataan yhteys
                    conn.Open();
                    // 2 tehdään SQL-kysely, siitä luodaan Command-tyyppinen olio
                    string sql = "SELECT asioid, lastname, firstname FROM Presences WHERE asioid = 'H8699'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    // 3 käsitellään "tulos"
                    SqlDataReader rdr = cmd.ExecuteReader();
                    // Käydään reader-olio läpi, forward-only
                    if(rdr.HasRows)
                    {
                        while(rdr.Read())
                        {
                            Console.WriteLine("Läsnäolosi {0} {1} {2}",
                                rdr.GetString(0), rdr.GetString(1), rdr.GetString(2));
                        }
                        Console.WriteLine("Tiedot haettu onnistuneesti");
                    }
                    // Suljetaan tarvittavat
                    rdr.Close();
                    conn.Close();
                    Console.WriteLine("Tietokantayhteys suljettu onnistuneesti");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        private static string GetConnectionString()
        {
            // Luetaan connection string App.Configista
            return H7ADOConsoleDemo.Properties.Settings.Default.Tietokanta;
        }
    }
}
