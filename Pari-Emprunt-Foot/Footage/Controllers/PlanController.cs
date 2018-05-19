using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Footage.Models.Json;

namespace Footage.Controllers {
    
    public class PlanController : ApiController {

        public Res Post([FromBody]Pret value) {

            Res response = new Res(true, null, null);

            try {

                this.MonPlan(response, value);

            } catch (Exception ex) {

                response.message = ex.Message;

            } return response;

        }

        private void MonPlan(Res response, Pret value) {

            SqlConnection connection = Models.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");

            Models.RemboursementDAO rbdao = new Models.RemboursementDAO(connection);
            response.data = rbdao.Select("WHERE pret='" + value.id + "'");
            response.error = false;

        }

        private void ModifPlan(ModifPlan value, SqlConnection connection) {

            Models.RemboursementDAO rbdao = new Models.RemboursementDAO(connection);
            rbdao.Delete("WHERE pret='" + value.pret.id + "'");
            Models.Pret pret = new Models.Pret(value.pret); pret.Client = new Models.Client(); pret.Client.Id = value.pret.id;
            foreach (Remboursement r in value.remboursements) {

                Models.Remboursement rb = new Models.Remboursement(r); rb.Pret = pret;
                if (rb.Id == null)
                    rb.Id = rbdao.NextId();
                rbdao.Insert(rb);

            }

        }

        // PUT: api/Plan/5
        public Res Put(int id, [FromBody]ModifPlan value) {

            Res response = new Res(true, null, null);

            try {

                this.CheckRequest(response, id, value);

            } catch (Exception ex) {

                response.message = ex.Message;

            } return response;

        }

        private void CheckRequest(Res response, int id, ModifPlan value) {

            SqlConnection connection = Models.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");

            if (id == 0) {
                value.Verifier();
                value.AddInteret(connection);
                value.AddRetard(connection);

                response.data = value; response.error = false;
            } else if (id == 1) {
                value.Verifier();
                value.AddInteret(connection);
                value.AddRetard(connection);

                this.ModifPlan(value, connection); response.error = false;
            }

        }

    }

}
