using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace Ctrl {
    public class CtrlJoueur {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTOR :

        public CtrlJoueur(SqlConnection connexion) {

            this.connexion = connexion;

        }

        // METHODS :

        public List<string[]> Read(string nom, string prenom, string numero, string equipe) {

            List<string[]> results = new List<string[]>();

            try {

                JoueurDAO jdao = new JoueurDAO(connexion);
                EquipeDAO eqdao = new EquipeDAO(connexion);
                EquipeDetailsDAO eddao = new EquipeDetailsDAO(connexion);

                List<EquipeDetails> joueurs = new List<EquipeDetails>();

                if (nom == "" && prenom == "" && numero == "" && equipe == "") {
                    joueurs = eddao.Select(null);
                } else if (nom == "" && prenom == "" && numero == "" && equipe != "") {
                    Equipe eq = eqdao.Select("WHERE nom='" + equipe + "'").ElementAt(0);
                    joueurs = eddao.Select("WHERE equipe='" + eq.Id + "'");
                }

                foreach (EquipeDetails ed in joueurs) {

                    string[] tab = { ed.Id, ed.Equipe.Nom, ed.Joueur.Nom, ed.Joueur.Prenom, ed.Numero + "" };

                    results.Add(tab);

                }

            } catch (Exception ex) {

                throw ex;

            } return results;

        }

        public string Create(string nom, string prenom, string numero, string equipe) {

            string result = null;

            try {

                JoueurDAO jdao = new JoueurDAO(connexion);
                Joueur joueur = null;
                List<Joueur> joueurs = jdao.Select("WHERE nom='" + nom + "' AND prenom='" + prenom + "'");
                int nb = joueurs.Count;
                if (nb == 1) {
                    joueur = joueurs.ElementAt(0);
                } else if (nb == 0) {
                    joueur = new Joueur(jdao.NextId(), nom, prenom);
                    jdao.Insert(joueur.ToInsert());
                } else {
                    throw new Exception("Nous trouvons un resultat different de 0 et 1 pour le joueur !");
                }

                EquipeDAO eqdao = new EquipeDAO(connexion);
                Equipe eq = null;
                List<Equipe> equipes = eqdao.Select("WHERE nom='" + equipe + "'");
                if (equipes.Count == 1) {
                    eq = equipes.ElementAt(0);
                } else if (equipes.Count == 0) {
                    throw new Exception("Cet equipe n'est pas present dans la base !");
                } else {
                    throw new Exception("Nous trouvons un resultat different de 0 et 1 pour l'equipe !");
                }

                if (joueur != null && eq != null) {
                    EquipeDetailsDAO eddao = new EquipeDetailsDAO(connexion);
                    string id = eddao.NextId();
                    int num = int.Parse(numero);
                    EquipeDetails ed = new EquipeDetails(id, eq, joueur, num);

                    result = eddao.Insert(ed.ToInsert());
                }

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

        public string CreateAll(List<string[]> joueurs) {

            string result = null;

            try {

                foreach (string[] joueur in joueurs) {

                    this.Create(joueur[0], joueur[1], joueur[2], joueur[3]);

                } result = "Ajout de " + joueurs.Count + " joueur(s) probablement fait !";

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

        public string Delete(List<string> ids) {

            string result = null;

            try {

                EquipeDetailsDAO eddao = new EquipeDetailsDAO(connexion);

                string condition = null;

                foreach (string id in ids) {

                    if (condition == null)
                        condition = "WHERE id='" + id + "'";
                    else
                        condition += " OR id='" + id + "'";

                } result = eddao.Delete(condition);

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

        public string Update(string id, string nom, string prenom, string numero, string equipe) {

            string result = null;

            try {

                JoueurDAO jdao = new JoueurDAO(connexion);
                EquipeDAO eqdao = new EquipeDAO(connexion);
                EquipeDetailsDAO eddao = new EquipeDetailsDAO(connexion);

                List<EquipeDetails> joueurs = eddao.Select("WHERE id='" + id + "'");
                EquipeDetails details = null;
                if (joueurs.Count == 1) {
                    details = joueurs.ElementAt(0);
                } else if (joueurs.Count == 0) {
                    throw new Exception("Ce joueur n'est pas present dans la base !");
                } else {
                    throw new Exception("Nous trouvons un resultat different de 0 et 1 pour le joueur !");
                }

                if (details != null) {

                    Joueur joueur = null;
                    joueur = jdao.Select("WHERE id='" + details.Joueur.Id + "'").ElementAt(0);

                    List<Equipe> equipes = eqdao.Select("WHERE id='" + equipe + "'");
                    Equipe eq = null;
                    if (equipes.Count == 1) {
                        eq = equipes.ElementAt(0);
                    } else if (equipes.Count == 0) {
                        throw new Exception("Cet equipe n'est pas present dans la base !");
                    } else {
                        throw new Exception("Nous trouvons un resultat different de 0 et 1 pour l'equipe !");
                    }

                    if (joueur != null && eq != null) {
                        joueur.Nom = nom;
                        joueur.Prenom = prenom;

                        details.Numero = int.Parse(numero);
                        details.Equipe = eq;

                        jdao.Update(joueur.ToUpdate(), "WHERE id='" + joueur.Id + "'");
                        eddao.Update(details.ToUpdate(), "WHERE id='" + details.Id + "'");
                    }

                } result = "Joueur probablement bien mis a jour !";

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

    }
}
