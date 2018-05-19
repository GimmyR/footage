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
    public partial class ViewFormation : Form {
        private System.Data.SqlClient.SqlConnection connexion = null;
        private List<string[]> selected = null;
        private List<string[]> list = null;
        public ViewFormation(System.Data.SqlClient.SqlConnection connexion, string equipe) {
            try {
                this.connexion = connexion;
                selected = new List<string[]>();
                InitializeComponent();
                FillDataGridView(equipe);
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void FillDataGridView(string equipe) {

            try {
                CtrlJoueur cj = new CtrlJoueur(connexion);
                list = cj.Read("", "", "", equipe);
                foreach (string[] tab in list) { // 423
                    dgvFormation.Rows.Add(tab[4], tab[2], tab[3]);
                } AddCheckBox();
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void AddCheckBox() {

            try {

                DataGridViewCheckBoxColumn chb = new DataGridViewCheckBoxColumn();
                dgvFormation.Columns.Add(chb);

            } catch (Exception ex) {
                throw ex;
            }

        }

        private void Select() {
            try {
                for (int i = 0; i < list.Count; i++) {
                    if (Convert.ToBoolean(dgvFormation.Rows[i].Cells[3].Value)) {
                        selected.Add(list.ElementAt(i));
                    }
                }
            } catch (Exception ex) {
                throw ex;
            } 
        }

        public List<string[]> GetSelected() {

            return selected;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void btnValider_Click(object sender, EventArgs e) {
            Select();
        }

        private void ShowSelected() {

            string show = "";

            foreach(string[] tab in selected){

                foreach (string item in tab) {

                    show += item + " ; ";

                } show += "\n";

            } MessageBox.Show(show);

        }

        public Button GetBtnValider() {

            return btnValider;

        }

    }
}
