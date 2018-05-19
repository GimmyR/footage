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
    public partial class ViewConfig : Form {
        private System.Data.SqlClient.SqlConnection connexion = null;
        private Model.ProchainePartie partie = null;

        public ViewConfig(System.Data.SqlClient.SqlConnection connexion) {
            try {
                this.connexion = connexion;
                InitializeComponent();
                FillCbEquipe();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ViewConfig(System.Data.SqlClient.SqlConnection connexion, Model.ProchainePartie partie) {
            try {
                this.connexion = connexion;
                this.partie = partie;
                InitializeComponent();
                SetEnable();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void FillCbEquipe() {

            try {
                CtrlEquipe ce = new CtrlEquipe(connexion);
                List<string[]> list = ce.Read("");
                foreach (string[] tab in list) {
                    cbEquipe1.Items.Add(tab[1]);
                    cbEquipe2.Items.Add(tab[1]);
                }
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void SetEnable() {

            try {

                if (partie != null) {
                    cbEquipe1.Enabled = false;
                    cbEquipe1.Text = partie.Equipe1.Nom;
                    cbEquipe2.Enabled = false;
                    cbEquipe2.Text = partie.Equipe2.Nom;
                }

            } catch (Exception ex) {
                throw ex;
            }

        }

        private void ViewConfig_Load(object sender, EventArgs e) {

        }

        private void btnCreer_Click(object sender, EventArgs e) {
            try {
                CtrlConfiguration cc = new CtrlConfiguration(connexion);
                string equipe1 = cbEquipe1.Text;
                string equipe2 = cbEquipe2.Text;
                string duree = dtpMitemps.Value.ToString("HH:mm:ss");
                string partie = cc.Create(equipe1, equipe2, duree);
                ViewCoursMatch vcm = new ViewCoursMatch(connexion, partie, duree, "1", equipe1, equipe2);
                vcm.Show();

                if (this.partie != null) {

                    Model.ProchainePartieDAO ppdao = new Model.ProchainePartieDAO(connexion);
                    Model.PartieDAO ptdao = new Model.PartieDAO(connexion);
                    Model.Partie encours = ptdao.Select("WHERE id='" + partie + "'").First();
                    this.partie.Partie = encours;

                    ppdao.Update(this.partie.ToUpdate(), "WHERE id='" + this.partie.Id + "'");

                }
            } catch (Exception ex) {
                throw ex;
                //throw new Exception("Etape : " + etape);
                //System.Windows.Forms.MessageBox.Show(ex.Message + ":" + ex.StackTrace);
            }
        }

        private void cbEquipe1_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbEquipe1.Text = cbEquipe1.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
        }

        private void cbEquipe2_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbEquipe2.Text = cbEquipe2.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
        }
    }
}
