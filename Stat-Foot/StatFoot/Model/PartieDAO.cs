using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Model {
    public class PartieDAO {

        // ATTRIBUTS :

        private SqlConnection connexion = null;

        // CONSTRUCTEUR :

        public PartieDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // GETTERS ET SETTERS :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODES :

        public List<Partie> Select(string cond) {

            List<Partie> parties = null;

            try {

                if (connexion.State == ConnectionState.Open)
                    connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    string condition = "";
                    if (cond != null)
                        condition = " " + cond;
                    cmd.CommandText = "SELECT id, datePartie, equipe1, equipe2, dureeMitemps, fini FROM Partie" + condition;
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        parties = new List<Partie>();
                        Partie p;

                        EquipeDAO eqdao = new EquipeDAO(connexion);
                        while (reader.Read()) {

                            Equipe eq1 = eqdao.Select("WHERE id='" + reader["equipe1"].ToString() + "'").ElementAt(0);
                            Equipe eq2 = eqdao.Select("WHERE id='" + reader["equipe2"].ToString() + "'").ElementAt(0);
                            int fini = int.Parse(reader["fini"].ToString());

                            p = new Partie(reader["id"].ToString(), Convert.ToDateTime(reader["datePartie"].ToString()), eq1, eq2, Convert.ToDateTime(reader["dureeMitemps"].ToString()), fini);
                            parties.Add(p);

                        }

                    }

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;
                //Console.Error.WriteLine(ex.Message + " in : " + ex.StackTrace);

            } return parties;

        }

        public string Insert(string values) {

            string response = null;

            try {

                int nbLigne = 0;
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    values = "VALUES(" + values + ")";
                    cmd.CommandText = "INSERT INTO Partie " + values;
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

                    cmd.CommandText = "DELETE FROM Partie " + cond;
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
                    cmd.CommandText = "UPDATE Partie " + settings + " " + condition;
                    nbLigne = cmd.ExecuteNonQuery();

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return response;

        }

        public static void ShowList(List<Partie> parties) {

            foreach (Partie p in parties) {
                Console.WriteLine(p.ToInsert());
            } Console.WriteLine();

        }

        public string NextId() {

            int next = SeqVal.Next(connexion, "seqPartie");
            string id = "" + next;
            while (id.Length < 3) {
                id = "0" + id;
            } return "PT" + id;

        }

    }
}
