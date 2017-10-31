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
        int valueModifierType;
        double valueModifierAmount;

        public Hero(int h, int d, int s, int mod, double v)
        {
            hp = h; damage = d; SPperLevel = s;
            valueModifierAmount = v; valueModifierType = mod;
        }

        public int getStrength(int level)
        {
            if (level > 0)
            {
                int points = SPperLevel * (level-1);
                int eHP = hp + (int)Math.Round((double)points * hp / (hp + damage), MidpointRounding.AwayFromZero);
                int eDamage = damage + (int)Math.Round((double)points * damage / (hp + damage), MidpointRounding.AwayFromZero);
                int value = (int)Math.Pow(eHP * eDamage, 1.5) - 1000;
                if (valueModifierType == 0)
                    value += (int)valueModifierAmount;
                else
                    value = (int)(value*valueModifierAmount);

                return value;
            }
            else
            {
                return 0;
            }
        }
    }
}
