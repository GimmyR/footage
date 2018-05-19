using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    public class ProchainePartie {

        // ATTRIBUTES :

        private string id = null;
        private Equipe equipe1 = null;
        private Equipe equipe2 = null;
        private Partie partie = null;

        // CONSTRUCTOR :

        public ProchainePartie(string id, Equipe equipe1, Equipe equipe2, Partie partie) {

            this.Id = id;
            this.Equipe1 = equipe1;
            this.Equipe2 = equipe2;
            this.Partie = partie;

        }

        // GETTERS & SETTERS | PROPERTIES :

        public string Id {

            get { return id; }
            set { id = value; }

        }

        public Equipe Equipe1 {

            get { return equipe1; }
            set { equipe1 = value; }

        }

        public Equipe Equipe2 {

            get { return equipe2; }
            set { equipe2 = value; }

        }

        public Partie Partie {

            get { return partie; }
            set { partie = value; }

        }

        // METHODS :

        public bool Equals(ProchainePartie partie) {

            bool tof = false;
            if (this.partie != null && partie.Partie != null)
                tof = this.partie.Equals(partie.Partie);
            
            return id == partie.Id && equipe1.Equals(partie.Equipe1) && equipe2.Equals(partie.Equipe2) && tof;

        }

        public override string ToString() {

            return id;

        }

        public string ToInsert() {

            return "'" + id + "', '" + equipe1 + "', '" + equipe2 + "', NULL";

        }

        public string ToUpdate() {

            string str_partie = "NULL";
            if (partie != null)
                str_partie = "'" + partie + "'";
            
            return "equipe1='" + equipe1 + "', equipe2='" + equipe2 + "', partie=" + str_partie;

        }

    }
}
