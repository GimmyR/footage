using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Footage.Models.Json {

    public class ModifPlan {

        public Pret pret;
        public List<Remboursement> remboursements;

        public ModifPlan() { }

        public void Verifier() {

            float montant1 = pret.montant;
            float montant2 = 0;

            for (int i = 0; i < remboursements.Count(); i++) {

                float tmp = montant2;
                Remboursement r = remboursements.ElementAt(i);
                montant2 += r.montant;
                if (montant2 > montant1) {
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
            foreach (Remboursement r in remboursements) {

                if (r.fait == 0) {
                    DateTime date2 = Convert.ToDateTime(r.dateRemboursement);
                    TimeSpan time = date2.Subtract(date1);
                    int nbJour = (int)time.TotalDays;
                    r.interet = (interet.Valeur * nbJour * reste) / 100;
                    date1 = date2;
                    reste -= r.montant;
                } else {
                    date1 = Convert.ToDateTime(r.dateRemboursement);
                    reste -= r.montant;
                }

            }

        }

        public void AddRetard(SqlConnection connection) {

            TauxDAO tdao = new TauxDAO(connection);
            RemboursementDAO rbdao = new RemboursementDAO(connection);
            Taux retard = tdao.SelectOne("WHERE nom='Retard'");

            float reste = pret.montant;
            DateTime date1 = default(DateTime);
            for (int i = 0; i < remboursements.Count(); i++) {

                Remboursement r = remboursements.ElementAt(i);
                if (r.fait == 0 || (r.fait == 1 && r.id == null)) {
                    Models.Remboursement rb = rbdao.SelectOne("WHERE id='" + r.id + "'");
                    if ((r.id != null && rb != null) || r.id == null) {
                        if(r.id != null)
                            date1 = Convert.ToDateTime(rb.DateRemboursement);
                        DateTime date2 = Convert.ToDateTime(r.dateRemboursement);
                        TimeSpan time = date2.Subtract(date1);
                        int nbJour = (int)time.TotalDays;
                        if (nbJour > 0)
                            r.interet += (retard.Valeur * nbJour * reste) / 100;
                        date1 = date2;
                        reste -= r.montant;
                    } else throw new Exception("ID du remboursement introuvable !");
                } else if (r.fait == 1 && r.id != null) {
                    Models.Remboursement rb = rbdao.SelectOne("WHERE pret='" + pret.id + "' AND id='" + r.id + "' AND fait=1");
                    if (rb != null) {
                        date1 = Convert.ToDateTime(rb.DateRemboursement);
                        reste -= rb.Montant;
                    } else throw new Exception("Le remboursement qui se dit etre deja fait est introuvable !");
                }

            }

        }

    }

}