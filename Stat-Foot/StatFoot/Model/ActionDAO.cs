using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Model {
    public class ActionDAO {

        // ATTRIBUTS :

        private SqlConnection connexion = null;

        // CONSTRUCTEUR :

        public ActionDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // GETTERS ET SETTERS :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODES :

        public List<Action> Select(string cond) {

            List<Action> actions = null;

            try {

                if (connexion.State == ConnectionState.Open)
                    connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    string condition = "";
                    if (cond != null)
                        condition = " " + cond;
                    cmd.CommandText = "SELECT id, nom FROM Action" + condition;
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        actions = new List<Action>();
                        Action p;
                        while (reader.Read()) {

                            p = new Action(reader["id"].ToString(), reader["nom"].ToString());
                            actions.Add(p);

                        }

                    }

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return actions;

        }

        public string Insert(string values) {

            string response = null;

            try {

                int nbLigne = 0;
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    values = "VALUES(" + values + ")";
                    cmd.CommandText = "INSERT INTO Action " + values;
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

                    cmd.CommandText = "DELETE FROM Action " + cond;
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
                    cmd.CommandText = "UPDATE Action " + settings + " " + condition;
                    nbLigne = cmd.ExecuteNonQuery();

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return response;

        }

        public static void ShowList(List<Action> actions) {

            foreach (Action p in actions) {
                Console.WriteLine(p.ToInsert());
            } Console.WriteLine();

        }

        public string NextId() {

            int next = SeqVal.Next(connexion, "seqAction");
            string id = "" + next;
            while (id.Length < 2) {
                id = "0" + id;
            } return "ACT" + id;

        }

    }
}
