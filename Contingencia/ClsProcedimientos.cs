using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contingencia
{
    public class ClsProcedimientos
    {
        public ClsProcedimientos(string plow) {
            sign = "I";
            option = "EQ";
            low = plow;
        }

        private string sign;

        public string Sign
        {
            get { return sign; }
            set { sign = value; }
        }
        private string option;

        public string Option
        {
            get { return option; }
            set { option = value; }
        }
        private string low;

        public string Low
        {
            get { return low; }
            set { low = value; }
        }
    }
}
