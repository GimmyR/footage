using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Footage.Models {

    public class RembAuto {

        private SqlConnection connection;
        private RemboursementDAO rbdao;

        public RembAuto(SqlConnection connection) {

            this.connection = connection;

        }

        public void Debiter() {

            this.rbdao = new RemboursementDAO(connection);

            while (true) {

                List<Remboursement> rbs = rbdao.Select("WHERE dateRemboursement <= GETDATE() AND fait=0");
                this.Proceder(rbs);

            }

        }

        private void Proceder(List<Remboursement> rbs) {

            ClientDAO cldao = new ClientDAO(connection);

            foreach (Remboursement rb in rbs) {

                Client client = rb.Pret.Client;
                client.Solde -= (rb.Montant + rb.Interet);
                rb.Fait = 1;
                cldao.Update(client);
                rbdao.Update(rb);

            }

        }

    }

}