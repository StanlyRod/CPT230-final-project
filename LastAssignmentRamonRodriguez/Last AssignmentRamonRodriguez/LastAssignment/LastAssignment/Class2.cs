using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastAssignment
{
    class CaracterAttributes
    {
        //power level for the heores and villains
        private string powerLevel = "100";

        public string PowerLevel
        {
            get { return powerLevel; }
            set { PowerLevel = value; }
        }

        public int Attack(int min, int max)
        {
            Random random = new Random();
            int damage = random.Next(min, max);
            return damage;
        }
    }
}
