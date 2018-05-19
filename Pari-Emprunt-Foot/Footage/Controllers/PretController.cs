using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Footage.Models.Json;
using System.Data.SqlClient;

namespace Footage.Controllers {

    public class PretController : ApiController {

        public Res Post([FromBody]Client value) {

            Res response = new Res(true, null, null);

            try {

                this.MesPrets(response, value);

            } catch(Exception ex) {

                response.message = ex.Message;

            } return response;

        }

        private void MesPrets(Res response, Client model) {

            SqlConnection connection = Models.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");

            Models.PretDAO prdao = new Models.PretDAO(connection);
            response.data = prdao.Select("WHERE client='" + model.id + "'");
            response.error = false;

        }

        private void VerifierPlan(Plan value) {

            if (value.pret.client.id != null) {
                Models.Pret tmp1 = new Models.Pret(value.pret);
                foreach (Remboursement r in value.remboursements) {
                    Models.Remboursement rb = new Models.Remboursement(r);
                } value.Verifier();
            } else throw new Exception("ID du client non recu !");

        }

        private void SimplePlan(Plan value, SqlConnection connection) {

            this.VerifierPlan(value);
            value.AddInteret(connection);

        }

        private void DefinitivePlan(Plan value, SqlConnection connection) {

            this.VerifierPlan(value); value.AddInteret(connection);
            Models.PretDAO prdao = new Models.PretDAO(connection);
            Models.ClientDAO cldao = new Models.ClientDAO(connection);
            Models.RemboursementDAO rbdao = new Models.RemboursementDAO(connection);
            
            Models.Pret pret = new Models.Pret(value.pret);
            Models.Client client = cldao.SelectOne("WHERE id='" + value.pret.client.id + "'");
            client.Solde += pret.Montant;
            pret.Id = prdao.NextId();
            pret.Client = client;
            prdao.Insert(pret);
            cldao.Update(client);
            foreach(Remboursement r in value.remboursements) {

                Models.Remboursement rb = new Models.Remboursement(r); rb.Id = rbdao.NextId(); rb.Pret = pret;
                rbdao.Insert(rb);

            }         

        }

        // PUT: api/Pret/5
        public Res Put(int id, [FromBody]Plan value) {

            Res response = new Res(true, null, null);

            try {

                SqlConnection connection = Models.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");

                if (id == 0) {

                    this.SimplePlan(value, connection);
                    response.data = value;

                } else if (id == 1) {

                    this.DefinitivePlan(value, connection);

                } response.error = false;

            } catch (Exception ex) {

                response.message = ex.Message;

            } return response;

        }

    }

}
