using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace Ctrl {
    public class CtrlProchainePartie {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTOR :

        public CtrlProchainePartie(SqlConnection connexion) {

            this.connexion = connexion;

        }

        // METHODS :

        public string Create(string equipe1, string equipe2) {

            string result = "";

            try {

                EquipeDAO eqdao = new EquipeDAO(connexion);
                Equipe eq1 = eqdao.Select("WHERE nom LIKE '%" + equipe1 + "%'").First();
                Equipe eq2 = eqdao.Select("WHERE nom LIKE '%" + equipe2 + "%'").First();
                
                ProchainePartieDAO padao = new ProchainePartieDAO(connexion);
                string id = padao.NextId();
                ProchainePartie cli = new ProchainePartie(id, eq1, eq2, null);
                result = padao.Insert(cli.ToInsert());

            } catch (Exception ex) {

                throw ex;
                //Console.Write(ex.Message + " :\n" + ex.StackTrace);

            } return result;

        }

        public List<string[]> Read(string equipe1, string equipe2) {

            List<string[]> result = new List<string[]>();

            try {

                EquipeDAO eqdao = new EquipeDAO(connexion);
                List<Equipe> eqs1 = eqdao.Select("WHERE nom LIKE '%" + equipe1 + "%'");
                List<Equipe> eqs2 = eqdao.Select("WHERE nom LIKE '%" + equipe2 + "%'");

                if (eqs1.Count == 1)
                    equipe1 = eqs1.First().Id;
                if (eqs2.Count == 1)
                    equipe2 = eqs2.First().Id;

                ProchainePartieDAO padao = new ProchainePartieDAO(connexion);
                List<ProchainePartie> parties = padao.Select("WHERE equipe1 LIKE '%" + equipe1 + "%' AND equipe2 LIKE '%" + equipe2 + "%' AND partie IS NULL");
                foreach (ProchainePartie cli in parties) {

                    string partie_affiliee = "Aucune";
                    if (cli.Partie != null)
                        partie_affiliee = cli.Partie.Id;

                    string[] tab = { cli.Id, cli.Equipe1.Nom, cli.Equipe2.Nom, partie_affiliee };
                    result.Add(tab);

                }

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

    }
}
