using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Footage.Models.Json;

namespace Footage.Controllers {

    public class JonctionController : ApiController {

        private SqlConnection connection = Models.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");
        private Models.PariDetailDAO paddao;
        private Models.JonctionDAO jodao;

        public Res Post([FromBody]Pari value) {

            Res response = new Res(true, null, null);

            try {

                this.AnswerPost(response, value);

            } catch (Exception ex) {

                response.message = ex.Message;

            } return response;

        }

        private void AnswerPost(Res response, Pari value) {

            paddao = new Models.PariDetailDAO(connection);
            jodao = new Models.JonctionDAO(connection);

            Models.PariDetail detail = paddao.SelectOne("WHERE pari='" + value.id + "'");
            response.data = jodao.Select("WHERE pari='" + detail + "' OR contrePari='" + detail + "'");
            response.error = false;

        }

        public Res Put(int id, [FromBody]Jonction value) {

            Res response = new Res(true, null, null);

            try {

                this.AnswerPut(response, id, value);

            } catch(Exception ex) {

                response.message = ex.Message;

            } return response;

        }

        private void AnswerPut(Res response, int id, Jonction value) {

            paddao = new Models.PariDetailDAO(connection);
            jodao = new Models.JonctionDAO(connection);

            Models.PariDetail pari = paddao.SelectOne("WHERE pari='" + value.pari +"'");
            Models.PariDetail contre = paddao.SelectOne("WHERE pari='" + value.contrePari + "'");

            if (pari != null && contre != null) {

                this.ManagePut(response, pari, contre);

            } else throw new Exception("Pari introuvable !");

        }

        private void ManagePut(Res response, Models.PariDetail pari, Models.PariDetail contre) {

            float montant = -1;
            if (pari.Montant > contre.Montant) montant = contre.Montant; else montant = pari.Montant;
            Models.Jonction jonct = new Models.Jonction(jodao.NextId(), pari, contre, montant, 0);
            float pMont = pari.Montant - montant, cMont = contre.Montant - montant;
            if (pMont >= 0) pari.Montant = pMont; else pari.Montant = 0;
            if (cMont >= 0) contre.Montant = cMont; else contre.Montant = 0;

            if (pari.Pari.Equilibre == 0) {

                Models.Client cl1 = pari.Pari.Client; Models.Client cl2 = contre.Pari.Client;
                cl1.Solde += pari.Montant; pari.Montant = 0; cl2.Solde += contre.Montant; contre.Montant = 0;
                Models.ClientDAO cldao = new Models.ClientDAO(connection);
                cldao.Update(cl1); cldao.Update(cl2);

            } paddao.Update(pari); paddao.Update(contre); jodao.Insert(jonct.ToInsert());

            response.data = new Jonction() { id = jonct.Id, pari = pari.Id, contrePari = contre.Id, montant = jonct.Montant };
            response.error = false;

        }
        
    }

}
