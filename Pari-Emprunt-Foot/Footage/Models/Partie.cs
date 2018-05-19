using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Footage.Models {
    public class Partie {

        // ATTRIBUTES :

        private string id = null;
        private DateTime datePartie = default(DateTime);
        private Equipe equipe1 = null;
        private Equipe equipe2 = null;
        private DateTime dureeMitemps = default(DateTime);
        private int fini;

        // CONSTRUCTOR :

        public Partie() { }

        public Partie(string id, DateTime datePartie, Equipe equipe1, Equipe equipe2, DateTime dureeMitemps, int fini) {

            this.Id = id;
            this.DatePartie = datePartie;
            this.Equipe1 = equipe1;
            this.Equipe2 = equipe2;
            this.DureeMitemps = dureeMitemps;
            this.Fini = fini;

        }

        public Partie(Json.Partie partie) {

            this.Id = partie.id;
            this.Fini = partie.fini;

        }

        // GETTERS & SETTERS | PROPERTIES :

        public string Id {

            get { return id; }
            set { id = value; }

        }

        public DateTime DatePartie {

            get { return datePartie; }
            set { datePartie = value; }

        }

        public Equipe Equipe1 {

            get { return equipe1; }
            set {
                if (equipe2 == null || (equipe2 != null && !value.Equals(equipe2))) {
                    equipe1 = value;
                } else {
                    throw new Exception("Il faut deux equipes differentes pour faire un match (1) !");
                }
            }

        }

        public Equipe Equipe2 {

            get { return equipe2; }
            set {
                if (equipe1 == null || (equipe1 != null && !value.Equals(equipe1))) {
                    equipe2 = value;
                } else {
                    throw new Exception("Il faut deux equipes differentes pour faire un match (2) !");
                }
            }

        }

        public DateTime DureeMitemps {

            get { return dureeMitemps; }
            set { dureeMitemps = value; }

        }

        public int Fini {

            get { return fini; }
            set {

                if (value == 0 || value == 1)
                    this.fini = value;
                else
                    throw new Exception("Un match peut etre soit fini (1) ou non (0) !");

            }

        }

        // METHODS :

        public bool Equals(Partie partie) {

            return id == partie.Id && datePartie.Equals(partie.DatePartie) && equipe1.Equals(partie.Equipe1) && equipe2.Equals(partie.Equipe2) && dureeMitemps.Equals(partie.DureeMitemps) && fini == partie.Fini;

        }

        public override string ToString() {

            return id;

        }

        public string ToInsert() {

            return "'" + id + "', '" + datePartie.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + equipe1 + "', '" + equipe2 + "', '" + dureeMitemps.ToString("HH:mm:ss") + "', " + fini;

        }

        public string ToUpdate() {

            return "datePartie='" + datePartie.ToString("yyyy-MM-dd HH:mm:ss") + "', equipe1='" + equipe1 + "', equipe2='" + equipe2 + "', dureeMitemps='" + dureeMitemps.ToString("HH:mm:ss") + "', fini=" + fini;

        }

    }
}
