using ConsoleApp_Groep5_Restaurant.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Groep5_Restaurant.DattaAcces
{
    public class DAL
    {
        private readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=RestaurantDB_V1;Integrated Security=True;Trust Server Certificate=True";

        public DAL()
        { }

        public void VoegGastToeAanDB(Gast gast)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO dbo.Gast(Naam,TelefoonNummer)
                                            Values(@Naam,@TelefoonNummer)";
                    command.Parameters.AddWithValue("@Naam", gast.Naam);
                    command.Parameters.AddWithValue("@TelefoonNummer", gast.TelefoonNummer);
                    command.ExecuteNonQuery();

                }
            }
        }
        public void VoegReserveringToeAanDB(Reservering reservering)
        {
            int gastID = 0;
            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT id
                                            FROM Gast
                                            WHERE Naam = @Naam AND TelefoonNummer = @TelefoonNummer";
                    command.Parameters.AddWithValue("@Naam", reservering.gast.Naam);
                    command.Parameters.AddWithValue("@TelefoonNummer", reservering.gast.TelefoonNummer);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gastID = reader.GetInt32(0);
                        }
                    }
                    connection.Close();

                }
                using (SqlCommand command = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO dbo.Reservering(GastID,DatumTijd,AantalPersonen)
                                            Values(@GastID,@DatumTijd,@AantalPersonen)";
                    command.Parameters.AddWithValue("@GastID", gastID);
                    command.Parameters.AddWithValue("@DatumTijd", reservering.DatumTijd);
                    command.Parameters.AddWithValue("@AantalPersonen", reservering.AantalPersonen);
                    command.ExecuteNonQuery();

                }
            }
        }
        
        public List<Reservering> HaalReserveringOpUitDB()
        {
            List<Reservering> reserveringen = new List<Reservering>();
            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"select g.Naam,g.TelefoonNummer, r.AantalPersonen, r.DatumTijd
                                            from Reservering R
                                            Join Gast G on R.GastID = g.Id";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reservering reservering = new Reservering();
                            reservering.gast = new Gast(reader.GetString(0),reader.GetString(1));
                            reservering.AantalPersonen = reader.GetInt32(2);
                            reservering.DatumTijd = reader.GetDateTime(3);

                            reserveringen.Add(reservering);
                        }
                    }
                    connection.Close();

                }
            }

            return reserveringen;
        }
    }
}
