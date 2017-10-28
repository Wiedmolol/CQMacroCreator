using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQMacroCreator
{
    class Hero
    {
        int hp;
        int damage;
        int SPperLevel;

        public Hero(int h, int d, int s)
        {
            hp = h; damage = d; SPperLevel = s;
        }

        public int getStrength(int level)
        {
            if (level > 0)
            {
                int points = SPperLevel * (level-1);
                return (hp + (int)Math.Round((double)points * hp / (hp + damage), MidpointRounding.AwayFromZero)) * (damage + (int)Math.Round((double)points * damage / (hp + damage), MidpointRounding.AwayFromZero));
            }
            else
            {
                return 0;
            }
        }
    }
}
