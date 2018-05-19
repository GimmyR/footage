using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Footage.Models.Json;

namespace Footage.Controllers {

    public class ClientController : ApiController {

        public Res Post([FromBody]Client value) {

            Res response = new Res(true, null, null);

            try {

                this.CheckLogin(response, value);

            } catch(Exception ex) {

                response.message = ex.Message;

            } return response;

        }

        private void CheckLogin(Res response, Client model) {

            SqlConnection connection = Models.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");

            Models.ClientDAO cldao = new Models.ClientDAO(connection);
            Models.Client client = cldao.SelectOne("WHERE pseudo='" + model.pseudo + "' AND password='" + model.password + "'");
            if(client != null) {
                response.data = client.Id;
                response.error = false;
            }

        }

    }

}
