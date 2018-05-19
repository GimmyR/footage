using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Footage.Models {

    public class ClientDAO {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTS :

        public ClientDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // PROPERTIES :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODS :

        private int ExecuteUpdate(SqlCommand cmd, Client model) {

            cmd.CommandText = "UPDATE Client SET pseudo=@val1, password=@val2, solde=@val3 WHERE id=@val4";
            cmd.Parameters.AddWithValue("@val1", model.Pseudo);
            cmd.Parameters.AddWithValue("@val2", model.Password);
            cmd.Parameters.AddWithValue("@val3", model.Solde);
            cmd.Parameters.AddWithValue("@val4", model.Id);

            return cmd.ExecuteNonQuery();

        }

        public int Update(Client model) {

            int result = -1;

            connexion.Open(); using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteUpdate(cmd, model);

            }
            connexion.Close();

            return result;

        }

        private Client Map(SqlDataReader reader) {

            String id = reader["id"].ToString();
            String pseudo = reader["pseudo"].ToString();
            String password = reader["password"].ToString();
            double solde = double.Parse(reader["solde"].ToString());

            return new Client(id, pseudo, password, solde);

        }

        private Client ExecuteSelectOne(SqlCommand cmd, String condition) {

            Client result = null;
            
            string cond = "";
            if (condition != null)
                cond = " " + condition;
            cmd.CommandText = "SELECT id, pseudo, password, solde FROM Client" + cond;
            using (SqlDataReader reader = cmd.ExecuteReader()) {

                if(reader.Read())
                    result = this.Map(reader);

            } return result;

        }

        public Client SelectOne(String condition) {

            Client result = null;

            if (connexion.State == ConnectionState.Open)
                connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
            connexion.Open();
            using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteSelectOne(cmd, condition);

            } connexion.Close();

            return result;

        }

        private List<Client> ExecuteSelect(SqlCommand cmd, String condition) {

            List<Client> result = new List<Client>();
            
            string cond = "";
            if (condition != null)
                cond = " " + condition;
            cmd.CommandText = "SELECT id, pseudo, password, solde FROM Client" + cond;
            using (SqlDataReader reader = cmd.ExecuteReader()) {

                while(reader.Read())
                    result.Add(this.Map(reader));

            } return result;

        }

        public List<Client> Select(String condition) {

            List<Client> result = new List<Client>();

            if (connexion.State == ConnectionState.Open)
                connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
            connexion.Open();
            using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteSelect(cmd, condition);

            } connexion.Close();

            return result;

        }

        private int ExecuteUpdate(SqlCommand cmd, String settings, String condition) {

            settings = "SET " + settings;
            cmd.CommandText = "UPDATE Client " + settings + " " + condition;
            return cmd.ExecuteNonQuery();

        }

        public int Update(String settings, String condition) {

            int result = -1;

            connexion.Open();
            using (SqlCommand cmd = connexion.CreateCommand()) {

                this.ExecuteUpdate(cmd, settings, condition);

            } connexion.Close();

            return result;

        }

    }

}