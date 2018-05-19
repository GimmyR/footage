using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footage.Models {

    public class Client {

        // ATTRIBUTES :

        private String id;
        private String pseudo;
        private String password;
        private double solde;

        // CONSTRUCTS :

        public Client() { }

        public Client(String id, String pseudo, String password, double solde) {

            this.Id = id;
            this.Pseudo = pseudo;
            this.Password = password;
            this.Solde = solde;

        }

        public Client(Json.Client client) {

            this.Id = client.id;
            this.Pseudo = client.pseudo;
            this.Password = client.password;
            this.Solde = client.solde;

        }

        // PROPERTIES :

        public String Id { 
        
            get { return this.id; }
            set { this.id = value; }
        
        }

        public String Pseudo {

            get { return this.pseudo; }
            set { this.pseudo = value; }

        }

        public String Password {

            get { return this.password; }
            set { this.password = value; }

        }

        public double Solde {

            get { return this.solde; }
            set { this.solde = value; }

        }

        // METHODS :

        public bool Equals(Client client) {

            return this.id == client.Id && this.pseudo == client.Pseudo && this.password == client.Password && this.solde == client.Solde;

        }

        public override String ToString() { return this.id; }

        public String ToInsert() {

            return "'" + this.id + "', '" + this.pseudo + "', '" + this.password + "', " + this.solde;

        }

        public String ToUpdate() {

            return "pseudo='" + this.pseudo + "', password='" + this.password + "', solde=" + this.solde;

        }

        // STATIC METHODS :



    }

}