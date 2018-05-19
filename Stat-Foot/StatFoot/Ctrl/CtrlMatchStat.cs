using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace Ctrl {
    public class CtrlMatchStat {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTOR :

        public CtrlMatchStat(SqlConnection connexion) {

            this.connexion = connexion;

        }

        // METHODS :

        public List<string[]> Read(string datePartie, string equipe1, string equipe2, string mitemps) {

            List<string[]> results = new List<string[]>();

            try {

                CtrlEquipeStat ces = new CtrlEquipeStat(connexion);

                List<string[]> eq1 = ces.Read(equipe1, equipe2, datePartie, mitemps, "", "");
                List<string[]> eq2 = ces.Read(equipe2, equipe1, datePartie, mitemps, "", "");

                foreach (string[] str in eq1) {

                    string[] tab = null;

                    foreach (string[] str2 in eq2) {

                        if (str[0] == str2[0]) {

                            string[] tab2 = { str[1], str[0], str2[1] };
                            tab = tab2;

                        }

                    } results.Add(tab);

                }

            } catch (Exception ex) {

                throw ex;
				//System.Windows.Forms.MessageBox.Show(ex.Message + ":\n" + ex.StackTrace);

            } return results;

        }

    }
}
