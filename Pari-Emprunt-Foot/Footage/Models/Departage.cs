using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Footage.Models {

    public class Departage {

        private SqlConnection connection;
        private ProchainePartieDAO ppdao;
        private PariDAO padao;
        private PariDetailDAO paddao;
        private JonctionDAO jodao;

        public Departage(SqlConnection connection) {

            this.connection = connection;
            this.ppdao = new ProchainePartieDAO(connection);
            this.padao = new PariDAO(connection);
            this.paddao = new PariDetailDAO(connection);
            this.jodao = new JonctionDAO(connection);

        }

        public void DoIt(Partie partie) {

            List<ProchainePartie> pps = ppdao.Select("WHERE partie='" + partie + "'");
            if (pps.Count() > 0) {

                ProchainePartie pp = pps.First();
                Pari pari = padao.SelectOne("WHERE partie='" + pp + "'");
                List<PariDetail> details = paddao.Select("WHERE pari='" + pari + "'");
                this.JustDoIt(details);

            } else throw new Exception("Partie introuvable !");

        }

        private void JustDoIt(List<PariDetail> details) {

            foreach(PariDetail pd in details) {

                List<Jonction> joncts = jodao.Select("WHERE pari='" + pd + "' OR contrePari='" + pd + "' AND regle=0");
                foreach(Jonction j in joncts) {

                    this.Regler(j);
                    j.Regle = 1;
                    jodao.Update(j);

                }

            }

        }

        private void Regler(Jonction jonction) {

            PariDetail pd1 = jonction.Pari, pd2 = jonction.ContrePari;
            Pari pari = pd1.Pari;
            Partie partie = pari.Partie.Partie;
            Action action = pari.Action;

            Json.Stat stat = new OtherDAO(connection).SelectOneStat(partie.Id, action.Id, pd1.Equipe.Id, pd2.Equipe.Id);
            if (pari.TypePari == 0)
                this.ReglerTotal(jonction, pari, stat, pd1, pd2);
            else
                this.ReglerQte(jonction, pari, stat, pd1, pd2);

        }

        private void Egalite(Jonction jonct, Pari pari, PariDetail pd1, PariDetail pd2) {

            Client cl1 = pd1.Pari.Client, cl2 = pd2.Pari.Client;
            ClientDAO cldao = new ClientDAO(connection);
            if(pari.RegleEgalite == 0) {
                
                cl1.Solde += jonct.Montant; cl2.Solde += jonct.Montant;
                cldao.Update(cl1); cldao.Update(cl2);

            } else if(pari.RegleEgalite == 1) {

                cl1.Solde += (jonct.Montant * 2);
                cldao.Update(cl1);

            } else {

                cl2.Solde += (jonct.Montant * 2);
                cldao.Update(cl2);

            }

        }

        private void ReglerTotal(Jonction jonct, Pari pari, Json.Stat stat, PariDetail pd1, PariDetail pd2) {

            if (stat.equipe1 > (stat.equipe2 + pd1.Compensation)) {

                Client client = pd1.Pari.Client;
                client.Solde += (jonct.Montant * 2);
                new ClientDAO(connection).Update(client);

            } else if (stat.equipe1 < (stat.equipe2 + pd1.Compensation)) {

                Client client = pd2.Pari.Client;
                client.Solde += (jonct.Montant * 2);
                new ClientDAO(connection).Update(client);

            } else
                this.Egalite(jonct, pari, pd1, pd2);

        }

        private void ReglerQte(Jonction jonct, Pari pari, Json.Stat stat, PariDetail pd1, PariDetail pd2) {

            if (stat.equipe1 > (stat.equipe2 + pd1.Compensation)) {

                int ecart = stat.equipe1 - (stat.equipe2 + pd1.Compensation);
                if(ecart > pd1.Ecart) {

                    int ecart2 = ecart / (int)pd1.Ecart;
                    float montant = ecart2 * pd1.MontantEcart;
                    if (montant > jonct.Montant)
                        montant = jonct.Montant;
                    Client cl1 = pd1.Pari.Client, cl2 = pd2.Pari.Client;
                    cl1.Solde += (jonct.Montant + montant);
                    cl2.Solde += (jonct.Montant - montant);
                    new ClientDAO(connection).Update(cl1);
                    new ClientDAO(connection).Update(cl2);

                } else {

                    Client client = pd1.Pari.Client;
                    client.Solde += jonct.Montant;
                    new ClientDAO(connection).Update(client);

                }

            } else if (stat.equipe1 < (stat.equipe2 + pd1.Compensation)) {

                int ecart = (stat.equipe2 + pd1.Compensation) - stat.equipe1;
                if (ecart > pd2.Ecart) {

                    int ecart2 = ecart / (int)pd2.Ecart;
                    float montant = ecart2 * pd2.MontantEcart;
                    if (montant > jonct.Montant)
                        montant = jonct.Montant;
                    Client cl1 = pd1.Pari.Client, cl2 = pd2.Pari.Client;
                    cl1.Solde += (jonct.Montant - montant);
                    cl2.Solde += (jonct.Montant + montant);
                    new ClientDAO(connection).Update(cl1);
                    new ClientDAO(connection).Update(cl2);

                } else {

                    Client client = pd2.Pari.Client;
                    client.Solde += jonct.Montant;
                    new ClientDAO(connection).Update(client);

                }

            } else
                this.Egalite(jonct, pari, pd1, pd2);

        }

    }

}