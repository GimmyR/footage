using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Footage.Models.Json;

namespace Footage.Controllers {

    public class DepartagerController : ApiController {

        public Res Post([FromBody]Partie value) {

            Res response = new Res(true, null, null);

            try {

                this.AnswerPost(response, value);

            } catch (Exception ex) {

                response.message = ex.Message;

            } return response;

        }

        private void AnswerPost(Res response, Partie value) {

            SqlConnection connection = Models.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");

            Models.Departage dp = new Models.Departage(connection);
            dp.DoIt(new Models.Partie(value));
            response.error = false;

        }

    }

}
