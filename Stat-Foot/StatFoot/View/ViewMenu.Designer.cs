namespace View {
    partial class ViewMenu {
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
            this.btnCommencer = new System.Windows.Forms.Button();
            this.btnEquipes = new System.Windows.Forms.Button();
            this.btnMatch = new System.Windows.Forms.Button();
            this.btnJoueurs = new System.Windows.Forms.Button();
            this.btnProchainMatch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCommencer
            // 
            this.btnCommencer.Location = new System.Drawing.Point(265, 33);
            this.btnCommencer.Name = "btnCommencer";
            this.btnCommencer.Size = new System.Drawing.Size(164, 43);
            this.btnCommencer.TabIndex = 0;
            this.btnCommencer.Text = "Commener un match";
            this.btnCommencer.UseVisualStyleBackColor = true;
            this.btnCommencer.Click += new System.EventHandler(this.btnCommencer_Click);
            // 
            // btnEquipes
            // 
            this.btnEquipes.Location = new System.Drawing.Point(265, 111);
            this.btnEquipes.Name = "btnEquipes";
            this.btnEquipes.Size = new System.Drawing.Size(164, 43);
            this.btnEquipes.TabIndex = 1;
            this.btnEquipes.Text = "Equipes";
            this.btnEquipes.UseVisualStyleBackColor = true;
            this.btnEquipes.Click += new System.EventHandler(this.btnEquipe_Click);
            // 
            // btnMatch
            // 
            this.btnMatch.Location = new System.Drawing.Point(265, 189);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(164, 43);
            this.btnMatch.TabIndex = 2;
            this.btnMatch.Text = "Matchs";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // btnJoueurs
            // 
            this.btnJoueurs.Location = new System.Drawing.Point(265, 269);
            this.btnJoueurs.Name = "btnJoueurs";
            this.btnJoueurs.Size = new System.Drawing.Size(164, 43);
            this.btnJoueurs.TabIndex = 3;
            this.btnJoueurs.Text = "Joueurs";
            this.btnJoueurs.UseVisualStyleBackColor = true;
            this.btnJoueurs.Click += new System.EventHandler(this.btnJoueurs_Click);
            // 
            // btnProchainMatch
            // 
            this.btnProchainMatch.Location = new System.Drawing.Point(265, 344);
            this.btnProchainMatch.Name = "btnProchainMatch";
            this.btnProchainMatch.Size = new System.Drawing.Size(164, 43);
            this.btnProchainMatch.TabIndex = 4;
            this.btnProchainMatch.Text = "Prochains matchs";
            this.btnProchainMatch.UseVisualStyleBackColor = true;
            this.btnProchainMatch.Click += new System.EventHandler(this.btnProchainMatch_Click);
            // 
            // ViewMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StatFoot.Properties.Resources.footBG;
            this.ClientSize = new System.Drawing.Size(697, 423);
            this.Controls.Add(this.btnProchainMatch);
            this.Controls.Add(this.btnJoueurs);
            this.Controls.Add(this.btnMatch);
            this.Controls.Add(this.btnEquipes);
            this.Controls.Add(this.btnCommencer);
            this.Name = "ViewMenu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCommencer;
        private System.Windows.Forms.Button btnEquipes;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.Button btnJoueurs;
        private System.Windows.Forms.Button btnProchainMatch;
    }
}

