using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footage.Models.Json {
    public class Stat {

        public int equipe1;
        public int equipe2;

        public Stat(int equipe1, int equipe2) {

            this.equipe1 = equipe1;
            this.equipe2 = equipe2;

        }

    }
}