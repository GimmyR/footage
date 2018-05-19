using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace Ctrl {
    public class CtrlFormation {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTOR :

        public CtrlFormation(SqlConnection connexion) {

            this.connexion = connexion;

        }

        // METHODS :

        public List<string[]> Read(string equipe) {

            List<string[]> results = new List<string[]>();

            try {

                EquipeDAO eqdao = new EquipeDAO(connexion);
                EquipeDetailsDAO eddao = new EquipeDetailsDAO(connexion);

                Equipe eq = eqdao.Select("WHERE nom='" + equipe + "'").First();
                List<EquipeDetails> details = eddao.Select("WHERE equipe='" + eq + "'");

                foreach (EquipeDetails ed in details) {

                    string[] tab = { ed.Id, eq.Nom, ed.Joueur.Nom, ed.Joueur.Prenom, ed.Numero.ToString() };

                    results.Add(tab);

                }

            } catch (Exception ex) {

                throw ex;
            
            } return results;

        }

    }
}
