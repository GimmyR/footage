using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace Ctrl {
    public class CtrlCoursMatch {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTOR :

        public CtrlCoursMatch(SqlConnection connexion) {

            this.connexion = connexion;

        }

        // METHODS :

        public string Possession(string match, string mitemps, string temps, string equipe, string joueur) {

            string result = "";

            try {

                CtrlAction ca = new CtrlAction(connexion);

                result = Create(match, mitemps, temps, equipe, joueur, ca.Possession, "");

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

        public string Passe(string match, string mitemps, string temps) {

            string result = "";

            try {

                CtrlAction ca = new CtrlAction(connexion);
                PartieDetailsDAO pddao = new PartieDetailsDAO(connexion);
                PartieDetails detail = pddao.Select("WHERE partie='" + match + "' AND mitemps=" + mitemps + " AND action='" + ca.Possession + "' ORDER BY temps DESC").First();

                result = Create(match, mitemps, temps, detail.Equipe.Nom, detail.Details.Id, ca.Passe, "");

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

        public string Tir(string match, string mitemps, string temps) {

            string result = "";

            try {

                CtrlAction ca = new CtrlAction(connexion);
                PartieDetailsDAO pddao = new PartieDetailsDAO(connexion);
                PartieDetails detail = pddao.Select("WHERE partie='" + match + "' AND mitemps=" + mitemps + " AND action='" + ca.Possession + "' ORDER BY temps DESC").First();

                result = Create(match, mitemps, temps, detail.Equipe.Nom, detail.Details.Id, ca.Tir, "");

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

        public string TirCadre(string match, string mitemps, string temps) {

            string result = "";

            try {

                CtrlAction ca = new CtrlAction(connexion);
                PartieDetailsDAO pddao = new PartieDetailsDAO(connexion);
                PartieDetails detail = pddao.Select("WHERE partie='" + match + "' AND mitemps=" + mitemps + " AND action='" + ca.Tir + "' ORDER BY temps DESC").First();

                result = Create(match, mitemps, temps, detail.Equipe.Nom, detail.Details.Id, ca.TirCadre, "");

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

        public string But(string match, string mitemps, string temps) {

            string result = "";

            try {

                CtrlAction ca = new CtrlAction(connexion);
                PartieDetailsDAO pddao = new PartieDetailsDAO(connexion);
                PartieDetails detail = pddao.Select("WHERE partie='" + match + "' AND mitemps=" + mitemps + " AND action='" + ca.TirCadre + "' ORDER BY temps DESC").First();

                result = Create(match, mitemps, temps, detail.Equipe.Nom, detail.Details.Id, ca.But, "");

            } catch (Exception ex) {

                throw ex;

            } return result;

        }
		
		public string SetTempsPossession(string match, string mitemps, string equipe, string joueur, string duree) {

            string result = "";

			try {

                PartieDAO ptdao = new PartieDAO(connexion);
                EquipeDAO eqdao = new EquipeDAO(connexion);
                EquipeDetailsDAO eddao = new EquipeDetailsDAO(connexion);
                PartieDetailsDAO pddao = new PartieDetailsDAO(connexion);

                Partie pt = ptdao.Select("WHERE id='" + match + "'").First();
                Equipe eq = eqdao.Select("WHERE nom='" + equipe + "'").First();
                EquipeDetails detail = eddao.Select("WHERE id='" + joueur + "'").First();

                result = pddao.InsertPossession("'" + pt + "', " + mitemps + ", '" + eq + "', '" + detail + "', '" + duree + "'");

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

        private string Create(string match, string mitemps, string temps, string equipe, string joueur, string action, string remarque) {

            string result = "";

            try {

                PartieDAO ptdao = new PartieDAO(connexion);
                EquipeDAO eqdao = new EquipeDAO(connexion);
                EquipeDetailsDAO eddao = new EquipeDetailsDAO(connexion);
                ActionDAO acdao = new ActionDAO(connexion);
                PartieDetailsDAO pddao = new PartieDetailsDAO(connexion);

                Partie pt = ptdao.Select("WHERE id='" + match + "'").First();
                Equipe eq = eqdao.Select("WHERE nom='" + equipe + "'").First();
                EquipeDetails detail = eddao.Select("WHERE id='" + joueur + "'").First();
                Model.Action act = acdao.Select("WHERE id='" + action + "'").First();

                PartieDetails pd = new PartieDetails(pt, int.Parse(mitemps), Convert.ToDateTime(temps), eq, detail, act, remarque);

                result = pddao.Insert(pd.ToInsert());

            } catch (Exception ex) {

                throw ex;
                //System.Windows.Forms.MessageBox.Show(ex.StackTrace);

            } return result;

        }

    }
}
