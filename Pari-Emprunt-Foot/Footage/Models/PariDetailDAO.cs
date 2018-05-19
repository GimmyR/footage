using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Footage.Models {

    public class PariDetailDAO {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTS :

        public PariDetailDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // PROPERTIES :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODS :

        private int ExecuteUpdate(SqlCommand cmd, PariDetail model) {

            cmd.CommandText = "UPDATE PariDetail SET montant=@val1 WHERE id=@val2";
            cmd.Parameters.AddWithValue("@val1", model.Montant);
            cmd.Parameters.AddWithValue("@val2", model.Id);

            return cmd.ExecuteNonQuery();

        }

        public int Update(PariDetail model) {

            int result = -1;

            connexion.Open(); using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteUpdate(cmd, model);

            } connexion.Close();

            return result;

        }

        private int ExecuteInsert(SqlCommand cmd, String values) {

            values = "VALUES(" + values + ")";
            cmd.CommandText = "INSERT INTO PariDetail " + values;
            return cmd.ExecuteNonQuery();

        }

        public int Insert(string values) {

            int result = -1;

            connexion.Open(); using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteInsert(cmd, values);

            } connexion.Close();

            return result;

        }

        private PariDetail Map(SqlDataReader reader) {

            String id = reader["id"].ToString();
            Pari pari = new PariDAO(connexion).SelectOne("WHERE id='" + reader["pari"] + "'");
            Equipe equipe = new EquipeDAO(connexion).Select("WHERE id='" + reader["equipe"] + "'").First();
            int compensation = int.Parse(reader["compensation"].ToString());
            float montant = float.Parse(reader["montant"].ToString());
            float ecartMax = float.Parse(reader["ecartMax"].ToString());
            float ecart = float.Parse(reader["ecart"].ToString());
            float montantEcart = float.Parse(reader["montantEcart"].ToString());

            return new PariDetail(id, pari, equipe, compensation, montant, ecartMax, ecart, montantEcart);

        }

        private PariDetail ExecuteSelectOne(SqlCommand cmd, String condition) {

            PariDetail result = null;

            string cond = "";
            if (condition != null)
                cond = " " + condition;
            cmd.CommandText = "SELECT * FROM PariDetail" + cond;
            using (SqlDataReader reader = cmd.ExecuteReader()) {

                if (reader.Read())
                    result = this.Map(reader);

            } return result;

        }

        public PariDetail SelectOne(String condition) {

            PariDetail result = null;

            if (connexion.State == ConnectionState.Open)
                connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
            connexion.Open();
            using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteSelectOne(cmd, condition);

            } connexion.Close();

            return result;

        }

        private List<PariDetail> ExecuteSelect(SqlCommand cmd, String condition) {

            List<PariDetail> result = new List<PariDetail>();

            string cond = "";
            if (condition != null)
                cond = " " + condition;
            cmd.CommandText = "SELECT pd.* FROM PariDetail pd" + cond;
            using (SqlDataReader reader = cmd.ExecuteReader()) {

                while (reader.Read())
                    result.Add(this.Map(reader));

            } return result;

        }

        public List<PariDetail> Select(String condition) {

            List<PariDetail> result = new List<PariDetail>();

            if (connexion.State == ConnectionState.Open)
                connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
            connexion.Open();
            using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteSelect(cmd, condition);

            } connexion.Close();

            return result;

        }

        public string NextId() {

            int next = SeqVal.Next(connexion, "seqPariDetail");
            string id = "" + next;
            while (id.Length < 6) {
                id = "0" + id;
            } return "PAD" + id;

        }

    }

}