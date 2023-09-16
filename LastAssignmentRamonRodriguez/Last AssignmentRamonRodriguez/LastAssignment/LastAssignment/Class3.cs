using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastAssignment
{
    class DCHeroes: CaracterAttributes
    {
        private string batmanName = "Batman";
        private string supermanName = "Superman";

        public string BatmanName
        {
            get { return batmanName; }
            set { batmanName = value; }
        }

        public string SupermanName
        {
            get { return supermanName; }
            set { supermanName = value; }
        }
    }
}
