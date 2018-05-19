using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footage.Models.Json {

    public class Res {

        public bool error;
        public String message;
        public Object data;

        public Res(bool error, String message, Object data) {

            this.error = error;
            this.message = message;
            this.data = data;

        }

    }

}