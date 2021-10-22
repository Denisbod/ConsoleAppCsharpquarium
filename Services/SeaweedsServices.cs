using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAppCsharpquarium.Services
{
    class SeaweedsServices
    {
        public Aquarium Habitat { get; protected set; }

        private SqlConnection oConn;

        public SeaweedsServices(SqlConnection oConn, Aquarium habitat)
        {
            this.oConn = oConn;
            this.Habitat= habitat;
        }
        public List<Seaweeds> GetSeaweeds()
        {
            try
            {
                oConn.Open();
                string requete = "select Id, PV, age FROM Seaweeds";
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = requete;
                SqlDataReader reader = cmd.ExecuteReader();
  
                while (reader.Read())
                {
                    Habitat.liste_algues.Add(new Seaweeds((int)reader["Id"], (int)reader["PV"], (int)reader["Age"], Habitat));
                }
                return Habitat.liste_algues;
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
        public int AddSeaweeds(Seaweeds algue)
        {
            try
            {
                oConn.Open();
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO Seaweeds OUTPUT inserted.Id VALUES (@p1, @p2)";
                cmd.Parameters.AddWithValue("p1", algue.PV);
                cmd.Parameters.AddWithValue("p2", algue.Age);
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
        public bool DeleteSeaweeds(Seaweeds algue)
        {
            try
            {
                oConn.Open();
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "DELETE FROM Seaweeds WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", algue.Id);
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
        public bool UpdateSeaweeds(Seaweeds algue)
        {
            try
            {
                oConn.Open();
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE Seaweeds SET PV = @p2, Age = @p3 WHERE Id = @p1";
                cmd.Parameters.AddWithValue("p1", algue.Id);
                cmd.Parameters.AddWithValue("p2", algue.PV);
                cmd.Parameters.AddWithValue("p3", algue.Age);
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
