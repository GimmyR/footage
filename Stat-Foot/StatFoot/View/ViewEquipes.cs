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
using Ctrl;

namespace View {
    public partial class ViewEquipes : Form {
        private SqlConnection connexion = null;
        private List<string> ids = null;
        public ViewEquipes(SqlConnection connexion) {
            try {
                this.connexion = connexion;
                InitializeComponent();
                FillDataGridView();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void FillDataGridView() {

            try {
                ids = new List<string>();
                CtrlEquipe ce = new CtrlEquipe(connexion);
                List<string[]> list = ce.Read(tbNomS.Text);
                foreach (string[] tab in list) {
                    dgvEquipes.Rows.Add(tab[1]);
                    ids.Add(tab[1]);
                } AddBtnJoueurs();
                AddBtnStats();
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void AddBtnJoueurs() {

            try {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Voir joueurs";
                btn.UseColumnTextForButtonValue = true;
                dgvEquipes.Columns.Add(btn);
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void AddBtnStats() {

            try {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Voir stats";
                btn.UseColumnTextForButtonValue = true;
                dgvEquipes.Columns.Add(btn);
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                string equipe = ids.ElementAt(e.RowIndex);
                if (e.ColumnIndex == 1) {

                } else if (e.ColumnIndex == 2) {
                    ViewEquipeStat ves = new ViewEquipeStat(connexion, null, equipe, null, null, null);
                    ves.Show();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void btnChercher_Click(object sender, EventArgs e) {
            try {
                dgvEquipes.Rows.Clear();
                dgvEquipes.Columns.RemoveAt(1);
                dgvEquipes.Columns.RemoveAt(1);
                FillDataGridView();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
