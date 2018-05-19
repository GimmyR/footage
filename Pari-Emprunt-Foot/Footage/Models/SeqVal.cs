using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Footage.Models {

    public class SeqVal {

        public static int Update(SqlConnection connexion, string sequence, int valeur) {

            int nbLigne = -1;
            using (SqlCommand cmd = connexion.CreateCommand()) {

                cmd.CommandText = "UPDATE SeqVal SET valeur=" + valeur + " WHERE nom='" + sequence + "'";
                nbLigne = cmd.ExecuteNonQuery();

            } return nbLigne;

        }

        public static int Next(SqlConnection connexion, string sequence) {

            int valeur = 0, next = -1;

            connexion.Open();
            using (SqlCommand cmd = connexion.CreateCommand()) {

                cmd.CommandText = "SELECT valeur FROM SeqVal WHERE nom='" + sequence + "'";
                using (SqlDataReader reader = cmd.ExecuteReader()) {

                    int etape = 1;
                    reader.Read();
                    try {

                        valeur = int.Parse(reader["valeur"].ToString());
                        reader.Close();
                        next = valeur + 1;
                        Update(connexion, sequence, next);
                        etape = 2;

                    } catch (Exception e) {

                        Console.WriteLine(e.GetType() + " : " + e.Message + " :\n" + e.StackTrace + "\n");
                        if (etape == 2) {
                            Update(connexion, sequence, valeur);
                        }

                    }

                }

            } connexion.Close();

            return valeur;

        }

    }

}
