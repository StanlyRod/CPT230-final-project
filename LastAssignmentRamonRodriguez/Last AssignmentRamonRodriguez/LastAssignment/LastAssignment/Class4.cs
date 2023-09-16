using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastAssignment
{
    class DCVillains:CaracterAttributes
    {
        private string jokerName = "Joker";
        private string luthorName = "Luthor";

        public string JokerName
        {
            get { return jokerName; }
            set { jokerName = value; }
        }

        public string LuthorName
        {
            get { return luthorName; }
            set { luthorName = value; }
        }
    }
}
