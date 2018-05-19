namespace View {
    partial class ViewJoueurs {
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
            this.tbNomS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPrenomS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNumeroS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEquipeS = new System.Windows.Forms.ComboBox();
            this.cbEquipe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNumero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPrenom = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.dgvJoueurs = new System.Windows.Forms.DataGridView();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnChercher = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJoueurs)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNomS
            // 
            this.tbNomS.Location = new System.Drawing.Point(63, 13);
            this.tbNomS.Name = "tbNomS";
            this.tbNomS.Size = new System.Drawing.Size(100, 20);
            this.tbNomS.TabIndex = 0;
            this.tbNomS.TextChanged += new System.EventHandler(this.tbNomS_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prenom :";
            // 
            // tbPrenomS
            // 
            this.tbPrenomS.Location = new System.Drawing.Point(251, 13);
            this.tbPrenomS.Name = "tbPrenomS";
            this.tbPrenomS.Size = new System.Drawing.Size(100, 20);
            this.tbPrenomS.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Numero :";
            // 
            // tbNumeroS
            // 
            this.tbNumeroS.Location = new System.Drawing.Point(465, 13);
            this.tbNumeroS.Name = "tbNumeroS";
            this.tbNumeroS.Size = new System.Drawing.Size(100, 20);
            this.tbNumeroS.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(593, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Equipe :";
            // 
            // cbEquipeS
            // 
            this.cbEquipeS.FormattingEnabled = true;
            this.cbEquipeS.Location = new System.Drawing.Point(667, 13);
            this.cbEquipeS.Name = "cbEquipeS";
            this.cbEquipeS.Size = new System.Drawing.Size(121, 21);
            this.cbEquipeS.TabIndex = 7;
            this.cbEquipeS.SelectedIndexChanged += new System.EventHandler(this.cbEquipeS_SelectedIndexChanged);
            // 
            // cbEquipe
            // 
            this.cbEquipe.FormattingEnabled = true;
            this.cbEquipe.Location = new System.Drawing.Point(667, 221);
            this.cbEquipe.Name = "cbEquipe";
            this.cbEquipe.Size = new System.Drawing.Size(121, 21);
            this.cbEquipe.TabIndex = 15;
            this.cbEquipe.SelectedIndexChanged += new System.EventHandler(this.cbEquipe_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(593, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Equipe :";
            // 
            // tbNumero
            // 
            this.tbNumero.Location = new System.Drawing.Point(468, 223);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(100, 20);
            this.tbNumero.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(389, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Numero :";
            // 
            // tbPrenom
            // 
            this.tbPrenom.Location = new System.Drawing.Point(251, 223);
            this.tbPrenom.Name = "tbPrenom";
            this.tbPrenom.Size = new System.Drawing.Size(100, 20);
            this.tbPrenom.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Prenom :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Nom :";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(63, 223);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(100, 20);
            this.tbNom.TabIndex = 8;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(818, 221);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(75, 23);
            this.btnAjouter.TabIndex = 16;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            // 
            // dgvJoueurs
            // 
            this.dgvJoueurs.AllowUserToAddRows = false;
            this.dgvJoueurs.AllowUserToDeleteRows = false;
            this.dgvJoueurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJoueurs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nom,
            this.Prenom,
            this.Numero,
            this.Equipe});
            this.dgvJoueurs.Location = new System.Drawing.Point(25, 53);
            this.dgvJoueurs.Name = "dgvJoueurs";
            this.dgvJoueurs.Size = new System.Drawing.Size(868, 150);
            this.dgvJoueurs.TabIndex = 17;
            this.dgvJoueurs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // Numero
            // 
            this.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            // 
            // Equipe
            // 
            this.Equipe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Equipe.HeaderText = "Equipe";
            this.Equipe.Name = "Equipe";
            // 
            // btnChercher
            // 
            this.btnChercher.Location = new System.Drawing.Point(818, 10);
            this.btnChercher.Name = "btnChercher";
            this.btnChercher.Size = new System.Drawing.Size(75, 23);
            this.btnChercher.TabIndex = 18;
            this.btnChercher.Text = "Chercher";
            this.btnChercher.UseVisualStyleBackColor = true;
            this.btnChercher.Click += new System.EventHandler(this.btnChercher_Click);
            // 
            // ViewJoueurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 261);
            this.Controls.Add(this.btnChercher);
            this.Controls.Add(this.dgvJoueurs);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.cbEquipe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbNumero);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPrenom);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.cbEquipeS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbNumeroS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPrenomS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNomS);
            this.Name = "ViewJoueurs";
            this.Text = "Les joueurs";
            this.Load += new System.EventHandler(this.ViewJoueurs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJoueurs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNomS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPrenomS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNumeroS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbEquipeS;
        private System.Windows.Forms.ComboBox cbEquipe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNumero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPrenom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.DataGridView dgvJoueurs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipe;
        private System.Windows.Forms.Button btnChercher;
    }
}