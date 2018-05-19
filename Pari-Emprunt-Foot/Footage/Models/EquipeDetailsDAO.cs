using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Footage.Models {
    public class EquipeDetailsDAO {

        // ATTRIBUTS :

        private SqlConnection connexion = null;

        // CONSTRUCTEUR :

        public EquipeDetailsDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // GETTERS ET SETTERS :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODES :

        public List<EquipeDetails> Select(string cond) {

            List<EquipeDetails> equipedetailss = null;

            try {

                if (connexion.State == ConnectionState.Open)
                    connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    string condition = "";
                    if (cond != null)
                        condition = " " + cond;
                    cmd.CommandText = "SELECT id, equipe, joueur, numero FROM EquipeDetails" + condition;
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        equipedetailss = new List<EquipeDetails>();
                        EquipeDetails p;

                        EquipeDAO eqdao = new EquipeDAO(connexion);
                        JoueurDAO jdao = new JoueurDAO(connexion);
                        while (reader.Read()) {

                            Equipe eq = eqdao.Select("WHERE id='" + reader["equipe"].ToString() + "'").ElementAt(0);
                            Joueur jr = jdao.Select("WHERE id='" + reader["joueur"].ToString() + "'").ElementAt(0);

                            
                            p = new EquipeDetails(reader["id"].ToString(), eq, jr, int.Parse(reader["numero"].ToString()));
                            equipedetailss.Add(p);

                        }

                    }

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return equipedetailss;

        }

        public string Insert(string values) {

            string response = null;

            try {

                int nbLigne = 0;
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    values = "VALUES(" + values + ")";
                    cmd.CommandText = "INSERT INTO EquipeDetails " + values;
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

                    cmd.CommandText = "DELETE FROM EquipeDetails " + cond;
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
                    cmd.CommandText = "UPDATE EquipeDetails " + settings + " " + condition;
                    nbLigne = cmd.ExecuteNonQuery();

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return response;

        }

        public static void ShowList(List<EquipeDetails> equipedetailss) {

            foreach (EquipeDetails p in equipedetailss) {
                Console.WriteLine(p.ToInsert());
            } Console.WriteLine();

        }

        public string NextId() {

            int next = SeqVal.Next(connexion, "seqEquipeDetails");
            string id = "" + next;
            while (id.Length < 4) {
                id = "0" + id;
            } return "ED" + id;

        }

    }
}
