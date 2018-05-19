using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using View;

namespace StatFoot {

    static class Program {

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main() {

            try {

                System.Data.SqlClient.SqlConnection connexion = Model.Connexion.Get("Server=localhost;Database=foot;User ID=sa;Password=itu;");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ViewMenu(connexion));

            } catch (Exception ex) {

                System.Windows.Forms.MessageBox.Show(ex.Message);
                //System.Windows.Forms.MessageBox.Show(ex.StackTrace);

            }

        }

    }

}
