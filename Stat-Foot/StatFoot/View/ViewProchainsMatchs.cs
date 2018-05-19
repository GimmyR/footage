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
    public partial class ViewProchainsMatchs : Form {
        private System.Data.SqlClient.SqlConnection connexion = null;
        private List<string[]> list = null;
        public ViewProchainsMatchs(System.Data.SqlClient.SqlConnection connexion) {
            try {
                this.connexion = connexion;
                InitializeComponent();
                FillDataGridView();
                AddBtnDemarrer();
                FillCbEquipe();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void FillDataGridView() {

            try {

                CtrlProchainePartie cpp = new CtrlProchainePartie(connexion);
                list = cpp.Read(cbEquipe1S.Text, cbEquipe2S.Text);
                foreach (string[] tab in list) {
                    dgvProchainsMatchs.Rows.Add(tab[1], tab[2]);
                }

            } catch (Exception ex) {
                throw ex;
                //MessageBox.Show(ex.Message + ":\n" + ex.StackTrace);
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

        private void AddBtnDemarrer() {

            try {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Demarrer";
                btn.UseColumnTextForButtonValue = true;
                dgvProchainsMatchs.Columns.Add(btn);
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void dgvProchainsMatchs_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                int index = e.RowIndex;
                string[] tab = list.ElementAt(index);
                Model.ProchainePartieDAO ppdao = new Model.ProchainePartieDAO(connexion);
                Model.ProchainePartie partie = ppdao.Select("WHERE id='" + tab[0] + "'").First();
                ViewConfig vc = new ViewConfig(connexion, partie);
                vc.Show();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void ViewProchainsMatchs_Load(object sender, EventArgs e) {

        }

        private void cbEquipe1S_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbEquipe1S.Text = cbEquipe1S.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
        }

        private void cbEquipe2S_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbEquipe2S.Text = cbEquipe2S.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
        }

        private void cbEquipe1_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbEquipe1.Text = cbEquipe1.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
        }

        private void cbEquipe2_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbEquipe2.Text = cbEquipe2.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
        }

        private void btnAjouter_Click(object sender, EventArgs e) {
            Model.EquipeDAO eqdao = new Model.EquipeDAO(connexion);
            Model.Equipe eq1 = eqdao.Select("WHERE nom = '" + cbEquipe1.Text + "'").First();
            Model.Equipe eq2 = eqdao.Select("WHERE nom = '" + cbEquipe2.Text + "'").First();

            Model.ProchainePartieDAO pptdao = new Model.ProchainePartieDAO(connexion);
            Model.ProchainePartie pp = new Model.ProchainePartie(pptdao.NextId(), eq1, eq2, null);
            pptdao.Insert(pp.ToInsert());

            dgvProchainsMatchs.Rows.Clear();
            FillDataGridView();
        }
    }
}
