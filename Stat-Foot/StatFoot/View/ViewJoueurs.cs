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
    public partial class ViewJoueurs : Form {
        private SqlConnection connexion = null;
        private List<string> ids = null;
        private string datePartie = null;
        private string adversaire = null;
        public ViewJoueurs(SqlConnection connexion, string datePartie, string equipe, string adversaire) {
            try {
                this.connexion = connexion;
                this.datePartie = datePartie;
                this.adversaire = adversaire;
                InitializeComponent();
                if (equipe != null) {
                    this.cbEquipeS.Enabled = false;
                    this.cbEquipeS.Text = equipe;
                } FillDataGridView();
                FillCbEquipe();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void ViewJoueurs_Load(object sender, EventArgs e) {

        }

        private void FillDataGridView() {

            try {

                ids = new List<string>();

                CtrlJoueur cj = new CtrlJoueur(connexion);
                List<string[]> joueurs = cj.Read(tbNomS.Text, tbPrenomS.Text, tbNumeroS.Text, cbEquipeS.Text);
                for (int i = 0; i < joueurs.Count; i++) {
                    string[] tab = joueurs.ElementAt(i);
                    dgvJoueurs.Rows.Add(tab[2], tab[3], tab[4], tab[1]);
                    ids.Add(tab[0]);
                } AddButtons();

            } catch (Exception ex) {

                throw ex;

            }

        }

        private void AddButtons() {

            try {

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Voir stats";
                btn.UseColumnTextForButtonValue = true;
                dgvJoueurs.Columns.Add(btn);

            } catch (Exception ex) {
                throw ex;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

            try {
                string id = ids.ElementAt(e.RowIndex);
                Model.EquipeDetailsDAO eddao = new Model.EquipeDetailsDAO(connexion);
                Model.EquipeDetails ed = eddao.Select("WHERE id='" + id + "'").First();
                ViewEquipeStat ves = new ViewEquipeStat(connexion, datePartie, ed.Equipe.Nom, adversaire, ed.Joueur.Nom, ed.Joueur.Prenom);
                ves.Show();
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void btnChercher_Click(object sender, EventArgs e) {
            try {
                dgvJoueurs.Rows.Clear();
                dgvJoueurs.Columns.RemoveAt(4);
                FillDataGridView();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void tbNomS_TextChanged(object sender, EventArgs e) {

        }

        private void FillCbEquipe() {

            try {

                CtrlEquipe ce = new CtrlEquipe(connexion);
                List<string[]> equipes = ce.Read("");
                foreach (string[] tab in equipes) {

                    cbEquipe.Items.Add(tab[1]);
                    cbEquipeS.Items.Add(tab[1]);

                }

            } catch (Exception ex) {
                throw ex;
            }

        }

        private void cbEquipeS_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbEquipeS.Text = cbEquipeS.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
        }

        private void cbEquipe_SelectedIndexChanged(object sender, EventArgs e) {
            try { cbEquipe.Text = cbEquipe.SelectedItem.ToString(); } catch (Exception ex) { throw ex; }
        }

    }
}
