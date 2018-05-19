using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Model {

    public class Connexion {

        public static SqlConnection Get(string strConn) {

            return new SqlConnection(strConn);

        }

    }

}
