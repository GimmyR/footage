namespace View {
    partial class ViewProchainsMatchs {
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
            this.dgvProchainsMatchs = new System.Windows.Forms.DataGridView();
            this.Equipe1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChercher = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEquipe1S = new System.Windows.Forms.ComboBox();
            this.cbEquipe2S = new System.Windows.Forms.ComboBox();
            this.cbEquipe1 = new System.Windows.Forms.ComboBox();
            this.cbEquipe2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProchainsMatchs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProchainsMatchs
            // 
            this.dgvProchainsMatchs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProchainsMatchs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Equipe1,
            this.Equipe2});
            this.dgvProchainsMatchs.Location = new System.Drawing.Point(12, 55);
            this.dgvProchainsMatchs.Name = "dgvProchainsMatchs";
            this.dgvProchainsMatchs.Size = new System.Drawing.Size(538, 150);
            this.dgvProchainsMatchs.TabIndex = 0;
            this.dgvProchainsMatchs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProchainsMatchs_CellContentClick);
            // 
            // Equipe1
            // 
            this.Equipe1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Equipe1.HeaderText = "Equipe 1";
            this.Equipe1.Name = "Equipe1";
            // 
            // Equipe2
            // 
            this.Equipe2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Equipe2.HeaderText = "Equipe 2";
            this.Equipe2.Name = "Equipe2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Equipe 1 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Equipe 2 :";
            // 
            // btnChercher
            // 
            this.btnChercher.Location = new System.Drawing.Point(424, 14);
            this.btnChercher.Name = "btnChercher";
            this.btnChercher.Size = new System.Drawing.Size(126, 23);
            this.btnChercher.TabIndex = 5;
            this.btnChercher.Text = "Chercher";
            this.btnChercher.UseVisualStyleBackColor = true;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(424, 220);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(126, 23);
            this.btnAjouter.TabIndex = 10;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Equipe 2 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Equipe 1 :";
            // 
            // cbEquipe1S
            // 
            this.cbEquipe1S.FormattingEnabled = true;
            this.cbEquipe1S.Location = new System.Drawing.Point(73, 14);
            this.cbEquipe1S.Name = "cbEquipe1S";
            this.cbEquipe1S.Size = new System.Drawing.Size(133, 21);
            this.cbEquipe1S.TabIndex = 11;
            this.cbEquipe1S.SelectedIndexChanged += new System.EventHandler(this.cbEquipe1S_SelectedIndexChanged);
            // 
            // cbEquipe2S
            // 
            this.cbEquipe2S.FormattingEnabled = true;
            this.cbEquipe2S.Location = new System.Drawing.Point(273, 14);
            this.cbEquipe2S.Name = "cbEquipe2S";
            this.cbEquipe2S.Size = new System.Drawing.Size(133, 21);
            this.cbEquipe2S.TabIndex = 12;
            this.cbEquipe2S.SelectedIndexChanged += new System.EventHandler(this.cbEquipe2S_SelectedIndexChanged);
            // 
            // cbEquipe1
            // 
            this.cbEquipe1.FormattingEnabled = true;
            this.cbEquipe1.Location = new System.Drawing.Point(73, 222);
            this.cbEquipe1.Name = "cbEquipe1";
            this.cbEquipe1.Size = new System.Drawing.Size(133, 21);
            this.cbEquipe1.TabIndex = 13;
            this.cbEquipe1.SelectedIndexChanged += new System.EventHandler(this.cbEquipe1_SelectedIndexChanged);
            // 
            // cbEquipe2
            // 
            this.cbEquipe2.FormattingEnabled = true;
            this.cbEquipe2.Location = new System.Drawing.Point(273, 222);
            this.cbEquipe2.Name = "cbEquipe2";
            this.cbEquipe2.Size = new System.Drawing.Size(133, 21);
            this.cbEquipe2.TabIndex = 14;
            this.cbEquipe2.SelectedIndexChanged += new System.EventHandler(this.cbEquipe2_SelectedIndexChanged);
            // 
            // ViewProchainsMatchs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 260);
            this.Controls.Add(this.cbEquipe2);
            this.Controls.Add(this.cbEquipe1);
            this.Controls.Add(this.cbEquipe2S);
            this.Controls.Add(this.cbEquipe1S);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnChercher);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProchainsMatchs);
            this.Name = "ViewProchainsMatchs";
            this.Text = "Prochains matchs";
            this.Load += new System.EventHandler(this.ViewProchainsMatchs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProchainsMatchs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProchainsMatchs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipe1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipe2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChercher;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbEquipe1S;
        private System.Windows.Forms.ComboBox cbEquipe2S;
        private System.Windows.Forms.ComboBox cbEquipe1;
        private System.Windows.Forms.ComboBox cbEquipe2;
    }
}