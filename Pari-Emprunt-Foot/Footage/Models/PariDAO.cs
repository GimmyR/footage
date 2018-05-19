using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Footage.Models {

    public class PariDAO {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTS :

        public PariDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // PROPERTIES :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODS :

        private int ExecuteInsert(SqlCommand cmd, String values) {

            values = "VALUES(" + values + ")";
            cmd.CommandText = "INSERT INTO Pari " + values;
            return cmd.ExecuteNonQuery();

        }

        public int Insert(string values) {

            int result = -1;

            connexion.Open(); using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteInsert(cmd, values);

            } connexion.Close();

            return result;

        }

        private Pari Map(SqlDataReader reader) {

            String id = reader["id"].ToString();
            Client client = new ClientDAO(connexion).SelectOne("WHERE id='" + reader["client"] + "'");
            ProchainePartie partie = new ProchainePartieDAO(connexion).Select("WHERE id='" + reader["partie"] + "'").First();
            int typePari = int.Parse(reader["typePari"].ToString());
            Models.Action action = new ActionDAO(connexion).Select("WHERE id='" + reader["action"] + "'").First();
            int equilibre = int.Parse(reader["equilibre"].ToString());
            int regleEgalite = int.Parse(reader["regleEgalite"].ToString());

            return new Pari(id, client, partie, typePari, action, equilibre, regleEgalite);

        }

        private Pari ExecuteSelectOne(SqlCommand cmd, String condition) {

            Pari result = null;

            string cond = "";
            if (condition != null)
                cond = " " + condition;
            cmd.CommandText = "SELECT * FROM Pari" + cond;
            using (SqlDataReader reader = cmd.ExecuteReader()) {

                if (reader.Read())
                    result = this.Map(reader);

            } return result;

        }

        public Pari SelectOne(String condition) {

            Pari result = null;

            if (connexion.State == ConnectionState.Open)
                connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
            connexion.Open();
            using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteSelectOne(cmd, condition);

            } connexion.Close();

            return result;

        }

        private List<Pari> ExecuteSelect(SqlCommand cmd, String condition) {

            List<Pari> result = new List<Pari>();

            string cond = "";
            if (condition != null)
                cond = " " + condition;
            cmd.CommandText = "SELECT * FROM Pari" + cond;
            using (SqlDataReader reader = cmd.ExecuteReader()) {

                while (reader.Read())
                    result.Add(this.Map(reader));

            }
            return result;

        }

        public List<Pari> Select(String condition) {

            List<Pari> result = new List<Pari>();

            if (connexion.State == ConnectionState.Open)
                connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
            connexion.Open();
            using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteSelect(cmd, condition);

            }
            connexion.Close();

            return result;

        }

        public string NextId() {

            int next = SeqVal.Next(connexion, "seqPari");
            string id = "" + next;
            while (id.Length < 6) {
                id = "0" + id;
            } return "PA" + id;

        }

    }

}