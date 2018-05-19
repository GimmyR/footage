using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footage.Models {

    public class Pret {

        // ATTRIBUTES :

        private String id;
        private Client client;
        private float montant;
        private String datePret;
        private int rembourse;

        // CONSTRUCTS :

        public Pret() { }

        public Pret(String id, Client client, float montant, String datePret, int rembourse) {

            this.Id = id;
            this.Client = client;
            this.Montant = montant;
            this.DatePret = datePret;
            this.Rembourse = rembourse;

        }

        public Pret(Json.Pret pret) {

            this.Id = pret.id;
            this.Montant = pret.montant;
            this.DatePret = pret.datePret;
            this.Rembourse = pret.rembourse;

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

        public float Montant {
            get { return this.montant; }
            set {
                if (value > 0)
                    this.montant = value;
                else
                    throw new Exception("Montant de pret doit etre positif !");
            }
        }

        public String DatePret {
            get { return this.datePret; }
            set {
                try {
                    Convert.ToDateTime(value);
                    this.datePret = value;
                } catch(FormatException ex) {
                    throw new Exception("Le format de la date de pret est incorrect (il faut yyyy-MM-dd HH:mm:ss) !");
                }
            }
        }

        public int Rembourse {
            get { return this.rembourse; }
            set {
                if (value == 0 || value == 1)
                    this.rembourse = value;
                else throw new Exception("Le pret peut soit etre rembourse (1) soit non (0) !");
            }
        }

        // METHODS :

        public bool Equals(Pret pret) { return this.id == pret.Id; }

        public override string ToString() { return this.id; }

        public String ToInsert() { return "'" + this.id + "', '" + this.client + "', " + this.montant + ", '" + this.datePret + "', " + this.rembourse; }

        public String ToUpdate() { return "client='" + this.client + "', montant=" + this.montant + ", datePret='" + this.datePret + "', rembourse=" + this.rembourse; }

        // STATIC METHODS :



    }

}