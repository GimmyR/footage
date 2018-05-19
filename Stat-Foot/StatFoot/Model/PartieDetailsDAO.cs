using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Model {
    public class PartieDetailsDAO {

        // ATTRIBUTS :

        private SqlConnection connexion = null;

        // CONSTRUCTEUR :

        public PartieDetailsDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // GETTERS ET SETTERS :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODES :

        public List<PartieDetails> Select(string cond) {

            List<PartieDetails> partiedetailss = null;

            try {

                if (connexion.State == ConnectionState.Open)
                    connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    string condition = "";
                    if (cond != null)
                        condition = " " + cond;
                    cmd.CommandText = "SELECT partie, mitemps, temps, equipe, details, action, remarque FROM PartieDetails" + condition;
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        partiedetailss = new List<PartieDetails>();
                        PartieDetails p;

                        PartieDAO ptdao = new PartieDAO(connexion);
                        EquipeDAO eqdao = new EquipeDAO(connexion);
                        ActionDAO actdao = new ActionDAO(connexion);
                        EquipeDetailsDAO eddao = new EquipeDetailsDAO(connexion);
                        while (reader.Read()) {

                            Partie pt = ptdao.Select("WHERE id='" + reader["partie"].ToString() + "'").ElementAt(0);
                            Equipe eq = eqdao.Select("WHERE id='" + reader["equipe"].ToString() + "'").ElementAt(0);
                            EquipeDetails details = eddao.Select("WHERE id='" + reader["details"].ToString() + "'").ElementAt(0);
                            Action act = actdao.Select("WHERE id='" + reader["action"].ToString() + "'").ElementAt(0);

                            p = new PartieDetails(pt, int.Parse(reader["mitemps"].ToString()), Convert.ToDateTime(reader["temps"].ToString()), eq, details, act, reader["remarque"].ToString());
                            partiedetailss.Add(p);

                        }

                    }

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;
                //Console.Error.WriteLine(ex.Message + " in : " + ex.StackTrace);

            } return partiedetailss;

        }

        private DateTime GetTime(string query) {

            DateTime dt = Convert.ToDateTime("00:00:00");

            try {

                if (connexion.State == ConnectionState.Open)
                    connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    cmd.CommandText = query;
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        if (reader.Read()) {
						
							if(reader["duree"].ToString() != ""){
							
								DateTime d = Convert.ToDateTime(reader["duree"].ToString());
								dt = Convert.ToDateTime(d.ToString("HH:mm:ss"));
							
							}

                        }

                    }

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;
				//System.Windows.Forms.MessageBox.Show(ex.Message + ":\n" + ex.StackTrace);

            } return dt;

        }

        public float Possession(string query1, string query2) { // QUERY -> obtenir le temps de possession selon certains criteres - QUERY2 -> obtenir le nombre de mitemps

            float result = 0;

            try {

                if (query1 != null && query2 != null) {

                    String mainQuery = "SELECT CONVERT(DECIMAL(4, 3), CONVERT(DECIMAL, (" + query1 + ")) / CONVERT(DECIMAL, (" + query2 + "))) * 100 as pourcentage";
                    result = new OtherDAO(connexion).SelectPossession(mainQuery);

                } else {

                    throw new Exception("Une requete est nulle !");

                }

            } catch (Exception ex) {

                throw ex;
                //System.Windows.Forms.MessageBox.Show(ex.Message + ":\n" + ex.StackTrace);
                //System.Windows.Forms.MessageBox.Show(query3);

            } return result;

        }

        /*public float Possession(string mitemps, string query, string cond) { // QUERY -> obtenir le temps de possession selon certains criteres - QUERY2 -> obtenir le nombre de mitemps

            float result = 0; string query3 = "";

            try {

                if (mitemps != null && query != null && cond != null) {

                    DateTime possession = GetTime(query);
                    PartieDAO ptdao = new PartieDAO(connexion);
                    //int nbMitemps = new OtherDAO(connexion).SelectNbMitemps(query2);
                    List<Partie> parties = ptdao.Select(cond);

                    float dureePoss = Utils.TimeToSeconds(possession);
                    float dureePartie = 0;

                    foreach(Partie partie in parties){

                        query3 = "SELECT count(distinct(mitemps)) as nbMitemps FROM PartieDetails WHERE partie LIKE '%" + partie + "%' AND mitemps LIKE '%" + mitemps + "%'";
                        int nbMitemps = new OtherDAO(connexion).SelectNbMitemps(query3);
						
						if(nbMitemps == 0){
							throw new Exception("Ce mi-temps n'existe pas !");
						}

                        dureePartie += Utils.TimeToSeconds(partie.DureeMitemps) * nbMitemps;

                    } result = (dureePoss / dureePartie) * 100;

                } else {

                    throw new Exception("Une requete est nulle !");

                }

            } catch (Exception ex) {

                //throw ex;
                //System.Windows.Forms.MessageBox.Show(ex.Message + ":\n" + ex.StackTrace);
                System.Windows.Forms.MessageBox.Show(query3);

            } return result;

        }*/

        public string Insert(string values) {

            string response = null;

            try {

                int nbLigne = 0;
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    values = "VALUES(" + values + ")";
                    cmd.CommandText = "INSERT INTO PartieDetails " + values;
                    nbLigne = cmd.ExecuteNonQuery();

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return response;

        }
		
		public string InsertPossession(string values) {

            string response = null;

            try {

                int nbLigne = 0;
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    values = "VALUES(" + values + ")";
                    cmd.CommandText = "INSERT INTO Possession " + values;
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

                    cmd.CommandText = "DELETE FROM PartieDetails " + cond;
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
                    cmd.CommandText = "UPDATE PartieDetails " + settings + " " + condition;
                    nbLigne = cmd.ExecuteNonQuery();

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return response;

        }

        public static void ShowList(List<PartieDetails> partiedetailss) {

            foreach (PartieDetails p in partiedetailss) {
                Console.WriteLine(p.ToInsert());
            } Console.WriteLine();

        }

        /*public string NextId() {

            int next = SeqVal.Next(connexion, "seqPartieDetails");
            string id = "" + next;
            while (id.Length < 4) {
                id = "0" + id;
            } return "ED" + id;

        }*/

    }
}
