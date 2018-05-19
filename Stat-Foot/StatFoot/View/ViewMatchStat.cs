using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ctrl;

namespace View {
    public partial class ViewMatchStat : Form {
        private System.Data.SqlClient.SqlConnection connexion = null;
        public ViewMatchStat(System.Data.SqlClient.SqlConnection connexion, string datePartie, string equipe, string adversaire) {
            try {
                this.connexion = connexion;
                InitializeComponent();
                SetEnable(datePartie, equipe, adversaire);
                FillDataGridView();
            } catch (Exception ex) {
                throw ex;
                //MessageBox.Show(ex.Message + ":\n" + ex.StackTrace);
            }
        }

        private void FillDataGridView() {

            try {

                CtrlMatchStat cms = new CtrlMatchStat(connexion);
                string sdate = "";
                if (!dtpDateS.Enabled)
                    sdate = dtpDateS.Value.ToString("yyyy-MM-dd HH:mm:ss");
                List<string[]> list = cms.Read(sdate, cbEquipe1S.Text, cbEquipe2S.Text, cbMitempsS.Text);
                foreach (string[] tab in list) {
                    dgvEquipeStat.Rows.Add(tab[0], tab[1], tab[2]);
                }

            } catch (Exception ex) {
                throw ex;
                //MessageBox.Show(ex.Message + ":\n" + ex.StackTrace);
                //MessageBox.Show(cbMitempsS.Text);
            }

        }

        private void SetEnable(string datePartie, string equipe, string adversaire) {

            try {

                if (datePartie != null) {
                    dtpDateS.Enabled = false;
                    dtpDateS.Value = Convert.ToDateTime(datePartie);
                }

                if (equipe != null) {
                    cbEquipe1S.Enabled = false;
                    cbEquipe1S.Text = equipe;
                }

                if (adversaire != null) {
                    cbEquipe2S.Enabled = false;
                    cbEquipe2S.Text = adversaire;
                }

            } catch (Exception ex) {
                throw ex;
            }

        }

        private void ViewMatchStat_Load(object sender, EventArgs e) {

        }

        private void cbEquipe1S_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbEquipe1S.Text = cbEquipe1S.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
        }

        private void cbEquipe2S_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbEquipe2S.Text = cbEquipe2S.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
        }

        private void cbMitempsS_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbMitempsS.Text = cbMitempsS.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
        }

        private void btnChercher_Click(object sender, EventArgs e) {
            try {
                dgvEquipeStat.Rows.Clear();
                FillDataGridView();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void btnFiche1_Click(object sender, EventArgs e) {
            try {
                ViewJoueurs vj = new ViewJoueurs(connexion, dtpDateS.Value.ToString("yyyy-MM-dd"), cbEquipe1S.Text, cbEquipe2S.Text);
                vj.Show();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void btnFiche2_Click(object sender, EventArgs e) {
            try {
                ViewJoueurs vj = new ViewJoueurs(connexion, dtpDateS.Value.ToString("yyyy-MM-dd"), cbEquipe2S.Text, cbEquipe1S.Text);
                vj.Show();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
