using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace Ctrl {
    public class CtrlEquipe {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTOR :

        public CtrlEquipe(SqlConnection connexion) {

            this.connexion = connexion;

        }

        // METHODS :

        public List<string[]> Read(string nom) {

            List<string[]> results = new List<string[]>();

            try {

                EquipeDAO eqdao = new EquipeDAO(connexion);

                string condition = null;

                if (nom != "")
                    condition = "WHERE nom='" + nom + "'";

                List<Equipe> equipes = eqdao.Select(condition);

                foreach (Equipe e in equipes) {

                    string[] tab = { e.Id, e.Nom };

                    results.Add(tab);

                }

            } catch (Exception ex) {

                throw ex;

            } return results;

        }

        private string CreateEquipe(string nom) {

            string result = null;

            try {

                EquipeDAO eqdao = new EquipeDAO(connexion);

                string id = eqdao.NextId();

                Equipe equipe = new Equipe(id, nom);

                result = eqdao.Insert(equipe.ToInsert());

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

        public string Create(string nom, List<string[]> joueurs) {

            string result = null;

            try {

                result = CreateEquipe(nom);

                CtrlJoueur cj = new CtrlJoueur(connexion);
                if(result == null)
                    result = cj.CreateAll(joueurs);
                else
                    result += "\n" + cj.CreateAll(joueurs);

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

        public string Delete(List<string> ids) {

            string result = null;

            try {

                EquipeDAO eqdao = new EquipeDAO(connexion);

                string condition = null;

                foreach (string id in ids) {

                    if (condition == null)
                        condition = "WHERE id='" + id + "'";
                    else
                        condition += " OR id='" + id + "'";

                } result = eqdao.Delete(condition);

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

        public string Update(string id, string nom) {

            string result = null;

            try {

                EquipeDAO eqdao = new EquipeDAO(connexion);

                Equipe equipe = new Equipe(id, nom);

                result = eqdao.Update(equipe.ToUpdate(), "WHERE id='" + id + "'");

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

    }
}
