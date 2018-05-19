using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Footage.Models.Json;

namespace Footage.Controllers {

    public class MatchsController : ApiController {

        public Res Get() {

            Res response = new Res(true, null, null);

            try {

                this.Prochains(response);

            } catch(Exception ex) {

                response.message = ex.Message;

            } return response;

        }

        private void Prochains(Res response) {

            SqlConnection connection = Models.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");

            Models.ProchainePartieDAO ppdao = new Models.ProchainePartieDAO(connection);
            response.data = ppdao.Select("WHERE partie IS NULL");
            response.error = false;

        }

    }

}
