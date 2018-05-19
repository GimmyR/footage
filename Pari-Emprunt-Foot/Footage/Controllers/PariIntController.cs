using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Footage.Models.Json;

namespace Footage.Controllers
{
    public class PariIntController : ApiController
    {

        public Res Post([FromBody]Pari value) {

            Res response = new Res(true, null, null);

            try {

                this.Interessants(response, value);

            } catch(Exception ex) {

                response.message = ex.Message;

            } return response;

        }

        private void Interessants(Res response, Pari value) {

            SqlConnection connection = Models.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");

            Models.PariDetailDAO paddao = new Models.PariDetailDAO(connection);
            Models.PariDetail detail = paddao.SelectOne("WHERE pari='" + value.id + "'");
            response.data = paddao.Select(", Pari p WHERE p.id=pd.pari AND p.partie='" + detail.Pari.Partie + "' AND p.client != '" + detail.Pari.Client + "' AND p.typePari=" + detail.Pari.TypePari + " AND p.action='" + detail.Pari.Action + "' AND p.equilibre=" + detail.Pari.Equilibre + " AND pd.equipe!='" + detail.Equipe + "' AND pd.montant > 0");
            response.error = false;

        }

    }
}
