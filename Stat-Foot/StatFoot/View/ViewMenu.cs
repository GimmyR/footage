using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace View {
    public partial class ViewMenu : Form {
        private SqlConnection connexion = null;
        public ViewMenu(SqlConnection connexion) {
            try {
                this.connexion = connexion;
                InitializeComponent();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void btnJoueurs_Click(object sender, EventArgs e) {
            try {
                ViewJoueurs vj = new ViewJoueurs(connexion, "Barcelone", null, null);
                vj.Show();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void btnEquipe_Click(object sender, EventArgs e) {
            try {
                ViewEquipes ve = new ViewEquipes(connexion);
                ve.Show();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void btnMatch_Click(object sender, EventArgs e) {
            try {
                ViewMatch vm = new ViewMatch(connexion);
                vm.Show();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void btnCommencer_Click(object sender, EventArgs e) {
            try {
                ViewConfig vc = new ViewConfig(connexion);
                vc.Show();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void btnProchainMatch_Click(object sender, EventArgs e) {
            try {
                ViewProchainsMatchs vpm = new ViewProchainsMatchs(connexion);
                vpm.Show();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
