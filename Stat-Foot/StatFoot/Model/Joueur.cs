using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    public class Joueur {

        // ATTRIBUTES :

        private string id = null;
        private string nom = null;
        private string prenom = null;

        // CONSTRUCTOR :

        public Joueur(string id, string nom, string prenom) {

            this.Id = id;
            this.Nom = nom;
            this.Prenom = prenom;

        }

        // GETTERS & SETTERS | PROPERTIES :

        public string Id {

            get { return id; }
            set { id = value; }

        }

        public string Nom {

            get { return nom; }
            set { nom = value; }

        }

        public string Prenom {

            get { return prenom; }
            set { prenom = value; }

        }

        // METHODS :

        public bool Equals(Joueur joueur) {

            return id == joueur.Id && nom == joueur.Nom && prenom == joueur.Prenom;

        }

        public override string ToString() {

            return id;

        }

        public string ToInsert() {

            return "'" + id + "', '" + nom + "', '" + prenom + "'";

        }

        public string ToUpdate() {

            return "nom='" + nom + "', prenom='" + prenom + "'";

        }

    }
}
