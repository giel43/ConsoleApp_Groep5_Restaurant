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

    }
}
