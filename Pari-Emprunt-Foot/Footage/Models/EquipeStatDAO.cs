using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Footage.Models {
    public class EquipeStatDAO {

        // ATTRIBUTS :

        private SqlConnection connexion = null;

        // CONSTRUCTEUR :

        public EquipeStatDAO(SqlConnection connexion) {

            this.Connexion = connexion;

        }

        // GETTERS ET SETTERS :

        public SqlConnection Connexion {

            get { return connexion; }
            set { connexion = value; }

        }

        // METHODES :

        public EquipeStat Select(string query) {

            EquipeStat stats = null;

            try {

                if (connexion.State == ConnectionState.Open)
                    connexion = new SqlConnection(connexion.ConnectionString + "Password=itu");
                connexion.Open();
                using (SqlCommand cmd = connexion.CreateCommand()) {

                    cmd.CommandText = query;
                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        stats = new EquipeStat();
                        EquipeStat p;
                        ActionDAO acdao = new ActionDAO(connexion);
                        while (reader.Read()) {

                            Action action = acdao.Select("WHERE id='" + reader["action"].ToString() + "'").First();
                            int nb = int.Parse(reader["nombre"].ToString());

                            stats.Add(action.Nom, nb);

                        }

                    }

                } connexion.Close();

            } catch (Exception ex) {

                throw ex;

            } return Complete(stats);

        }

        private EquipeStat Complete(EquipeStat stat) {

            try {

                ActionDAO acdao = new ActionDAO(connexion);
                List<Action> actions = acdao.Select("WHERE id!='ACT01'");
                foreach (Action action in actions) {
                    if (!stat.Exist(action.Nom)) {
                        stat.Add(action.Nom, 0);
                    }
                }

            } catch (Exception ex) {
                throw ex;
            } return stat;

        }

    }
}
