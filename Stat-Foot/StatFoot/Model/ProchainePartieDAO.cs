using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Model {
    public class ProchainePartieDAO {

        // ATTRIBUTS :

        private SqlConnection connexion = null;

        // CONSTRUCTEUR :

        public ProchainePartieDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // GETTERS ET SETTERS :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODES :

        public List<ProchainePartie> Select(string cond) {

            List<ProchainePartie> parties = null;

            try {

                if (connexion.State == ConnectionState.Open)
                    connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    string condition = "";
                    if (cond != null)
                        condition = " " + cond;
                    cmd.CommandText = "SELECT id, equipe1, equipe2, partie FROM ProchainePartie" + condition;
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        parties = new List<ProchainePartie>();
                        ProchainePartie p;

                        EquipeDAO eqdao = new EquipeDAO(connexion);
                        PartieDAO pdao = new PartieDAO(connexion);
                        while (reader.Read()) {

                            Partie partie = null;
                            if (reader["partie"].ToString() != "")
                                partie = pdao.Select("WHERE id='" + reader["partie"].ToString() + "'").First();

                            Equipe eq1 = eqdao.Select("WHERE id='" + reader["equipe1"].ToString() + "'").First();
                            Equipe eq2 = eqdao.Select("WHERE id='" + reader["equipe2"].ToString() + "'").First();

                            p = new ProchainePartie(reader["id"].ToString(), eq1, eq2, partie);
                            parties.Add(p);

                        }

                    }

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return parties;

        }

        public string Insert(string values) {

            string response = null;

            try {

                int nbLigne = 0;
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    values = "VALUES(" + values + ")";
                    cmd.CommandText = "INSERT INTO ProchainePartie " + values;
                    //Console.Write(cmd.CommandText);
                    nbLigne = cmd.ExecuteNonQuery();

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;
                //Console.Write(ex.Message + " :\n" + ex.StackTrace);

            } return response;

        }

        public string Delete(string cond) {

            string response = null;

            try {

                int nbLigne = 0;
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    cmd.CommandText = "DELETE FROM ProchainePartie " + cond;
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
                    cmd.CommandText = "UPDATE ProchainePartie " + settings + " " + condition;
                    nbLigne = cmd.ExecuteNonQuery();

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return response;

        }

        public static void ShowList(List<ProchainePartie> parties) {

            foreach (ProchainePartie p in parties) {
                Console.WriteLine(p.ToInsert());
            } Console.WriteLine();

        }

        public string NextId() {

            int next = SeqVal.Next(connexion, "seqProchainePartie");
            string id = "" + next;
            while (id.Length < 3) {
                id = "0" + id;
            } return "PP" + id;

        }

    }
}
