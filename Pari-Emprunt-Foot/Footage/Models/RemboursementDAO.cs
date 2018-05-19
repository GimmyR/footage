using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Footage.Models {

    public class RemboursementDAO {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTS :

        public RemboursementDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // PROPERTIES :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODS :

        private int ExecuteUpdate(SqlCommand cmd, Remboursement model) {

            cmd.CommandText = "UPDATE Remboursement SET pret=@val1, dateRemboursement=@val2, montant=@val3, interet=@val4, fait=@val5 WHERE id=@val6";
            cmd.Parameters.AddWithValue("@val1", model.Pret.ToString());
            cmd.Parameters.AddWithValue("@val2", model.DateRemboursement);
            cmd.Parameters.AddWithValue("@val3", model.Montant);
            cmd.Parameters.AddWithValue("@val4", model.Interet);
            cmd.Parameters.AddWithValue("@val5", model.Fait);
            cmd.Parameters.AddWithValue("@val6", model.Id);

            return cmd.ExecuteNonQuery();

        }

        public int Update(Remboursement model) {

            int result = -1;

            connexion.Open(); using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteUpdate(cmd, model);

            } connexion.Close();

            return result;

        }

        private int ExecuteInsert(SqlCommand cmd, Remboursement model) {

            cmd.CommandText = "INSERT INTO Remboursement VALUES(@val1, @val2, @val3, @val4, @val5, @val6)";
            cmd.Parameters.AddWithValue("@val1", model.Id);
            cmd.Parameters.AddWithValue("@val2", model.Pret.ToString());
            cmd.Parameters.AddWithValue("@val3", model.DateRemboursement);
            cmd.Parameters.AddWithValue("@val4", model.Montant);
            cmd.Parameters.AddWithValue("@val5", model.Interet);
            cmd.Parameters.AddWithValue("@val6", model.Fait);

            return cmd.ExecuteNonQuery();

        }

        public int Insert(Remboursement model) {

            int result = -1;

            connexion.Open(); using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteInsert(cmd, model);

            } connexion.Close();

            return result;

        }

        public int Delete(String condition) {

            int result = -1;

            connexion.Open(); using (SqlCommand cmd = connexion.CreateCommand()) {

                cmd.CommandText = "DELETE FROM Remboursement " + condition;
                result = cmd.ExecuteNonQuery(); 

            } connexion.Close();

            return result;

        }

        private Remboursement Map(SqlDataReader reader) {

            PretDAO prdao = new PretDAO(connexion);

            String id = reader["id"].ToString();
            Pret pret = prdao.SelectOne("WHERE id='" + reader["pret"] + "'");
            String dateRemboursement = Convert.ToDateTime(reader["dateRemboursement"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            float montant = float.Parse(reader["montant"].ToString());
            float interet = float.Parse(reader["interet"].ToString());
            int fait = int.Parse(reader["fait"].ToString());

            return new Remboursement(id, pret, dateRemboursement, montant, interet, fait);

        }

        private Remboursement ExecuteSelectOne(SqlCommand cmd, String condition) {

            Remboursement result = null;

            string cond = "";
            if (condition != null)
                cond = " " + condition;
            cmd.CommandText = "SELECT * FROM Remboursement" + cond;
            using (SqlDataReader reader = cmd.ExecuteReader()) {

                if (reader.Read())
                    result = this.Map(reader);

            } return result;

        }

        public Remboursement SelectOne(String condition) {

            Remboursement result = null;

            if (connexion.State == ConnectionState.Open)
                connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
            connexion.Open();
            using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteSelectOne(cmd, condition);

            } connexion.Close();

            return result;

        }

        private List<Remboursement> ExecuteSelect(SqlCommand cmd, String condition) {

            List<Remboursement> result = new List<Remboursement>();

            string cond = "";
            if (condition != null)
                cond = " " + condition;
            cmd.CommandText = "SELECT * FROM Remboursement" + cond;
            using (SqlDataReader reader = cmd.ExecuteReader()) {

                while (reader.Read())
                    result.Add(this.Map(reader));

            } return result;

        }

        public List<Remboursement> Select(String condition) {

            List<Remboursement> result = new List<Remboursement>();

            if (connexion.State == ConnectionState.Open)
                connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
            connexion.Open();
            using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteSelect(cmd, condition);

            } connexion.Close();

            return result;

        }

        public string NextId() {

            int next = SeqVal.Next(connexion, "seqRemboursement");
            string id = "" + next;
            while (id.Length < 7) {
                id = "0" + id;
            } return "R" + id;

        }

    }

}