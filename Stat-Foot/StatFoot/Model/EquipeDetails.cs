using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    public class EquipeDetails {

        // ATTRIBUTES :

        private string id = null;
        private Equipe equipe = null;
        private Joueur joueur = null;
        private int numero = -1;

        // CONSTRUCTOR :

        public EquipeDetails(string id, Equipe equipe, Joueur joueur, int numero) {

            this.Id = id;
            this.Equipe = equipe;
            this.Joueur = joueur;
            this.Numero = numero;

        }

        // GETTERS & SETTERS | PROPERTIES :

        public string Id {

            get { return id; }
            set { id = value; }

        }

        public Equipe Equipe {

            get { return equipe; }
            set { equipe = value; }

        }

        public Joueur Joueur {

            get { return joueur; }
            set { joueur = value; }

        }

        public int Numero {

            get { return numero; }
            set {
                if (value > 0) {
                    numero = value;
                } else {
                    throw new Exception("Le numero d'un joueur doit etre positif !");
                }
            }

        }

        // METHODS :

        public bool Equals(EquipeDetails equipedetails) {

            return id == equipedetails.Id && equipe.Equals(equipedetails.Equipe) && joueur.Equals(equipedetails.Joueur) && numero == equipedetails.Numero;

        }

        public override string ToString() {

            return id;

        }

        public string ToInsert() {

            return "'" + id + "', '" + equipe + "', '" + joueur + "', " + numero;

        }

        public string ToUpdate() {

            return "equipe='" + equipe + "', joueur='" + joueur + "', numero=" + numero;

        }

    }
}
