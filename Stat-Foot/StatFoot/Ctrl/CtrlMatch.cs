using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace Ctrl {
    public class CtrlMatch {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTOR :

        public CtrlMatch(SqlConnection connexion) {

            this.connexion = connexion;

        }

        // METHODS :

        private string GenerateQuery(string interval1, string interval2, string equipe1, string equipe2) {

            string result = null;

            try {

                if (interval1 != "" && interval2 != "" && equipe1 != "" && equipe2 != "") {

                    EquipeDAO eqdao = new EquipeDAO(connexion);

                    Equipe eq1 = eqdao.Select("WHERE nom='" + equipe1 + "'").First();
                    Equipe eq2 = eqdao.Select("WHERE nom='" + equipe2 + "'").First();

                    result = "WHERE datePartie >= '" + interval1 + "' AND datePartie <= '" + interval2 + "' AND equipe1='" + eq1 + "' AND equipe2='" + eq2 + "'";

                }

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

        public List<string[]> Read(string interval1, string interval2, string equipe1, string equipe2) {

            List<string[]> results = new List<string[]>();

            try {

                PartieDAO ptdao = new PartieDAO(connexion);
                List<Partie> parties = ptdao.Select(GenerateQuery(interval1, interval2, equipe1, equipe2));

                foreach (Partie p in parties) {

                    string[] tab = { p.Id, p.DatePartie.ToString("yyyy-MM-dd"), p.Equipe1.Nom, p.Equipe2.Nom };

                    results.Add(tab);

                }

            } catch (Exception ex) {

                throw ex;

            } return results;

        }

    }
}
