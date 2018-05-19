using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footage.Models {

    public class Jonction {

        // ATTRIBUTES :

        private String id;
        private PariDetail pari;
        private PariDetail contrePari;
        private float montant;
        private int regle;

        // CONSTRUCTS :

        public Jonction() { }

        public Jonction(String id, PariDetail pari, PariDetail contrePari, float montant, int regle) {

            this.Id = id;
            this.Pari = pari;
            this.ContrePari = contrePari;
            this.Montant = montant;
            this.Regle = regle;

        }

        // PROPERTIES :

        public String Id {

            get { return this.id; }
            set { this.id = value; }

        }

        public PariDetail Pari {

            get { return this.pari; }
            set { this.pari = value; }

        }

        public PariDetail ContrePari {

            get { return this.contrePari; }
            set { this.contrePari = value; }

        }

        public float Montant {

            get { return this.montant; }
            set {
                if (value > 0)
                    this.montant = value;
                else
                    throw new Exception("Le montant de la jonction entre deux paris doit etre positif !");
            }

        }

        public int Regle {
            get { return this.regle; }
            set {
                if (value == 0 || value == 1)
                    this.regle = value;
                else throw new Exception("La jonction de paris peut soit etre regle (1) soit non (0) !");
            }
        }

        // METHODS :

        public bool Equals(Jonction jonction) { return this.id == jonction.Id; }

        public override string ToString() { return this.id; }

        public String ToInsert() {

            return "'" + this.id + "', '" + this.pari + "', '" + this.contrePari + "', " + this.montant + ", " + this.regle;

        }

        public String ToUpdate() {

            return "pari='" + this.pari + "', contrePari='" + this.contrePari + "', montant=" + this.montant + ", regle=" + this.regle;

        }

        // STATIC METHODS :



    }

}