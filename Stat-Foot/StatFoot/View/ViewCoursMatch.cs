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
    public partial class ViewCoursMatch : Form {
        private System.Data.SqlClient.SqlConnection connexion = null;
        private string partie = null;
        private string mitemps = null;
        private string equipe1 = null;
        private string equipe2 = null;
        private List<string> ids1 = null, ids2 = null;
        private ViewFormation vf1 = null, vf2 = null;
        private string duree = null;

        private List<Timer> timers1 = null;
        private List<Timer> timers2 = null;
        private Dictionary<string, string>[] possession = null;
        public ViewCoursMatch(System.Data.SqlClient.SqlConnection connexion, string partie, string duree, string mitemps, string equipe1, string equipe2) {
            try {
                this.connexion = connexion;
                this.partie = partie;
                this.mitemps = mitemps;
                this.equipe1 = equipe1;
                this.equipe2 = equipe2;
                this.duree = duree;
                timers1 = new List<Timer>();
                timers2 = new List<Timer>();
                possession = new Dictionary<string, string>[2];
                possession[0] = new Dictionary<string, string>();
                possession[1] = new Dictionary<string, string>();
                InitializeComponent();
                AddKeyListener();
                SetEnable();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void AddKeyListener() {

            try {

                this.KeyPreview = true;
                this.KeyPress += new KeyPressEventHandler(ViewCoursMatch_KeyPress);

            } catch (Exception ex) {

                throw ex;

            }

        }

        private void SetEnable() {

            try {

                if (mitemps != null) {
                    tbMitemps.Enabled = false;
                    tbMitemps.Text = "Mi-temps : " + mitemps;
                }

                if (equipe1 != "") {
                    tbEquipe1.Enabled = false;
                    tbEquipe1.Text = equipe1;
                }

                if (equipe2 != "") {
                    tbEquipe2.Enabled = false;
                    tbEquipe2.Text = equipe2;
                }

            } catch (Exception ex) {

                throw ex;

            }

        }

        private void ViewCoursMatch_Load(object sender, EventArgs e) {

        }

        private void tbEquipe2_TextChanged(object sender, EventArgs e) {

        }

        private void dgvEquipe1_RowEnter(object sender, DataGridViewCellEventArgs e) {
            
        }

        private void btnFormation1_Click(object sender, EventArgs e) {
            try {
                vf1 = new ViewFormation(connexion, equipe1);
                vf1.GetBtnValider().Click += new EventHandler(BtnValider_Click1);
                vf1.Show();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void btnFormation2_Click(object sender, EventArgs e) {
            try {
                vf2 = new ViewFormation(connexion, equipe2);
                vf2.GetBtnValider().Click += new EventHandler(BtnValider_Click2);
                vf2.Show();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void FillDataGridView1(List<string[]> joueurs) {

            try {
                ids1 = new List<string>();
                for (int i = 0; i < joueurs.Count; i++) {
                    string[] tab = joueurs.ElementAt(i);

                    dgvEquipe1.Rows.Add(tab[4], tab[2], tab[3]);
                    ids1.Add(tab[0]);
                    Timer timer = new Timer();
                    timer.Interval = 1000;
                    timer.Tick += new EventHandler(TimerPersonnal_Tick);
                    timer.Tag = tab[0] + ":" + 0;
                    timers1.Add(timer);
                }
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void FillDataGridView2(List<string[]> joueurs) {

            try {
                ids2 = new List<string>();
                for (int i = 0; i < joueurs.Count; i++) {
                    string[] tab = joueurs.ElementAt(i);

                    dgvEquipe2.Rows.Add(tab[4], tab[2], tab[3]);
                    ids2.Add(tab[0]);
                    Timer timer = new Timer();
                    timer.Interval = 1000;
                    timer.Tick += new EventHandler(TimerPersonnal_Tick);
                    timer.Tag = tab[0] + ":" + 1;
                    timers2.Add(timer);
                }
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void TimerPersonnal_Tick(object sender, EventArgs e) {

            try {

                char[] sep = { ':' };
                Timer timer = (Timer)sender;
                string tag = timer.Tag.ToString();
                string[] strsplit = tag.Split(sep);
                string id = strsplit[0];
                int eq = int.Parse(strsplit[1]);

                DateTime next = default(DateTime);
                if (possession[eq].Keys.Contains(id)) {

                    DateTime init = Convert.ToDateTime(possession[eq][id]);
                    next = init.AddSeconds(1);

                } else {

                    next = Convert.ToDateTime("00:00:00");

                } possession[eq][id] = next.ToString("HH:mm:ss");

            } catch (Exception ex) {
                throw ex;
            }

        }

        private void StopAllPersoTimer() {

            foreach (Timer timer in timers1) {
                timer.Stop();
            }

            foreach (Timer timer in timers2) {
                timer.Stop();
            }

        }

        private void AddAllPossession() {

            try {
                CtrlCoursMatch ccm = new CtrlCoursMatch(connexion);
                string[] noms = { equipe1, equipe2 };
                for (int i = 0; i < possession.Length; i++) {
                    foreach (KeyValuePair<string, string> keyvalue in possession[i]) {
                        ccm.SetTempsPossession(partie, mitemps, noms[i], keyvalue.Key, keyvalue.Value);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void BtnValider_Click1(object sender, EventArgs e) {

            try {

                List<string[]> joueurs = vf1.GetSelected();
                vf1.Close();
                FillDataGridView1(joueurs);

            } catch (Exception ex) {
                throw ex;
            }

        }

        private void BtnValider_Click2(object sender, EventArgs e) {

            try {
                List<string[]> joueurs = vf2.GetSelected();
                vf2.Close();
                FillDataGridView2(joueurs);
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void timerGeneral_Tick(object sender, EventArgs e) {
            try {
                DateTime init = dtpTimerGeneral.Value;
                if (duree == init.ToString("HH:mm:ss")) {
                    timerGeneral.Stop();
                    StopAllPersoTimer();
                    AddAllPossession();
                    MessageBox.Show("Ce mitemps est termine !");
                    Suite();
                    this.Close();
                } else {
                    DateTime next = init.AddSeconds(1);
                    dtpTimerGeneral.Text = next.ToString("HH:mm:ss");
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void Suite() {

            try {

                int mt = int.Parse(mitemps);
                Model.PartieDAO ptdao = new Model.PartieDAO(connexion);
                if ((mt % 2) == 0) {

                    if (true) { // SI IL Y A PAS D'EGALITE

                        Model.Partie pt = ptdao.Select("WHERE id = '" + this.partie + "'").First();
                        pt.Fini = 1;
                        ptdao.Update(pt.ToUpdate(), "WHERE id='" + pt.Id + "'");
                        string datePartie = pt.DatePartie.ToString("yyyy-MM-dd HH:mm:ss");

                        Ctrl.RestClient client = new RestClient();
                        String json = "{ \"id\": \"" + pt.Id + "\" }";
                        client.Post("http://localhost:51549/api/Departager", json);

                        ViewMatchStat vms = new ViewMatchStat(connexion, datePartie, equipe2, equipe1);
                        vms.Show();

                    } else {

                        ViewCoursMatch vcm = new ViewCoursMatch(connexion, partie, duree, (mt + 1) + "", equipe1, equipe2);
                        vcm.Show();

                    }

                } else {

                    DialogResult result = MessageBox.Show("Continuer avec le prochain mi-temps ?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) {

                        ViewCoursMatch vcm = new ViewCoursMatch(connexion, partie, duree, (mt + 1) + "", equipe2, equipe1);
                        vcm.Show();

                    } else if (result == DialogResult.No) {

                        Model.Partie pt = ptdao.Select("WHERE id = '" + this.partie + "'").First();
                        pt.Fini = 1;
                        ptdao.Update(pt.ToUpdate(), "WHERE id='" + pt.Id + "'");
                        string datePartie = pt.DatePartie.ToString("yyyy-MM-dd HH:mm:ss");

                        Ctrl.RestClient client = new RestClient();
                        String json = "{ \"id\": \"" + pt.Id + "\" }";
                        client.Post("http://localhost:51549/api/Departager", json);

                        ViewMatchStat vms = new ViewMatchStat(connexion, datePartie, equipe1, equipe2);
                        vms.Show();

                    } else {

                        throw new Exception("Une erreur inconnue !");

                    }

                }

            } catch (Exception ex) {
                throw ex;
                //System.Windows.Forms.MessageBox.Show(ex.StackTrace);
            }

        }

        private void btnDemarrer_Click(object sender, EventArgs e) {
            try { 
                timerGeneral.Start();
            } catch (Exception ex) { 
                throw ex; 
            }
        }

        private void btnPauser_Click(object sender, EventArgs e) {
            try { 
                timerGeneral.Stop();
                StopAllPersoTimer();
            } catch (Exception ex) { 
                throw ex; 
            }
        }

        private void dgvEquipe1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {

        }

        private void ViewCoursMatch_KeyPress(object sender, KeyPressEventArgs e) {

            try {

                char[] spec = { 'a', 'w', 'd', ' ' };
                if (e.KeyChar == spec[0]) {
                    btnPasse.PerformClick();
                } else if (e.KeyChar == spec[1]) {
                    btnTir.PerformClick();
                } else if (e.KeyChar == spec[2]) {
                    btnTirCadre.PerformClick();
                } else if (e.KeyChar == spec[3]) {
                    btnBut.PerformClick();
                }

            } catch (Exception ex) {
                throw ex;
            }
        }

        private void dgvEquipe1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button.Equals(MouseButtons.Left)) {
                CtrlCoursMatch ccm = new CtrlCoursMatch(connexion);
                int index = e.RowIndex;
                ccm.Possession(partie, mitemps, dtpTimerGeneral.Value.ToString("HH:mm:ss"), equipe1, ids1.ElementAt(index));
                StopAllPersoTimer();
                timers1.ElementAt(index).Start();
            }
        }

        private void dgvEquipe2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button.Equals(MouseButtons.Left)) {
                CtrlCoursMatch ccm = new CtrlCoursMatch(connexion);
                int index = e.RowIndex;
                ccm.Possession(partie, mitemps, dtpTimerGeneral.Value.ToString("HH:mm:ss"), equipe2, ids1.ElementAt(index));
                StopAllPersoTimer();
                timers2.ElementAt(index).Start();
            }
        }

        private void btnPasse_Click(object sender, EventArgs e) {
            try {
                //MessageBox.Show("Une passe !!");
                //StopAllPersoTimer();
                CtrlCoursMatch ccm = new CtrlCoursMatch(connexion);
                ccm.Passe(partie, mitemps, dtpTimerGeneral.Value.ToString("HH:mm:ss"));
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void btnTir_Click(object sender, EventArgs e) {
            try {
                //MessageBox.Show("Un tir !!");
                //StopAllPersoTimer();
                CtrlCoursMatch ccm = new CtrlCoursMatch(connexion);
                ccm.Tir(partie, mitemps, dtpTimerGeneral.Value.ToString("HH:mm:ss"));
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void btnTirCadre_Click(object sender, EventArgs e) {
            try {
                //MessageBox.Show("Un tir cadre !!");
                //StopAllPersoTimer();
                CtrlCoursMatch ccm = new CtrlCoursMatch(connexion);
                ccm.TirCadre(partie, mitemps, dtpTimerGeneral.Value.ToString("HH:mm:ss"));
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void btnBut_Click(object sender, EventArgs e) {
            try {
                //MessageBox.Show("Buuuuuut !!");
                //StopAllPersoTimer();
                CtrlCoursMatch ccm = new CtrlCoursMatch(connexion);
                ccm.But(partie, mitemps, dtpTimerGeneral.Value.ToString("HH:mm:ss"));
            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}
