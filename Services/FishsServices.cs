using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAppCsharpquarium.Services
{
    class FishsServices
    {
        public Aquarium Habitat { get; protected set; }

        private SqlConnection oConn;

        public FishsServices(SqlConnection oConn, Aquarium habitat)
        {
            this.oConn = oConn;
            this.Habitat = habitat;
        }
        public List<Fishs> GetFishs()
        {
            try
            {
                oConn.Open();
                string requete = "select * FROM Fishs";
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = requete;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Habitat.liste_poissons.Add(new Fishs((int)reader["Id"], (int)reader["PV"], (int)reader["Age"], (string)reader["Name"],(Gender)reader["Sex"], (Races)reader["Race"], Habitat));
                }
                return Habitat.liste_poissons;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oConn.Close();
            }
        }
        public int AddFishs(Fishs poisson)
        {
            try
            {
                oConn.Open();
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO Fishs OUTPUT inserted.Id VALUES (@p1, @p2, @p3, @p4, @p5)";
                cmd.Parameters.AddWithValue("p1", poisson.PV);
                cmd.Parameters.AddWithValue("p2", poisson.Age);
                cmd.Parameters.AddWithValue("p3", poisson.Name);
                cmd.Parameters.AddWithValue("p4", (int)poisson.Sex);
                cmd.Parameters.AddWithValue("p5", (int)poisson.Race);
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oConn.Close();
            }
        }
        public bool DeleteFishs(Fishs poisson)
        {
            try
            {
                oConn.Open();
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "DELETE FROM Fishs WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", poisson.Id);
                return cmd.ExecuteNonQuery() != 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oConn.Close();
            }
        }
        public bool UpdateFishs(Fishs poisson)
        {
            try
            {
                oConn.Open();
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE Fishs SET PV = @p2, Age = @p3, Sex = @p4 WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", poisson.Id);
                cmd.Parameters.AddWithValue("p2", poisson.PV);
                cmd.Parameters.AddWithValue("p3", poisson.Age);
                cmd.Parameters.AddWithValue("p4", (int)poisson.Sex);
                return cmd.ExecuteNonQuery() != 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oConn.Close();
            }
        }

    }
}
