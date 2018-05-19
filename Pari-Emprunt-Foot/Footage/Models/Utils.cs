using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Footage.Models {
    public class Utils {

        // ATTRIBUTES :



        // STATIC METHOD :

        public static int TimeToSeconds(DateTime datetime) {

            int result = 0;

            result = (datetime.Hour * 60 * 60) + (datetime.Minute * 60) + datetime.Second; 

            return result;

        }

    }
}
