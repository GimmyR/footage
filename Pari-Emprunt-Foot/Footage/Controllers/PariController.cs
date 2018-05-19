using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Footage.Models.Json;

namespace Footage.Controllers {

    public class PariController : ApiController {

        public Res Post([FromBody]Client value) {

            Res response = new Res(true, null, null);

            try {

                this.MesParis(response, value);

            } catch (Exception ex) {

                response.message = ex.Message;

            } return response;

        }

        private void MesParis(Res response, Client value) {

            SqlConnection connection = Models.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");

            Models.PariDAO padao = new Models.PariDAO(connection);
            response.data = padao.Select("p, ProchainePartie pp WHERE p.partie=pp.id AND p.client='" + value.id + "'"); // AND ((pp.partie=pt.id  AND pt.fini=0) OR pp.partie IS NULL)
            response.error = false;

        }

        public Res Put(int id, [FromBody]StructPari value) {

            Res response = new Res(true, null, null);

            try {

                this.SavePari(response, id, value);

            } catch(Exception ex) {

                response.message = ex.Message;

            } return response;

        }

        private void SavePari(Res response, int id, StructPari value) {

            SqlConnection connection = Models.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");

            Models.PariDAO padao = new Models.PariDAO(connection);
            Models.PariDetailDAO paddao = new Models.PariDetailDAO(connection);
            Models.ClientDAO cldao = new Models.ClientDAO(connection);

            Models.Pari pari = new Models.Pari(value.pari); pari.Id = padao.NextId();
            Models.PariDetail detail = new Models.PariDetail(value.detail); detail.Id = paddao.NextId(); detail.Pari = pari;
            Models.Client client = cldao.SelectOne("WHERE id='" + pari.Client + "'");
            client.Solde -= detail.Montant;

            if (client != null && padao.Insert(pari.ToInsert()) > 0) {

                paddao.Insert(detail.ToInsert());
                cldao.Update(client);
                value.pari.id = pari.Id;
                value.detail.id = detail.Id;
                response.data = value;
                response.error = false;

            } else throw new Exception("Enregistrement du pari impossible !");

        }

    }

}
