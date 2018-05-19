using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footage.Models {

    public class Pari {

        // ATTRIBUTES :

        private String id;
        private Client client;
        private ProchainePartie partie;
        private int typePari;
        private Action action;
        private int equilibre;
        private int regleEgalite;

        // CONSTRUCTS :

        public Pari() { }

        public Pari(String id, Client client, ProchainePartie partie, int typePari, Action action, int equilibre, int regleEgalite) {

            this.Id = id;
            this.Client = client;
            this.Partie = partie;
            this.TypePari = typePari;
            this.Action = action;
            this.Equilibre = equilibre;
            this.RegleEgalite = regleEgalite;

        }

        public Pari(Json.Pari pari) {

            this.Id = pari.id;
            this.Client = new Client(); this.Client.Id = pari.client;
            this.Partie = new ProchainePartie(); this.Partie.Id = pari.partie;
            this.TypePari = pari.typePari;
            this.Action = new Action(); this.Action.Id = pari.action;
            this.Equilibre = pari.equilibre;
            this.RegleEgalite = pari.regleEgalite;

        }

        // PROPERTIES :

        public String Id {

            get { return this.id; }
            set { this.id = value; }

        }

        public Client Client {

            get { return this.client; }
            set { this.client = value; }
        
        }

        public ProchainePartie Partie {

            get { return this.partie; }
            set { this.partie = value; }

        }

        public int TypePari {

            get { return this.typePari; }
            set {
                if (value == 0 || value == 1)
                    this.typePari = value;
                else
                    throw new Exception("Le pari doit etre de type total (0) ou quantitatif(1) !");
            }

        }

        public Action Action {

            get { return this.action; }
            set { this.action = value; }

        }

        public int Equilibre {

            get { return this.equilibre; }
            set {
                if (value == 0 || value == 1)
                    this.equilibre = value;
                else
                    throw new Exception("Le pari doit etre soit equilibre (0) ou desequilibre (1) !");
            }

        }

        public int RegleEgalite {

            get { return this.regleEgalite; }
            set {
                if (value == 0 || value == 1 || value == 2)
                    this.regleEgalite = value;
                else
                    throw new Exception("La regle a l'egalite peut etre rien (0) , le poseur de pari gagne (1) ou le contre-parieur gagne (2) !");
            }

        }

        // METHODS :

        public bool Equals(Pari pari) {

            return pari.Id == this.id;

        }

        public override string ToString() { return this.id; }

        public String ToInsert() {

            return "'" + this.id + "', '" + this.client + "', '" + this.partie + "', " + this.typePari + ", '" + this.action + "', " + this.equilibre + ", " + this.regleEgalite;

        }

        public String ToUpdate() {

            return "client='" + this.client + "', partie='" + this.partie + "', typePari=" + this.typePari + ", action='" + this.action + "', equilibre=" + this.equilibre + ", regleEgalite=" + this.regleEgalite;

        }

        // STATIC METHODS :



    }

}