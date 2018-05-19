namespace View {
    partial class ViewCoursMatch {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.btnDemarrer = new System.Windows.Forms.Button();
            this.btnPauser = new System.Windows.Forms.Button();
            this.tbMitemps = new System.Windows.Forms.TextBox();
            this.dgvEquipe1 = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEquipe2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbEquipe1 = new System.Windows.Forms.TextBox();
            this.tbEquipe2 = new System.Windows.Forms.TextBox();
            this.btnFormation1 = new System.Windows.Forms.Button();
            this.btnFormation2 = new System.Windows.Forms.Button();
            this.btnPasse = new System.Windows.Forms.Button();
            this.btnTir = new System.Windows.Forms.Button();
            this.dtpTimerGeneral = new System.Windows.Forms.DateTimePicker();
            this.timerGeneral = new System.Windows.Forms.Timer(this.components);
            this.btnTirCadre = new System.Windows.Forms.Button();
            this.btnBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipe2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDemarrer
            // 
            this.btnDemarrer.Location = new System.Drawing.Point(12, 12);
            this.btnDemarrer.Name = "btnDemarrer";
            this.btnDemarrer.Size = new System.Drawing.Size(75, 23);
            this.btnDemarrer.TabIndex = 0;
            this.btnDemarrer.Text = "Demarrer";
            this.btnDemarrer.UseVisualStyleBackColor = true;
            this.btnDemarrer.Click += new System.EventHandler(this.btnDemarrer_Click);
            // 
            // btnPauser
            // 
            this.btnPauser.Location = new System.Drawing.Point(93, 12);
            this.btnPauser.Name = "btnPauser";
            this.btnPauser.Size = new System.Drawing.Size(75, 23);
            this.btnPauser.TabIndex = 1;
            this.btnPauser.Text = "Pauser";
            this.btnPauser.UseVisualStyleBackColor = true;
            this.btnPauser.Click += new System.EventHandler(this.btnPauser_Click);
            // 
            // tbMitemps
            // 
            this.tbMitemps.Location = new System.Drawing.Point(559, 14);
            this.tbMitemps.Name = "tbMitemps";
            this.tbMitemps.Size = new System.Drawing.Size(181, 20);
            this.tbMitemps.TabIndex = 2;
            this.tbMitemps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvEquipe1
            // 
            this.dgvEquipe1.AllowUserToAddRows = false;
            this.dgvEquipe1.AllowUserToDeleteRows = false;
            this.dgvEquipe1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipe1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Nom,
            this.Prenom});
            this.dgvEquipe1.Location = new System.Drawing.Point(12, 78);
            this.dgvEquipe1.Name = "dgvEquipe1";
            this.dgvEquipe1.Size = new System.Drawing.Size(634, 433);
            this.dgvEquipe1.TabIndex = 3;
            this.dgvEquipe1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEquipe1_CellMouseClick);
            this.dgvEquipe1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEquipe1_CellMouseDoubleClick);
            this.dgvEquipe1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipe1_RowEnter);
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            // 
            // Nom
            // 
            this.Nom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nom.HeaderText = "Nom";
            this.Nom.Name = "Nom";
            // 
            // Prenom
            // 
            this.Prenom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Prenom.HeaderText = "Prenom";
            this.Prenom.Name = "Prenom";
            // 
            // dgvEquipe2
            // 
            this.dgvEquipe2.AllowUserToAddRows = false;
            this.dgvEquipe2.AllowUserToDeleteRows = false;
            this.dgvEquipe2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipe2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvEquipe2.Location = new System.Drawing.Point(663, 78);
            this.dgvEquipe2.Name = "dgvEquipe2";
            this.dgvEquipe2.Size = new System.Drawing.Size(608, 433);
            this.dgvEquipe2.TabIndex = 4;
            this.dgvEquipe2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEquipe2_CellMouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Numero";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Nom";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Prenom";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // tbEquipe1
            // 
            this.tbEquipe1.Location = new System.Drawing.Point(12, 43);
            this.tbEquipe1.Name = "tbEquipe1";
            this.tbEquipe1.Size = new System.Drawing.Size(166, 20);
            this.tbEquipe1.TabIndex = 5;
            this.tbEquipe1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbEquipe2
            // 
            this.tbEquipe2.Location = new System.Drawing.Point(1105, 43);
            this.tbEquipe2.Name = "tbEquipe2";
            this.tbEquipe2.Size = new System.Drawing.Size(166, 20);
            this.tbEquipe2.TabIndex = 6;
            this.tbEquipe2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbEquipe2.TextChanged += new System.EventHandler(this.tbEquipe2_TextChanged);
            // 
            // btnFormation1
            // 
            this.btnFormation1.Location = new System.Drawing.Point(184, 41);
            this.btnFormation1.Name = "btnFormation1";
            this.btnFormation1.Size = new System.Drawing.Size(75, 23);
            this.btnFormation1.TabIndex = 7;
            this.btnFormation1.Text = "Formation";
            this.btnFormation1.UseVisualStyleBackColor = true;
            this.btnFormation1.Click += new System.EventHandler(this.btnFormation1_Click);
            // 
            // btnFormation2
            // 
            this.btnFormation2.Location = new System.Drawing.Point(1024, 41);
            this.btnFormation2.Name = "btnFormation2";
            this.btnFormation2.Size = new System.Drawing.Size(75, 23);
            this.btnFormation2.TabIndex = 8;
            this.btnFormation2.Text = "Formation";
            this.btnFormation2.UseVisualStyleBackColor = true;
            this.btnFormation2.Click += new System.EventHandler(this.btnFormation2_Click);
            // 
            // btnPasse
            // 
            this.btnPasse.Location = new System.Drawing.Point(12, 527);
            this.btnPasse.Name = "btnPasse";
            this.btnPasse.Size = new System.Drawing.Size(143, 23);
            this.btnPasse.TabIndex = 9;
            this.btnPasse.Text = "Passe (A)";
            this.btnPasse.UseVisualStyleBackColor = true;
            this.btnPasse.Click += new System.EventHandler(this.btnPasse_Click);
            // 
            // btnTir
            // 
            this.btnTir.Location = new System.Drawing.Point(161, 527);
            this.btnTir.Name = "btnTir";
            this.btnTir.Size = new System.Drawing.Size(143, 23);
            this.btnTir.TabIndex = 10;
            this.btnTir.Text = "Tir (W)";
            this.btnTir.UseVisualStyleBackColor = true;
            this.btnTir.Click += new System.EventHandler(this.btnTir_Click);
            // 
            // dtpTimerGeneral
            // 
            this.dtpTimerGeneral.Enabled = false;
            this.dtpTimerGeneral.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimerGeneral.Location = new System.Drawing.Point(612, 44);
            this.dtpTimerGeneral.Name = "dtpTimerGeneral";
            this.dtpTimerGeneral.Size = new System.Drawing.Size(83, 20);
            this.dtpTimerGeneral.TabIndex = 11;
            this.dtpTimerGeneral.Value = new System.DateTime(2017, 12, 2, 0, 0, 0, 0);
            // 
            // timerGeneral
            // 
            this.timerGeneral.Interval = 1000;
            this.timerGeneral.Tick += new System.EventHandler(this.timerGeneral_Tick);
            // 
            // btnTirCadre
            // 
            this.btnTirCadre.Location = new System.Drawing.Point(310, 527);
            this.btnTirCadre.Name = "btnTirCadre";
            this.btnTirCadre.Size = new System.Drawing.Size(143, 23);
            this.btnTirCadre.TabIndex = 12;
            this.btnTirCadre.Text = "Tir cadre (D)";
            this.btnTirCadre.UseVisualStyleBackColor = true;
            this.btnTirCadre.Click += new System.EventHandler(this.btnTirCadre_Click);
            // 
            // btnBut
            // 
            this.btnBut.Location = new System.Drawing.Point(459, 527);
            this.btnBut.Name = "btnBut";
            this.btnBut.Size = new System.Drawing.Size(143, 23);
            this.btnBut.TabIndex = 13;
            this.btnBut.Text = "But (ESPACE)";
            this.btnBut.UseVisualStyleBackColor = true;
            this.btnBut.Click += new System.EventHandler(this.btnBut_Click);
            // 
            // ViewCoursMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 565);
            this.Controls.Add(this.btnBut);
            this.Controls.Add(this.btnTirCadre);
            this.Controls.Add(this.dtpTimerGeneral);
            this.Controls.Add(this.btnTir);
            this.Controls.Add(this.btnPasse);
            this.Controls.Add(this.btnFormation2);
            this.Controls.Add(this.btnFormation1);
            this.Controls.Add(this.tbEquipe2);
            this.Controls.Add(this.tbEquipe1);
            this.Controls.Add(this.dgvEquipe2);
            this.Controls.Add(this.dgvEquipe1);
            this.Controls.Add(this.tbMitemps);
            this.Controls.Add(this.btnPauser);
            this.Controls.Add(this.btnDemarrer);
            this.Name = "ViewCoursMatch";
            this.Text = "ViewCoursMatch";
            this.Load += new System.EventHandler(this.ViewCoursMatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipe2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDemarrer;
        private System.Windows.Forms.Button btnPauser;
        private System.Windows.Forms.TextBox tbMitemps;
        private System.Windows.Forms.DataGridView dgvEquipe1;
        private System.Windows.Forms.DataGridView dgvEquipe2;
        private System.Windows.Forms.TextBox tbEquipe1;
        private System.Windows.Forms.TextBox tbEquipe2;
        private System.Windows.Forms.Button btnFormation1;
        private System.Windows.Forms.Button btnFormation2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnPasse;
        private System.Windows.Forms.Button btnTir;
        private System.Windows.Forms.DateTimePicker dtpTimerGeneral;
        private System.Windows.Forms.Timer timerGeneral;
        private System.Windows.Forms.Button btnTirCadre;
        private System.Windows.Forms.Button btnBut;
    }
}