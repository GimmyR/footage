namespace View {
    partial class ViewMatchStat {
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
            this.dtpDateS = new System.Windows.Forms.DateTimePicker();
            this.dgvEquipeStat = new System.Windows.Forms.DataGridView();
            this.Equipe1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnChercher = new System.Windows.Forms.Button();
            this.cbMitempsS = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbEquipe2S = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEquipe1S = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnFiche1 = new System.Windows.Forms.Button();
            this.btnFiche2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipeStat)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDateS
            // 
            this.dtpDateS.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateS.Location = new System.Drawing.Point(60, 19);
            this.dtpDateS.Name = "dtpDateS";
            this.dtpDateS.Size = new System.Drawing.Size(138, 20);
            this.dtpDateS.TabIndex = 26;
            // 
            // dgvEquipeStat
            // 
            this.dgvEquipeStat.AllowUserToAddRows = false;
            this.dgvEquipeStat.AllowUserToDeleteRows = false;
            this.dgvEquipeStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipeStat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Equipe1,
            this.Action,
            this.Equipe2});
            this.dgvEquipeStat.Location = new System.Drawing.Point(21, 65);
            this.dgvEquipeStat.Name = "dgvEquipeStat";
            this.dgvEquipeStat.Size = new System.Drawing.Size(904, 271);
            this.dgvEquipeStat.TabIndex = 25;
            // 
            // Equipe1
            // 
            this.Equipe1.HeaderText = "Equipe 1";
            this.Equipe1.Name = "Equipe1";
            this.Equipe1.Width = 200;
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            // 
            // Equipe2
            // 
            this.Equipe2.HeaderText = "Equipe 2";
            this.Equipe2.Name = "Equipe2";
            this.Equipe2.Width = 200;
            // 
            // btnChercher
            // 
            this.btnChercher.Location = new System.Drawing.Point(850, 17);
            this.btnChercher.Name = "btnChercher";
            this.btnChercher.Size = new System.Drawing.Size(75, 23);
            this.btnChercher.TabIndex = 24;
            this.btnChercher.Text = "Chercher";
            this.btnChercher.UseVisualStyleBackColor = true;
            this.btnChercher.Click += new System.EventHandler(this.btnChercher_Click);
            // 
            // cbMitempsS
            // 
            this.cbMitempsS.FormattingEnabled = true;
            this.cbMitempsS.Location = new System.Drawing.Point(702, 19);
            this.cbMitempsS.Name = "cbMitempsS";
            this.cbMitempsS.Size = new System.Drawing.Size(121, 21);
            this.cbMitempsS.TabIndex = 23;
            this.cbMitempsS.SelectedIndexChanged += new System.EventHandler(this.cbMitempsS_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(630, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Mi-temps :";
            // 
            // cbEquipe2S
            // 
            this.cbEquipe2S.FormattingEnabled = true;
            this.cbEquipe2S.Location = new System.Drawing.Point(492, 19);
            this.cbEquipe2S.Name = "cbEquipe2S";
            this.cbEquipe2S.Size = new System.Drawing.Size(121, 21);
            this.cbEquipe2S.TabIndex = 21;
            this.cbEquipe2S.SelectedIndexChanged += new System.EventHandler(this.cbEquipe2S_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(421, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Equipe 2 :";
            // 
            // cbEquipe1S
            // 
            this.cbEquipe1S.FormattingEnabled = true;
            this.cbEquipe1S.Location = new System.Drawing.Point(279, 19);
            this.cbEquipe1S.Name = "cbEquipe1S";
            this.cbEquipe1S.Size = new System.Drawing.Size(121, 21);
            this.cbEquipe1S.TabIndex = 19;
            this.cbEquipe1S.SelectedIndexChanged += new System.EventHandler(this.cbEquipe1S_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Equipe 1 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Equipe 1 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(870, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = ": Equipe 2";
            // 
            // btnFiche1
            // 
            this.btnFiche1.Location = new System.Drawing.Point(82, 347);
            this.btnFiche1.Name = "btnFiche1";
            this.btnFiche1.Size = new System.Drawing.Size(106, 23);
            this.btnFiche1.TabIndex = 29;
            this.btnFiche1.Text = "Fiche individuel";
            this.btnFiche1.UseVisualStyleBackColor = true;
            this.btnFiche1.Click += new System.EventHandler(this.btnFiche1_Click);
            // 
            // btnFiche2
            // 
            this.btnFiche2.Location = new System.Drawing.Point(758, 347);
            this.btnFiche2.Name = "btnFiche2";
            this.btnFiche2.Size = new System.Drawing.Size(106, 23);
            this.btnFiche2.TabIndex = 30;
            this.btnFiche2.Text = "Fiche individuel";
            this.btnFiche2.UseVisualStyleBackColor = true;
            this.btnFiche2.Click += new System.EventHandler(this.btnFiche2_Click);
            // 
            // ViewMatchStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 384);
            this.Controls.Add(this.btnFiche2);
            this.Controls.Add(this.btnFiche1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDateS);
            this.Controls.Add(this.dgvEquipeStat);
            this.Controls.Add(this.btnChercher);
            this.Controls.Add(this.cbMitempsS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbEquipe2S);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbEquipe1S);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ViewMatchStat";
            this.Text = "ViewMatchStat";
            this.Load += new System.EventHandler(this.ViewMatchStat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipeStat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDateS;
        private System.Windows.Forms.DataGridView dgvEquipeStat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipe1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipe2;
        private System.Windows.Forms.Button btnChercher;
        private System.Windows.Forms.ComboBox cbMitempsS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbEquipe2S;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbEquipe1S;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnFiche1;
        private System.Windows.Forms.Button btnFiche2;

    }
}