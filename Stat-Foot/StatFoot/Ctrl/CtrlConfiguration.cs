using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace Ctrl {
    public class CtrlConfiguration {

        // ATTRIBUTES :

        private SqlConnection connexion = null;

        // CONSTRUCTOR :

        public CtrlConfiguration(SqlConnection connexion) {

            this.connexion = connexion;

        }

        // METHODS :

        public string Create(string equipe1, string equipe2, string dureeMitemps) {

            string result = "";

            try {

                EquipeDAO eqdao = new EquipeDAO(connexion);
                PartieDAO ptdao = new PartieDAO(connexion);

                Equipe eq1 = eqdao.Select("WHERE nom='" + equipe1 + "'").First();
                Equipe eq2 = eqdao.Select("WHERE nom='" + equipe2 + "'").First();

                DateTime time = Convert.ToDateTime(dureeMitemps);

                Partie partie = new Partie(ptdao.NextId(), DateTime.Now, eq1, eq2, time, 0);
                result = ptdao.Insert(partie.ToInsert());
				
				result = partie.Id;

            } catch (Exception ex) {

                throw ex;

            } return result;

        }

    }
}
