using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Footage.Models {
    public class Equipe {

        // ATTRIBUTES :

        private string id = null;
        private string nom = null;

        // CONSTRUCTOR :

        public Equipe() { }

        public Equipe(String id) {
            this.id = id;
        }

        public Equipe(string id, string nom) {

            this.Id = id;
            this.Nom = nom;

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

        // METHODS :

        public bool Equals(Equipe equipe) {

            return id == equipe.Id && nom == equipe.Nom;

        }

        public override string ToString() {

            return id;

        }

        public string ToInsert() {

            return "'" + id + "', '" + nom + "'";

        }

        public string ToUpdate() {

            return "nom='" + nom + "'";

        }

    }
}
