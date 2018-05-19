using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footage.Models {

    public class PariDetail {

        // ATTRIBUTES :

        private String id;
        private Pari pari;
        private Equipe equipe;
        private int compensation;
        private float montant;
        private float ecartMax;
        private float ecart;
        private float montantEcart;

        // CONSTRUCTS :

        public PariDetail() { }

        public PariDetail(String id, Pari pari, Equipe equipe, int compensation, float montant, float ecartMax, float ecart, float montantEcart) {

            this.Id = id;
            this.Pari = pari;
            this.Equipe = equipe;
            this.Compensation = compensation;
            this.Montant = montant;
            this.EcartMax = ecartMax;
            this.Ecart = ecart;
            this.MontantEcart = montantEcart;

        }

        public PariDetail(Json.PariDetail detail) {

            this.Id = detail.id;
            this.Equipe = new Equipe(); this.Equipe.Id = detail.equipe;
            this.Compensation = detail.compensation;
            this.Montant = detail.montant;
            this.EcartMax = detail.ecartMax;
            this.Ecart = detail.ecart;
            this.MontantEcart = detail.montantEcart;

        }

        // PROPERTIES :

        public String Id {

            get { return this.id; }
            set { this.id = value; }

        }

        public Pari Pari {

            get { return this.pari; }
            set { this.pari = value; }

        }

        public Equipe Equipe {

            get { return this.equipe; }
            set { this.equipe = value; }

        }

        public int Compensation {

            get { return this.compensation; }
            set {
                if (value >= 0)
                    this.compensation = value;
                else
                    throw new Exception("La compensation ne peut etre un nombre negatif !");
            }

        }

        public float Montant {

            get { return this.montant; }
            set {
                if (value >= 0)
                    this.montant = value;
                else
                    throw new Exception("Le plafond ne peut etre un nombre negatif !");
            }

        }

        public float EcartMax {

            get { return this.ecartMax; }
            set {
                if (value > 0)
                    this.ecartMax = value;
                else
                    throw new Exception("L'ecart maximal ne peut etre un nombre negatif ou nul !");
            }

        }

        public float Ecart {

            get { return this.ecart; }
            set {
                if (value > 0)
                    this.ecart = value;
                else
                    throw new Exception("L'ecart ne peut etre un nombre negatif ou nul !");
            }

        }

        public float MontantEcart {

            get { return this.montantEcart; }
            set {
                if (value > 0)
                    this.montantEcart = value;
                else
                    throw new Exception("Le montant par " + this.ecart + " d'ecart ne peut etre un nombre negatif ou nul !");
            }

        }

        // METHODS :

        public bool Equals(PariDetail detail) { return this.id == detail.Id; }

        public override string ToString() { return this.id; }

        public String ToInsert() {

            return "'" + this.id + "', '" + this.pari + "', '" + this.equipe + "', " + this.compensation + ", " + this.montant + ", " + this.ecartMax + ", " + this.ecart + ", " + this.montantEcart;

        }

        public String ToUpdate() {

            return "pari='" + this.pari + "', equipe='" + this.equipe + "', compensation=" + this.compensation + ", montant=" + this.montant + ", ecartMax=" + this.ecartMax + ", ecart=" + this.ecart + ", montantEcart=" + this.montantEcart;

        }

        // STATIC METHODS :



    }

}