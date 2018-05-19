using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace Ctrl {
    public class CtrlEquipeStat {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTOR :

        public CtrlEquipeStat(SqlConnection connexion) {

            this.connexion = connexion;

        }

        // METHODS :

        private string[] GenerateQuery(string equipe, string adversaire, string datePartie, string mitemps, string nom, string prenom) {

            string[] query = new string[4];

            try {

                CtrlAction act = new CtrlAction(connexion);
                string eq = "", adv = "", dp = "", pt = "", mt = "", jr = "";

                if (equipe == "" && adversaire == "" && datePartie == "" && mitemps == "" && nom == "" && prenom == "") {

                    throw new Exception("Impossible de passer a ce genre de recherche !");

                } else if (equipe == "" && adversaire != "" && datePartie == "" && mitemps == "" && nom == "" && prenom == "") {

                    query = GenerateQuery(adversaire, equipe, datePartie, mitemps, nom, prenom);

                } else if (equipe == "" && adversaire != "" && datePartie != "" && mitemps == "" && nom == "" && prenom == "") {

                    query = GenerateQuery(adversaire, equipe, datePartie, mitemps, nom, prenom);

                } else if (equipe == "" && adversaire == "" && datePartie != "" && mitemps == "" && nom == "" && prenom == "") {

                    throw new Exception("Impossible de passer a ce genre de recherche !");

                } else if (equipe == "" && adversaire == "" && datePartie != "" && mitemps != "" && nom == "" && prenom == "") {

                    throw new Exception("Impossible de passer a ce genre de recherche !");

                } else if (equipe == "" && adversaire == "" && datePartie == "" && mitemps != "" && nom == "" && prenom == "") {

                    throw new Exception("Impossible de passer a ce genre de recherche !");

                } else {

                    JoueurDAO jdao = new JoueurDAO(connexion);
                    EquipeDAO eqdao = new EquipeDAO(connexion);
                    EquipeDetailsDAO eddao = new EquipeDetailsDAO(connexion);
                    PartieDAO ptdao = new PartieDAO(connexion);

                    List<Partie> parties = new List<Partie>();

                    if (equipe != "") {

                        Equipe eq1 = eqdao.Select("WHERE nom='" + equipe + "'").First();
                        eq = eq1.Id;

                    }

                    if (adversaire != "") {

                        //System.Windows.Forms.MessageBox.Show(adversaire);
						Equipe eq2 = eqdao.Select("WHERE nom='" + adversaire + "'").First();
                        adv = eq2.Id;

                    }

                    if (datePartie != "") {

                        dp = Convert.ToDateTime(datePartie).ToString("yyyy-MM-dd HH:mm:ss"); ;

                    } String cond = "WHERE ((equipe1 LIKE '%" + eq + "%' AND equipe2 LIKE '%" + adv + "%') OR (equipe1 LIKE '%" + adv + "%' AND equipe2 LIKE '%" + eq + "%')) AND datePartie = '" + dp + "'";
                    
                    parties.AddRange(ptdao.Select(cond));

                    if (nom != "" && prenom != "") {

                        Joueur j = jdao.Select("WHERE nom='" + nom + "' AND prenom='" + prenom + "'").First();
                        jr = j.Id;

                    } else if (nom != "" && prenom == "") {

                        Joueur j = jdao.Select("WHERE nom='" + nom + "'").First();
                        jr = j.Id;

                    } else if (nom == "" && prenom != "") {

                        Joueur j = jdao.Select("WHERE prenom='" + prenom + "'").First();
                        jr = j.Id;

                    }

                    if (jr != "") {

                        List<EquipeDetails> list = eddao.Select("WHERE joueur='" + jr +  "'");
                        if (list.Count == 1) {

                            jr = list.First().Id;

                        } else {

                            jr = "";

                        }

                    }

                    if (parties.Count == 1) {

                        pt = parties.First().Id;
                        query[0] = "SELECT action, SUM(nombre) as nombre FROM ViewStat WHERE partie LIKE '%" + pt + "%' AND mitemps LIKE '%" + mt + "%' AND equipe LIKE '%" + eq + "%' AND details LIKE '%" + jr + "%' AND action !='" + act.Possession + "' GROUP BY action";
                        query[1] = "SELECT COUNT(*) FROM Possession WHERE partie LIKE '%" + pt + "%' AND mitemps LIKE '%" + mitemps + "%' AND equipe LIKE '%" + eq + "%' AND details LIKE '%" + jr + "%'";
                        //query[2] = "SELECT count(distinct(mitemps)) as nbMitemps FROM PartieDetails WHERE partie LIKE '%" + pt + "%'";
                        query[2] = "SELECT COUNT(*) FROM Possession WHERE partie LIKE '%" + pt + "%' AND mitemps LIKE '%" + mitemps + "%'";

                    } else if (parties.Count > 1) {

                        query[0] = "SELECT action, SUM(nombre) as nombre FROM ViewStat WHERE mitemps LIKE '%" + mt + "%' AND equipe LIKE '%" + eq + "%' AND details LIKE '%" + jr + "%' AND action !='" + act.Possession + "' GROUP BY action";
                        query[1] = "SELECT COUNT(*) FROM Possession WHERE mitemps LIKE '%" + mitemps + "%' AND equipe LIKE '%" + eq + "%' AND details LIKE '%" + jr + "%'";
                        //query[2] = "SELECT count(distinct(mitemps)) as nbMitemps FROM PartieDetails WHERE partie LIKE '%" + pt + "%'";
                        query[2] = "SELECT COUNT(*) FROM Possession WHERE partie IN (SELECT id FROM Partie WHERE equipe1 LIKE '%" + eq + "%' OR equipe2 LIKE '%" + eq + "%') AND mitemps LIKE '%" + mitemps + "%'";

                    } else {

                        throw new Exception("Aucun match selon ces criteres n'a ete retrouve !");
                        //throw new Exception(cond);

                    }

                }

                /*if (equipe != "" && adversaire != "" && datePartie != "" && mitemps != "" && nom != "" && prenom != "") {

                    JoueurDAO jdao = new JoueurDAO(connexion);
                    Joueur j = jdao.Select("WHERE nom='" + nom + "' AND prenom='" + prenom + "'").First();

                    EquipeDAO eqdao = new EquipeDAO(connexion);
                    Equipe eq1 = eqdao.Select("WHERE nom='" + equipe + "'").First();
                    Equipe eq2 = eqdao.Select("WHERE nom='" + adversaire + "'").First();

                    EquipeDetailsDAO eddao = new EquipeDetailsDAO(connexion);
                    EquipeDetails details = eddao.Select("WHERE equipe='" + eq1 + "' AND joueur='" + j + "'").First();

                    DateTime dt = Convert.ToDateTime(datePartie);

                    PartieDAO ptdao = new PartieDAO(connexion);
                    Partie pt = ptdao.Select("WHERE datePartie='" + dt.ToString("yyyy-MM-dd") + "' AND (equipe1='" + eq1 + "' AND equipe2='" + eq2 + "' OR equipe1='" + eq2 + "' AND equipe2='" + eq1 + "')").First();

                    string condition = "WHERE action!='" + act.Possession + "' AND partie='" + pt + "' AND mitemps=" + mitemps + " AND equipe='" + eq1 + "' AND details='" + details + "'";
                    query[0] = "SELECT action, nombre FROM ViewStat " + condition;
                    query[1] = "SELECT DATEADD(ms, SUM(DATEDIFF(ms, 0, duree)), 0) as duree FROM Possession WHERE partie='" + pt + "' AND mitemps=" + mitemps + " AND equipe='" + eq1 + "' AND details='" + details + "';";
                    query[2] = "SELECT count(distinct(mitemps)) as nbMitemps FROM PartieDetails WHERE partie='" + pt + "'";
                    query[3] = "WHERE id='" + pt + "'";

                } else if (equipe != "" && adversaire != "" && datePartie != "" && mitemps == "" && nom != "" && prenom != "") {

                    JoueurDAO jdao = new JoueurDAO(connexion);
                    Joueur j = jdao.Select("WHERE nom='" + nom + "' AND prenom='" + prenom + "'").First();

                    EquipeDAO eqdao = new EquipeDAO(connexion);
                    Equipe eq1 = eqdao.Select("WHERE nom='" + equipe + "'").First();
                    Equipe eq2 = eqdao.Select("WHERE nom='" + adversaire + "'").First();

                    EquipeDetailsDAO eddao = new EquipeDetailsDAO(connexion);
                    EquipeDetails details = eddao.Select("WHERE equipe='" + eq1 + "' AND joueur='" + j + "'").First();

                    DateTime dt = Convert.ToDateTime(datePartie);

                    PartieDAO ptdao = new PartieDAO(connexion);
                    Partie pt = ptdao.Select("WHERE datePartie='" + dt.ToString("yyyy-MM-dd") + "' AND (equipe1='" + eq1 + "' AND equipe2='" + eq2 + "' OR equipe1='" + eq2 + "' AND equipe2='" + eq1 + "')").First();

                    string condition = "WHERE action!='" + act.Possession + "' AND partie='" + pt + "' AND equipe='" + eq1 + "' AND details='" + details + "'";
                    query[0] = "SELECT action, nombre FROM ViewStat " + condition;
                    query[1] = "SELECT DATEADD(ms, SUM(DATEDIFF(ms, 0, duree)), 0) as duree FROM Possession WHERE partie='" + pt + "' AND equipe='" + eq1 + "' AND details='" + details + "';";
                    query[2] = "SELECT count(distinct(mitemps)) as nbMitemps FROM PartieDetails WHERE partie='" + pt + "'";
                    query[3] = "WHERE id='" + pt + "'";

                } else if (equipe != "" && adversaire != "" && datePartie != "" && mitemps != "" && nom == "" && prenom == "") {

                    EquipeDAO eqdao = new EquipeDAO(connexion);
                    Equipe eq1 = eqdao.Select("WHERE nom='" + equipe + "'").First();
                    Equipe eq2 = eqdao.Select("WHERE nom='" + adversaire + "'").First();

                    DateTime dt = Convert.ToDateTime(datePartie);

                    PartieDAO ptdao = new PartieDAO(connexion);
                    Partie pt = ptdao.Select("WHERE datePartie='" + dt.ToString("yyyy-MM-dd") + "' AND (equipe1='" + eq1 + "' AND equipe2='" + eq2 + "' OR equipe1='" + eq2 + "' AND equipe2='" + eq1 + "')").First();

                    string condition = "WHERE action!='" + act.Possession + "' AND partie='" + pt + "' AND mitemps=" + mitemps + " AND equipe='" + eq1 + "'";
                    query[0] = "SELECT action, nombre FROM ViewStat " + condition;
                    query[1] = "SELECT DATEADD(ms, SUM(DATEDIFF(ms, 0, duree)), 0) as duree FROM Possession WHERE partie='" + pt + "' AND mitemps=" + mitemps + " AND equipe='" + eq1 + "';";
                    query[2] = "SELECT count(distinct(mitemps)) as nbMitemps FROM PartieDetails WHERE partie='" + pt + "'";
                    query[3] = "WHERE id='" + pt + "'";

                } else if (equipe != "" && adversaire != "" && datePartie != "" && mitemps == "" && nom == "" && prenom == "") {

                    EquipeDAO eqdao = new EquipeDAO(connexion);
                    Equipe eq1 = eqdao.Select("WHERE nom='" + equipe + "'").First();
                    Equipe eq2 = eqdao.Select("WHERE nom='" + adversaire + "'").First();

                    DateTime dt = Convert.ToDateTime(datePartie);

                    PartieDAO ptdao = new PartieDAO(connexion);
                    Partie pt = ptdao.Select("WHERE datePartie='" + dt.ToString("yyyy-MM-dd") + "' AND (equipe1='" + eq1 + "' AND equipe2='" + eq2 + "' OR equipe1='" + eq2 + "' AND equipe2='" + eq1 + "')").First();

                    string condition = "WHERE action!='" + act.Possession + "' AND partie='" + pt + "' AND equipe='" + eq1 + "'";
                    query[0] = "SELECT action, nombre FROM ViewStat " + condition;
                    query[1] = "SELECT DATEADD(ms, SUM(DATEDIFF(ms, 0, duree)), 0) as duree FROM Possession WHERE partie='" + pt + "' AND equipe='" + eq1 + "';";
                    query[2] = "SELECT count(distinct(mitemps)) as nbMitemps FROM PartieDetails WHERE partie='" + pt + "'";
                    query[3] = "WHERE id='" + pt + "'";

                } else if (equipe == "" && adversaire == "" && datePartie == "" && mitemps == "" && nom == "" && prenom == "") {

                    query[0] = "SELECT action, COUNT(nombre) as nombre FROM ViewStat WHERE action!='" + act.Possession + "' GROUP BY action";

                }*/

            } catch (Exception ex) {

                throw ex;
				//System.Windows.Forms.MessageBox.Show(ex.Message + ":\n" + ex.StackTrace);

            } return query;

        }

        public List<string[]> Read(string equipe, string adversaire, string datePartie, string mitemps, string nom, string prenom) {

            List<string[]> results = new List<string[]>();

            try {

                EquipeStatDAO eqsdao = new EquipeStatDAO(connexion);
                PartieDetailsDAO pddao = new PartieDetailsDAO(connexion);
                EquipeStat stats = null;
                string[] query = GenerateQuery(equipe, adversaire, datePartie, mitemps, nom, prenom);

                stats = eqsdao.Select(query[0]);
                float poss = pddao.Possession(query[1], query[2]);

                string[] str_poss = { "possession", poss + " %" };
                
                results.AddRange(stats.GetAll());
				results.Add(str_poss);

            } catch (Exception ex) {

                throw ex;
				//System.Windows.Forms.MessageBox.Show(ex.Message + ":\n" + ex.StackTrace);

            } return results;

        }

    }
}
