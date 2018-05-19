using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Footage.Models.Json;

namespace Footage.Controllers {

    public class ActionController : ApiController {

        public Res Get() {

            Res response = new Res(true, null, null);

            try {

                this.AnswerQuery(response);

            } catch (Exception ex) {

                response.message = ex.Message;

            } return response;

        }

        private void AnswerQuery(Res response) {

            SqlConnection connection = Models.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");

            Models.ActionDAO acdao = new Models.ActionDAO(connection);
            response.data = acdao.Select(null);
            response.error = false;

        }

    }

}
