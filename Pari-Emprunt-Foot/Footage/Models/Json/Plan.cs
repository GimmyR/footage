using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Footage.Models.Json {

    public class Plan {

        public Pret pret;
        public List<Remboursement> remboursements;

        public Plan() { }

        public void Verifier() {

            float montant1 = pret.montant;
            float montant2 = 0;

            for(int i = 0; i < remboursements.Count(); i++) {

                float tmp = montant2;
                Remboursement r = remboursements.ElementAt(i);
                montant2 += r.montant;
                if(montant2 > montant1) {
                    r.montant -= (montant2 - montant1);
                    montant2 = tmp + r.montant;
                    if (r.montant == 0)
                        remboursements.Remove(r);
                }

            } if (montant1 < montant2) throw new Exception("La somme des montants de remboursements n'est pas egale a celle du montant de pret !");

        }

        public void AddInteret(SqlConnection connection) {

            TauxDAO tdao = new TauxDAO(connection);
            Taux interet = tdao.SelectOne("WHERE nom='Interet'");

            float reste = pret.montant;
            DateTime date1 = Convert.ToDateTime(pret.datePret);
            foreach(Remboursement r in remboursements) {

                DateTime date2 = Convert.ToDateTime(r.dateRemboursement);
                TimeSpan time = date2.Subtract(date1);
                int nbJour = (int)time.TotalDays;
                r.interet = (interet.Valeur * nbJour * reste) / 100;
                date1 = date2;
                reste -= r.montant;

            }

        }

    }

}