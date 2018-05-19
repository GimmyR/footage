namespace View {
    partial class ViewConfig {
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
            this.dtpMitemps = new System.Windows.Forms.DateTimePicker();
            this.Equipe1 = new System.Windows.Forms.Label();
            this.Equipe2 = new System.Windows.Forms.Label();
            this.cbEquipe1 = new System.Windows.Forms.ComboBox();
            this.cbEquipe2 = new System.Windows.Forms.ComboBox();
            this.btnCreer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Duree de mi-temps :";
            // 
            // dtpMitemps
            // 
            this.dtpMitemps.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpMitemps.Location = new System.Drawing.Point(257, 41);
            this.dtpMitemps.Name = "dtpMitemps";
            this.dtpMitemps.Size = new System.Drawing.Size(98, 20);
            this.dtpMitemps.TabIndex = 1;
            // 
            // Equipe1
            // 
            this.Equipe1.AutoSize = true;
            this.Equipe1.Location = new System.Drawing.Point(133, 89);
            this.Equipe1.Name = "Equipe1";
            this.Equipe1.Size = new System.Drawing.Size(55, 13);
            this.Equipe1.TabIndex = 2;
            this.Equipe1.Text = "Equipe 1 :";
            // 
            // Equipe2
            // 
            this.Equipe2.AutoSize = true;
            this.Equipe2.Location = new System.Drawing.Point(133, 137);
            this.Equipe2.Name = "Equipe2";
            this.Equipe2.Size = new System.Drawing.Size(55, 13);
            this.Equipe2.TabIndex = 3;
            this.Equipe2.Text = "Equipe 2 :";
            // 
            // cbEquipe1
            // 
            this.cbEquipe1.FormattingEnabled = true;
            this.cbEquipe1.Location = new System.Drawing.Point(244, 86);
            this.cbEquipe1.Name = "cbEquipe1";
            this.cbEquipe1.Size = new System.Drawing.Size(121, 21);
            this.cbEquipe1.TabIndex = 4;
            this.cbEquipe1.SelectedIndexChanged += new System.EventHandler(this.cbEquipe1_SelectedIndexChanged);
            // 
            // cbEquipe2
            // 
            this.cbEquipe2.FormattingEnabled = true;
            this.cbEquipe2.Location = new System.Drawing.Point(244, 134);
            this.cbEquipe2.Name = "cbEquipe2";
            this.cbEquipe2.Size = new System.Drawing.Size(121, 21);
            this.cbEquipe2.TabIndex = 5;
            this.cbEquipe2.SelectedIndexChanged += new System.EventHandler(this.cbEquipe2_SelectedIndexChanged);
            // 
            // btnCreer
            // 
            this.btnCreer.Location = new System.Drawing.Point(195, 195);
            this.btnCreer.Name = "btnCreer";
            this.btnCreer.Size = new System.Drawing.Size(75, 23);
            this.btnCreer.TabIndex = 6;
            this.btnCreer.Text = "Creer";
            this.btnCreer.UseVisualStyleBackColor = true;
            this.btnCreer.Click += new System.EventHandler(this.btnCreer_Click);
            // 
            // ViewConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 261);
            this.Controls.Add(this.btnCreer);
            this.Controls.Add(this.cbEquipe2);
            this.Controls.Add(this.cbEquipe1);
            this.Controls.Add(this.Equipe2);
            this.Controls.Add(this.Equipe1);
            this.Controls.Add(this.dtpMitemps);
            this.Controls.Add(this.label1);
            this.Name = "ViewConfig";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.ViewConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpMitemps;
        private System.Windows.Forms.Label Equipe1;
        private System.Windows.Forms.Label Equipe2;
        private System.Windows.Forms.ComboBox cbEquipe1;
        private System.Windows.Forms.ComboBox cbEquipe2;
        private System.Windows.Forms.Button btnCreer;
    }
}