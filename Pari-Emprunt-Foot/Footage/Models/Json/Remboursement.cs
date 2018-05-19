using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footage.Models.Json {

    public class Remboursement {

        public String id;
        public Pret pret;
        public String dateRemboursement;
        public float montant;
        public float interet;
        public int fait;

    }

}