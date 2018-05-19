using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Model {
    public class EquipeDAO {

        // ATTRIBUTS :

        private SqlConnection connexion = null;

        // CONSTRUCTEUR :

        public EquipeDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // GETTERS ET SETTERS :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODES :

        public List<Equipe> Select(string cond) {

            List<Equipe> equipes = null;

            try {

                if (connexion.State == ConnectionState.Open)
                    connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    string condition = "";
                    if (cond != null)
                        condition = " " + cond;
                    cmd.CommandText = "SELECT id, nom FROM Equipe" + condition;
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        equipes = new List<Equipe>();
                        Equipe p;
                        while (reader.Read()) {

                            p = new Equipe(reader["id"].ToString(), reader["nom"].ToString());
                            equipes.Add(p);

                        }

                    }

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return equipes;

        }

        public string Insert(string values) {

            string response = null;

            try {

                int nbLigne = 0;
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    values = "VALUES(" + values + ")";
                    cmd.CommandText = "INSERT INTO Equipe " + values;
                    nbLigne = cmd.ExecuteNonQuery();

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return response;

        }

        public string Delete(string cond) {

            string response = null;

            try {

                int nbLigne = 0;
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    cmd.CommandText = "DELETE FROM Equipe " + cond;
                    nbLigne = cmd.ExecuteNonQuery();

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return response;

        }

        public string Update(string settings, string condition) {

            string response = null;

            try {

                int nbLigne = 0;
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    settings = "SET " + settings;
                    cmd.CommandText = "UPDATE Equipe " + settings + " " + condition;
                    nbLigne = cmd.ExecuteNonQuery();

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return response;

        }

        public static void ShowList(List<Equipe> equipes) {

            foreach (Equipe p in equipes) {
                Console.WriteLine(p.ToInsert());
            } Console.WriteLine();

        }

        public string NextId() {

            int next = SeqVal.Next(connexion, "seqEquipe");
            string id = "" + next;
            while (id.Length < 2) {
                id = "0" + id;
            } return "EQ" + id;

        }

    }
}
