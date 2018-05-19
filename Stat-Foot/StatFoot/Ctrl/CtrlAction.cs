using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace Ctrl {
    public class CtrlAction {

        // ATTRIBUTES :

        private SqlConnection connexion = null;
        private ActionDAO acdao = null;

        // CONSTRUCTOR :

        public CtrlAction(SqlConnection connexion) {

            this.connexion = connexion;
            this.InitDAO();

        }

        // GETTERS :

        public string Possession {

            get { return acdao.Select("WHERE nom='possession'").ElementAt(0).ToString(); }

        }

        public string Passe {

            get { return acdao.Select("WHERE nom='passe'").ElementAt(0).ToString(); }

        }

        public string Tir {

            get { return acdao.Select("WHERE nom='tir'").ElementAt(0).ToString(); }

        }
		
		public string TirCadre {

            get { return acdao.Select("WHERE nom='tir cadre'").ElementAt(0).ToString(); }

        }
		
		public string But {

            get { return acdao.Select("WHERE nom='but'").ElementAt(0).ToString(); }

        }

        // METHODS :

        private void InitDAO() {

            acdao = new ActionDAO(connexion);

        }

    }
}
