using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Model {
    public class OtherDAO {

        // ATTRIBUTS :

        private SqlConnection connexion = null;

        // CONSTRUCTEUR :

        public OtherDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // GETTERS ET SETTERS :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODES :

        public float SelectPossession(string query) {

            float result = 0;

            try {

                if (connexion.State == ConnectionState.Open)
                    connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    cmd.CommandText = query;
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        if (reader.Read()) {

                            result = float.Parse(reader["pourcentage"].ToString());

                        }

                    }

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

    }
}
