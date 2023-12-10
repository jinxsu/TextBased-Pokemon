using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_2030854.Classes
{
    public enum PotionType { ANTIDOTE, AWAKENING, BURN_HEAL, FULL_HEAL, FULL_RESTORE, ICE_HEAL, MAX_POTION, PARALYZE_HEAL, REVIVE, PP_MAX, PP_UP, COURAGE_CANDY, MIGHTY_CANDY }


    public class Potions:Items
    {
        PotionType type;

        public Potions():base()
        {
        }

        public Potions(string name, int price, PotionType type):base(name, price)
        {
            this.type = type;
        }

        public PotionType Type { get => type; set => type = value; }
    }
}
