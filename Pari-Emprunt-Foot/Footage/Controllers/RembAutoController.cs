using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Threading;
using Footage.Models.Json;

namespace Footage.Controllers {

    public class RembAutoController : ApiController {

        private static SqlConnection connection = Models.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");
        private static Thread debiter = new Thread(new Models.RembAuto(connection).Debiter);
        private static int running = 0;

        public Res Get() {

            return new Res(false, null, running);

        }

        public Res Get(int id) {

            Res response = new Res(true, null, null);

            try {

                this.AnswerRequest(response, id);

            } catch(Exception ex) {

                response.message = ex.Message;

            } return response;

        }

        private void AnswerRequest(Res response, int id) {

            if (id == 1) {

                debiter.Start();
                response.error = false;

            } else if (id == 0) {

                debiter.Abort();
                response.error = false;

            } else throw new Exception("Commande inconnue !");

            running = id;
            response.data = running;

        }

    }

}
