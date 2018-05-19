using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Footage.Models {

    public class PretDAO {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTS :

        public PretDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // PROPERTIES :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODS :

        private int ExecuteInsert(SqlCommand cmd, Pret model) {

            cmd.CommandText = "INSERT INTO Pret VALUES(@val1, @val2, @val3, @val4, @val5)";
            cmd.Parameters.AddWithValue("@val1", model.Id);
            cmd.Parameters.AddWithValue("@val2", model.Client.ToString());
            cmd.Parameters.AddWithValue("@val3", model.Montant);
            cmd.Parameters.AddWithValue("@val4", model.DatePret);
            cmd.Parameters.AddWithValue("@val5", model.Rembourse);

            return cmd.ExecuteNonQuery();

        }

        public int Insert(Pret model) {

            int result = -1;

            connexion.Open(); using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteInsert(cmd, model);

            } connexion.Close();

            return result;

        }

        private Pret Map(SqlDataReader reader) {

            ClientDAO cldao = new ClientDAO(connexion);

            String id = reader["id"].ToString();
            Client client = cldao.SelectOne("WHERE id='" + reader["client"] + "'");
            float montant = float.Parse(reader["montant"].ToString());
            String datePret = Convert.ToDateTime(reader["datePret"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            int rembourse = int.Parse(reader["rembourse"].ToString());

            return new Pret(id, client, montant, datePret, rembourse);

        }

        private Pret ExecuteSelectOne(SqlCommand cmd, String condition) {

            Pret result = null;

            string cond = "";
            if (condition != null)
                cond = " " + condition;
            cmd.CommandText = "SELECT * FROM Pret" + cond;
            using (SqlDataReader reader = cmd.ExecuteReader()) {

                if (reader.Read())
                    result = this.Map(reader);

            } return result;

        }

        public Pret SelectOne(String condition) {

            Pret result = null;

            if (connexion.State == ConnectionState.Open)
                connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
            connexion.Open();
            using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteSelectOne(cmd, condition);

            } connexion.Close();

            return result;

        }

        private List<Pret> ExecuteSelect(SqlCommand cmd, String condition) {

            List<Pret> result = new List<Pret>();

            string cond = "";
            if (condition != null)
                cond = " " + condition;
            cmd.CommandText = "SELECT * FROM Pret" + cond;
            using (SqlDataReader reader = cmd.ExecuteReader()) {

                while (reader.Read())
                    result.Add(this.Map(reader));

            }
            return result;

        }

        public List<Pret> Select(String condition) {

            List<Pret> result = new List<Pret>();

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

            int next = SeqVal.Next(connexion, "seqPret");
            string id = "" + next;
            while (id.Length < 6) {
                id = "0" + id;
            }
            return "PR" + id;

        }

    }

}