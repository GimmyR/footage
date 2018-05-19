using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Footage.Models {
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

        public Json.Stat SelectOneStat(String partie, String action, String equipe1, String equipe2) {

            Json.Stat result = null;

            if (connexion.State == ConnectionState.Open)
                connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
            connexion.Open();
            using (SqlCommand cmd = connexion.CreateCommand()) {

                cmd.CommandText = "SELECT dbo.GetDetail('" + partie + "', '" + equipe1 + "', '" + action + "') as equipe1, dbo.GetDetail('" + partie + "', '" + equipe2 + "', '" + action + "') as equipe2;";
                result = this.ExecuteSelectOneStat(cmd);

            } connexion.Close();

            return result;

        }

        private Json.Stat ExecuteSelectOneStat(SqlCommand cmd) {

            Json.Stat result = null;

            using (SqlDataReader reader = cmd.ExecuteReader()) {

                if (reader.Read())
                    result = this.MapStat(reader);

            } return result;

        }

        private Json.Stat MapStat(SqlDataReader reader) {

            int equipe1 = int.Parse(reader["equipe1"].ToString());
            int equipe2 = int.Parse(reader["equipe2"].ToString());

            return new Json.Stat(equipe1, equipe2);

        }

    }
}
