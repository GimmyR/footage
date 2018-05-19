using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Footage.Models.Json;

namespace Footage.Controllers {

    public class CrediterController : ApiController {

        public Res Post([FromBody]Client value) {

            Res response = new Res(true, null, null);

            try {

                this.AnswerRequest(response, value);

            } catch (Exception ex) {

                response.message = ex.Message;

            } return response;

        }

        private void AnswerRequest(Res response, Client value) {

            if (value.solde > 0) {

                this.Crediter(response, value);

            } else throw new Exception("Veuillez saisir un montant positif !");

        }

        private void Crediter(Res response, Client value) {

            SqlConnection connection = Models.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");

            Models.ClientDAO cldao = new Models.ClientDAO(connection);
            Models.Client client = cldao.SelectOne("WHERE id='" + value.id + "' AND password='" + value.password + "'");
            if (client != null) {

                client.Solde += value.solde;
                cldao.Update(client);
                response.error = false;

            } else throw new Exception("Votre pseudo ou mots de passe est errone !");

        }

    }

}
