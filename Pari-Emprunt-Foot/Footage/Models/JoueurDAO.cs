using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Footage.Models {
    public class JoueurDAO {

        // ATTRIBUTS :

        private SqlConnection connexion = null;

        // CONSTRUCTEUR :

        public JoueurDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // GETTERS ET SETTERS :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODES :

        public List<Joueur> Select(string cond) {

            List<Joueur> joueurs = null;

            try {

                if (connexion.State == ConnectionState.Open)
                    connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    string condition = "";
                    if (cond != null)
                        condition = " " + cond;
                    cmd.CommandText = "SELECT id, nom, prenom FROM Joueur" + condition;
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        joueurs = new List<Joueur>();
                        Joueur p;
                        while (reader.Read()) {

                            p = new Joueur(reader["id"].ToString(), reader["nom"].ToString(), reader["prenom"].ToString());
                            joueurs.Add(p);

                        }

                    }

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return joueurs;

        }

        public string Insert(string values) {

            string response = null;

            try {

                int nbLigne = 0;
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    values = "VALUES(" + values + ")";
                    cmd.CommandText = "INSERT INTO Joueur " + values;
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

                    cmd.CommandText = "DELETE FROM Joueur " + cond;
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
                    cmd.CommandText = "UPDATE Joueur " + settings + " " + condition;
                    nbLigne = cmd.ExecuteNonQuery();

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return response;

        }

        public static void ShowList(List<Joueur> joueurs) {

            foreach (Joueur p in joueurs) {
                Console.WriteLine(p.ToInsert());
            } Console.WriteLine();

        }

        public string NextId() {

            int next = SeqVal.Next(connexion, "seqJoueur");
            string id = "" + next;
            while (id.Length < 3) {
                id = "0" + id;
            } return "J" + id;

        }

    }
}
