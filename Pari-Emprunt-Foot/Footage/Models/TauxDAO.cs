using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Footage.Models {

    public class TauxDAO {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTS :

        public TauxDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // PROPERTIES :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODS :

        private Taux Map(SqlDataReader reader) {

            String id = reader["id"].ToString();
            String nom = reader["nom"].ToString();
            float valeur = float.Parse(reader["valeur"].ToString());

            return new Taux(id, nom, valeur);

        }

        private Taux ExecuteSelectOne(SqlCommand cmd, String condition) {

            Taux result = null;

            string cond = "";
            if (condition != null)
                cond = " " + condition;
            cmd.CommandText = "SELECT * FROM Taux" + cond;
            using (SqlDataReader reader = cmd.ExecuteReader()) {

                if (reader.Read())
                    result = this.Map(reader);

            } return result;

        }

        public Taux SelectOne(String condition) {

            Taux result = null;

            if (connexion.State == ConnectionState.Open)
                connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
            connexion.Open();
            using (SqlCommand cmd = connexion.CreateCommand()) {

                result = this.ExecuteSelectOne(cmd, condition);

            } connexion.Close();

            return result;

        }

    }

}