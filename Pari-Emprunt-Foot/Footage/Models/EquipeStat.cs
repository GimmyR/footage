using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Footage.Models {
    public class EquipeStat {

        // ATTRIBUTES :

        private Dictionary<string, object> dico = null;

        // CONSTRUCTOR :

        public EquipeStat() {

            dico = new Dictionary<string, object>();

        }

        // GETTERS AND SETTERS :

        public int Count {

            get { return dico.Count; }

        }

        public bool Exist(string key) {

            bool tof;
            try {
                tof = dico.Keys.Contains(key);
            } catch (Exception ex) {
                throw ex;
            } return tof;

        }

        public void Add(string key, object value) {

            try {
                dico.Add(key, value);
            } catch (Exception ex) {
                throw ex;
            }

        }

        public string[] GetAt(int index) {

            string[] result = new string[2];

            KeyValuePair<string, object> keyValue = dico.ElementAt(index);
            result[0] = keyValue.Key;
            result[1] = keyValue.Value.ToString();

            return result;

        }

        public List<string[]> GetAll() {

            List<string[]> results = new List<string[]>();

            for (int i = 0; i < dico.Count; i++) {

                results.Add(this.GetAt(i));

            } return results;

        }

        public object Get(string key) {

            object result = null;
            try {
                result = dico[key];
            } catch (Exception ex) {
                throw ex;
            } return result;

        }
        
        // METHODS :



    }
}
