using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footage.Models {

    public class Taux {

        // ATTRIBUTES :

        private String id;
        private String nom;
        private float valeur;

        // CONSTRUCTS :

        public Taux() { }

        public Taux(String id, String nom, float valeur) {

            this.Id = id;
            this.Nom = nom;
            this.Valeur = valeur;

        }

        // PROPERTIES :

        public String Id {
            get { return this.id; }
            set { this.id = value; }
        }

        public String Nom {
            get { return this.nom; }
            set { this.nom = value; }
        }

        public float Valeur {
            get { return this.valeur; }
            set {
                if (value > 0)
                    this.valeur = value;
                else
                    throw new Exception("Un taux doit etre positif !");
            }
        }

        // METHODS :

        public bool Equals(Taux cmp) { return this.id == cmp.Id; }

        public override String ToString() { return this.id; }

        // STATIC METHODS :



    }

}