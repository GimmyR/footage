namespace View {
    partial class ViewEquipeStat {
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbEquipeS = new System.Windows.Forms.ComboBox();
            this.cbAdversaireS = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMitempsS = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnChercher = new System.Windows.Forms.Button();
            this.dgvEquipeStat = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpDateS = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNomS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPrenomS = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipeStat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Equipe :";
            // 
            // cbEquipeS
            // 
            this.cbEquipeS.FormattingEnabled = true;
            this.cbEquipeS.Location = new System.Drawing.Point(275, 22);
            this.cbEquipeS.Name = "cbEquipeS";
            this.cbEquipeS.Size = new System.Drawing.Size(121, 21);
            this.cbEquipeS.TabIndex = 3;
            this.cbEquipeS.SelectedIndexChanged += new System.EventHandler(this.cbEquipeS_SelectedIndexChanged);
            // 
            // cbAdversaireS
            // 
            this.cbAdversaireS.FormattingEnabled = true;
            this.cbAdversaireS.Location = new System.Drawing.Point(488, 22);
            this.cbAdversaireS.Name = "cbAdversaireS";
            this.cbAdversaireS.Size = new System.Drawing.Size(121, 21);
            this.cbAdversaireS.TabIndex = 7;
            this.cbAdversaireS.SelectedIndexChanged += new System.EventHandler(this.cbAdversaireS_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Adversaire :";
            // 
            // cbMitempsS
            // 
            this.cbMitempsS.FormattingEnabled = true;
            this.cbMitempsS.Location = new System.Drawing.Point(698, 22);
            this.cbMitempsS.Name = "cbMitempsS";
            this.cbMitempsS.Size = new System.Drawing.Size(121, 21);
            this.cbMitempsS.TabIndex = 9;
            this.cbMitempsS.SelectedIndexChanged += new System.EventHandler(this.cbMitempsS_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(626, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mi-temps :";
            // 
            // btnChercher
            // 
            this.btnChercher.Location = new System.Drawing.Point(1176, 20);
            this.btnChercher.Name = "btnChercher";
            this.btnChercher.Size = new System.Drawing.Size(75, 23);
            this.btnChercher.TabIndex = 10;
            this.btnChercher.Text = "Chercher";
            this.btnChercher.UseVisualStyleBackColor = true;
            this.btnChercher.Click += new System.EventHandler(this.btnChercher_Click);
            // 
            // dgvEquipeStat
            // 
            this.dgvEquipeStat.AllowUserToAddRows = false;
            this.dgvEquipeStat.AllowUserToDeleteRows = false;
            this.dgvEquipeStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipeStat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action,
            this.Nombre});
            this.dgvEquipeStat.Location = new System.Drawing.Point(17, 68);
            this.dgvEquipeStat.Name = "dgvEquipeStat";
            this.dgvEquipeStat.Size = new System.Drawing.Size(1234, 271);
            this.dgvEquipeStat.TabIndex = 11;
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 200;
            // 
            // dtpDateS
            // 
            this.dtpDateS.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateS.Location = new System.Drawing.Point(56, 22);
            this.dtpDateS.Name = "dtpDateS";
            this.dtpDateS.Size = new System.Drawing.Size(138, 20);
            this.dtpDateS.TabIndex = 12;
            this.dtpDateS.ValueChanged += new System.EventHandler(this.dtpDateS_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(837, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nom :";
            // 
            // tbNomS
            // 
            this.tbNomS.Location = new System.Drawing.Point(889, 22);
            this.tbNomS.Name = "tbNomS";
            this.tbNomS.Size = new System.Drawing.Size(100, 20);
            this.tbNomS.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1004, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Prenom :";
            // 
            // tbPrenomS
            // 
            this.tbPrenomS.Location = new System.Drawing.Point(1059, 22);
            this.tbPrenomS.Name = "tbPrenomS";
            this.tbPrenomS.Size = new System.Drawing.Size(100, 20);
            this.tbPrenomS.TabIndex = 16;
            // 
            // ViewEquipeStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 363);
            this.Controls.Add(this.tbPrenomS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbNomS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDateS);
            this.Controls.Add(this.dgvEquipeStat);
            this.Controls.Add(this.btnChercher);
            this.Controls.Add(this.cbMitempsS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbAdversaireS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbEquipeS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ViewEquipeStat";
            this.Text = "ViewEquipeStat";
            this.Load += new System.EventHandler(this.ViewEquipeStat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipeStat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEquipeS;
        private System.Windows.Forms.ComboBox cbAdversaireS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMitempsS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnChercher;
        private System.Windows.Forms.DataGridView dgvEquipeStat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DateTimePicker dtpDateS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNomS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPrenomS;
    }
}