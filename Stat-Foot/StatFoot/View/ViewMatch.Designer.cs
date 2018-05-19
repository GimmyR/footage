namespace View {
    partial class ViewMatch {
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEquipe1S = new System.Windows.Forms.ComboBox();
            this.cbEquipe2S = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChercher = new System.Windows.Forms.Button();
            this.dgvMatchs = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipe1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatchs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date entre :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtp1
            // 
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(81, 20);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(101, 20);
            this.dtp1.TabIndex = 1;
            this.dtp1.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged);
            // 
            // dtp2
            // 
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp2.Location = new System.Drawing.Point(230, 20);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(101, 20);
            this.dtp2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "et";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Equipe 1 :";
            // 
            // cbEquipe1S
            // 
            this.cbEquipe1S.FormattingEnabled = true;
            this.cbEquipe1S.Location = new System.Drawing.Point(408, 18);
            this.cbEquipe1S.Name = "cbEquipe1S";
            this.cbEquipe1S.Size = new System.Drawing.Size(121, 21);
            this.cbEquipe1S.TabIndex = 5;
            this.cbEquipe1S.SelectedIndexChanged += new System.EventHandler(this.cbEquipe1S_SelectedIndexChanged);
            // 
            // cbEquipe2S
            // 
            this.cbEquipe2S.FormattingEnabled = true;
            this.cbEquipe2S.Location = new System.Drawing.Point(613, 19);
            this.cbEquipe2S.Name = "cbEquipe2S";
            this.cbEquipe2S.Size = new System.Drawing.Size(121, 21);
            this.cbEquipe2S.TabIndex = 7;
            this.cbEquipe2S.SelectedIndexChanged += new System.EventHandler(this.cbEquipe2S_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(552, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Equipe 2 :";
            // 
            // btnChercher
            // 
            this.btnChercher.Location = new System.Drawing.Point(755, 17);
            this.btnChercher.Name = "btnChercher";
            this.btnChercher.Size = new System.Drawing.Size(75, 23);
            this.btnChercher.TabIndex = 8;
            this.btnChercher.Text = "Chercher";
            this.btnChercher.UseVisualStyleBackColor = true;
            this.btnChercher.Click += new System.EventHandler(this.btnChercher_Click);
            // 
            // dgvMatchs
            // 
            this.dgvMatchs.AllowUserToAddRows = false;
            this.dgvMatchs.AllowUserToDeleteRows = false;
            this.dgvMatchs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatchs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Equipe1,
            this.Equipe2});
            this.dgvMatchs.Location = new System.Drawing.Point(15, 63);
            this.dgvMatchs.Name = "dgvMatchs";
            this.dgvMatchs.Size = new System.Drawing.Size(815, 176);
            this.dgvMatchs.TabIndex = 9;
            this.dgvMatchs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatchs_CellContentClick);
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
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
            // ViewMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 261);
            this.Controls.Add(this.dgvMatchs);
            this.Controls.Add(this.btnChercher);
            this.Controls.Add(this.cbEquipe2S);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbEquipe1S);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp1);
            this.Controls.Add(this.label1);
            this.Name = "ViewMatch";
            this.Text = "ViewMatch";
            this.Load += new System.EventHandler(this.ViewMatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatchs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbEquipe1S;
        private System.Windows.Forms.ComboBox cbEquipe2S;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnChercher;
        private System.Windows.Forms.DataGridView dgvMatchs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipe1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipe2;
    }
}