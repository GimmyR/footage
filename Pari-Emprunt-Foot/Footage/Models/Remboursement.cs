using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footage.Models {

    public class Remboursement {

        // ATTRIBUTES :

        private String id;
        private Pret pret;
        private String dateRemboursement;
        private float montant;
        private float interet;
        private int fait;

        // CONSTRUCTS :

        public Remboursement() { }

        public Remboursement(String id, Pret pret, String dateRemboursement, float montant, float interet, int fait) {

            this.Id = id;
            this.Pret = pret;
            this.DateRemboursement = dateRemboursement;
            this.Montant = montant;
            this.Interet = interet;
            this.Fait = fait;

        }

        public Remboursement(Json.Remboursement remboursement) {

            this.Id = remboursement.id;
            this.DateRemboursement = remboursement.dateRemboursement;
            this.Montant = remboursement.montant;
            this.Interet = remboursement.interet;
            this.Fait = remboursement.fait;

        }

        // PROPERTIES :

        public String Id {
            get { return this.id; }
            set { this.id = value; }
        }

        public Pret Pret {
            get { return this.pret; }
            set { this.pret = value; }
        }

        public String DateRemboursement {
            get { return this.dateRemboursement; }
            set {
                try {
                    Convert.ToDateTime(value);
                    this.dateRemboursement = value;
                } catch (FormatException ex) {
                    throw new Exception("Le format de la date de remboursement est incorrect (il faut yyyy-MM-dd HH:mm:ss) !");
                }
            }
        }

        public float Montant {
            get { return this.montant; }
            set {
                if (value > 0)
                    this.montant = value;
                else throw new Exception("Le montant a rembourse est invalide !");
            }
        }

        public float Interet {
            get { return this.interet; }
            set {
                if (value >= 0)
                    this.interet = value;
                else throw new Exception("La valeur de l'interet est invalide !");
            }
        }

        public int Fait {
            get { return this.fait; }
            set {
                if (value == 0 || value == 1)
                    this.fait = value;
                else throw new Exception("Le remboursement peut soit etre rembourse (1) soit non (0) !");
            }
        }

        // METHODS :

        public bool Equals(Remboursement cmp) { return this.id == cmp.Id; }

        public override string ToString() { return this.id; }

        // STATIC METHODS :



    }

}