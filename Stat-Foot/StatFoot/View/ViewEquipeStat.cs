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
    public partial class ViewEquipeStat : Form {
        private System.Data.SqlClient.SqlConnection connexion = null;
        public ViewEquipeStat(System.Data.SqlClient.SqlConnection connexion, string datePartie, string equipe, string adversaire, string nom, string prenom) {
            try {
                this.connexion = connexion;
                InitializeComponent();
                SetEnable(datePartie, equipe, adversaire, nom, prenom);
                FillDataGridView();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void FillDataGridView() {

            try {

                CtrlEquipeStat ces = new CtrlEquipeStat(connexion);
                string sdate = "";
                if (!dtpDateS.Enabled)
                    sdate = dtpDateS.Value.ToString("yyyy-MM-dd");
                List<string[]> list = ces.Read(cbEquipeS.Text, cbAdversaireS.Text, sdate, cbMitempsS.Text, tbNomS.Text, tbPrenomS.Text);
                foreach (string[] tab in list) {
                    dgvEquipeStat.Rows.Add(tab[0], tab[1]);
                }

            } catch (Exception ex) {
                throw ex;
            }

        }

        private void SetEnable(string datePartie, string equipe, string adversaire, string nom, string prenom) {

            try {

                if (datePartie != null) {
                    dtpDateS.Enabled = false;
                    dtpDateS.Value = Convert.ToDateTime(datePartie);
                }

                if (equipe != null) {
                    cbEquipeS.Enabled = false;
                    cbEquipeS.Text = equipe;
                }

                if (adversaire != null) {
                    cbAdversaireS.Enabled = false;
                    cbAdversaireS.Text = adversaire;
                }

                if (nom != null) {
                    tbNomS.Enabled = false;
                    tbNomS.Text = nom;
                }

                if (prenom != null) {
                    tbPrenomS.Enabled = false;
                    tbPrenomS.Text = prenom;
                }

            } catch (Exception ex) {
                throw ex;
            }

        }

        private void dtpDateS_ValueChanged(object sender, EventArgs e) {

        }

        private void cbEquipeS_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbEquipeS.Text = cbEquipeS.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
        }

        private void cbAdversaireS_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbAdversaireS.Text = cbAdversaireS.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
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

        private void ViewEquipeStat_Load(object sender, EventArgs e) {

        }
        
    }
}
