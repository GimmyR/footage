using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Footage.Models {

    public class JonctionDAO {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTS :

        public JonctionDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // PROPERTIES :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODS :

        private int ExecuteUpdate(SqlCommand cmd, Jonction model) {

            cmd.CommandText = "UPDATE Jonction SET regle=@val1 WHERE id=@val2";
            cmd.Parameters.AddWithValue("@val1", model.Regle);
            cmd.Parameters.AddWithValue("@val2", model.Id);

            return cmd.ExecuteNonQuery();

        }

        public int Update(Jonction model) {

            int result = -1;

            connexion.Open(); using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteUpdate(cmd, model);

            } connexion.Close();

            return result;

        }

        private int ExecuteInsert(SqlCommand cmd, String values) {

            values = "VALUES(" + values + ")";
            cmd.CommandText = "INSERT INTO Jonction " + values;
            return cmd.ExecuteNonQuery();

        }

        public int Insert(string values) {

            int result = -1;

            connexion.Open(); using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteInsert(cmd, values);

            } connexion.Close();

            return result;

        }

        private Jonction Map(SqlDataReader reader) {

            String id = reader["id"].ToString();
            PariDetail pari = new PariDetailDAO(connexion).SelectOne("WHERE id='" + reader["pari"] + "'");
            PariDetail contrePari = new PariDetailDAO(connexion).SelectOne("WHERE id='" + reader["contrePari"] + "'");
            float montant = float.Parse(reader["montant"].ToString());
            int regle = int.Parse(reader["regle"].ToString());

            return new Jonction(id, pari, contrePari, montant, regle);

        }

        private List<Jonction> ExecuteSelect(SqlCommand cmd, String condition) {

            List<Jonction> result = new List<Jonction>();

            string cond = "";
            if (condition != null)
                cond = " " + condition;
            cmd.CommandText = "SELECT * FROM Jonction" + cond;
            using (SqlDataReader reader = cmd.ExecuteReader()) {

                while (reader.Read())
                    result.Add(this.Map(reader));

            } return result;

        }

        public List<Jonction> Select(String condition) {

            List<Jonction> result = new List<Jonction>();

            if (connexion.State == ConnectionState.Open)
                connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
            connexion.Open();
            using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteSelect(cmd, condition);

            } connexion.Close();

            return result;

        }

        public string NextId() {

            int next = SeqVal.Next(connexion, "seqJonction");
            string id = "" + next;
            while (id.Length < 7) {
                id = "0" + id;
            } return "J" + id;

        }

    }

}