using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    public class PartieDetails {

        // ATTRIBUTES :

        private Partie partie = null;
        private int mitemps = -1;
        private DateTime temps = default(DateTime);
        private Equipe equipe = null;
        private EquipeDetails details = null;
        private Action action = null;
        private string remarque = null;

        // CONSTRUCTOR :

        public PartieDetails(Partie partie, int mitemps, DateTime temps, Equipe equipe, EquipeDetails details, Action action, string remarque) {

            this.Partie = partie;
            this.Mitemps = mitemps;
            this.Temps = temps;
            this.Equipe = equipe;
            this.Details = details;
            this.Action = action;
            this.Remarque = remarque;

        }

        // GETTERS & SETTERS | PROPERTIES :

        public Partie Partie {

            get { return partie; }
            set { partie = value; }

        }

        public int Mitemps {

            get { return mitemps; }
            set {
                if (value > 0) {
                    mitemps = value;
                } else {
                    throw new Exception("La valeur du mitemps doit etre positive !");
                }
            }

        }

        public DateTime Temps {

            get { return temps; }
            set { temps = value; }

        }

        public Equipe Equipe {

            get { return equipe; }
            set { equipe = value; }

        }

        public EquipeDetails Details {

            get { return details; }
            set { details = value; }

        }

        public Action Action {

            get { return action; }
            set { action = value; }

        }

        public string Remarque {

            get { return remarque; }
            set { remarque = value; }

        }

        // METHODS :

        public bool Equals(PartieDetails partieDetails) {

            return partie.Equals(partieDetails.Partie) && mitemps == partieDetails.Mitemps && temps.Equals(partieDetails.Temps) && equipe.Equals(partieDetails.Equipe) && details.Equals(partieDetails.Details) && action.Equals(partieDetails.Action) && remarque == partieDetails.Remarque;

        }

        public override string ToString() {

            return "";

        }

        public string ToInsert() {

            return "'" + partie + "', " + mitemps + ", '" + temps.ToString("HH:mm:ss") + "', '" + equipe + "', '" + details + "', '" + action + "', '" + remarque + "'";

        }

        public string ToUpdate() {

            return "partie='" + partie + "', mitemps=" + mitemps + ", temps='" + temps.ToString("HH:mm:ss") + "', equipe='" + equipe + "', details='" + details + "', action='" + action + "', remarque='" + remarque + "'";

        }

    }
}
