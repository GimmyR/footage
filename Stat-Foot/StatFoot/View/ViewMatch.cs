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
    public partial class ViewMatch : Form {
        private System.Data.SqlClient.SqlConnection connexion = null;
        private List<string[]> list = null;
        public ViewMatch(System.Data.SqlClient.SqlConnection connexion) {
            try {
                this.connexion = connexion;
                InitializeComponent();
                FillDataGridView();
                FillCbEquipe();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void FillDataGridView() {

            try {
                CtrlMatch cm = new CtrlMatch(connexion);
                 list = cm.Read(dtp1.Value.ToString("yyyy-MM-dd"), dtp2.Value.ToString("yyyy-MM-dd"), cbEquipe1S.Text, cbEquipe2S.Text);
                foreach (string[] tab in list) {
                    dgvMatchs.Rows.Add(tab[1], tab[2], tab[3]);
                } AddBtnStats();
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void AddBtnStats() {

            try {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Voir stats";
                btn.UseColumnTextForButtonValue = true;
                dgvMatchs.Columns.Add(btn);
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void FillCbEquipe() {

            try {
                CtrlEquipe ce = new CtrlEquipe(connexion);
                List<string[]> list = ce.Read("");
                foreach (string[] tab in list) {
                    cbEquipe1S.Items.Add(tab[1]);
                    cbEquipe2S.Items.Add(tab[1]);
                }
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void dgvMatchs_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                string[] tab = list.ElementAt(e.RowIndex);
                ViewMatchStat ves = new ViewMatchStat(connexion, tab[1], tab[2], tab[3]);
                ves.Show();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void cbEquipe1S_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbEquipe1S.Text = cbEquipe1S.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
        }

        private void cbEquipe2S_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbEquipe2S.Text = cbEquipe2S.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
        }

        private void btnChercher_Click(object sender, EventArgs e) {
            try {
                dgvMatchs.Rows.Clear();
                dgvMatchs.Columns.RemoveAt(3);
                FillDataGridView();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void dtp1_ValueChanged(object sender, EventArgs e) {

        }

        private void ViewMatch_Load(object sender, EventArgs e) {

        }
    }
}
