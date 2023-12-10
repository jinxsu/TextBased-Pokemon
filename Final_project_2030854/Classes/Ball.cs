using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_2030854.Classes
{
     public class Ball:Items
    {
        private double rate;
        private int ball_value;
        private int max_RDN;
        private bool isMaster;
      
        public Ball() : base() { }
        public Ball(string name, int price, double rate, int ball_value, int max_RDN, bool isMaster):base(name, price)
        {
            this.rate = rate;
            this.ball_value = ball_value;
            this.max_RDN = max_RDN;
            this.isMaster = isMaster;
        }

        public double Rate { get => rate; set => rate = value; }
        public int Ball_value { get => ball_value; set => ball_value = value; }
        public int Max_RDN { get => max_RDN; set => max_RDN = value; }
        public bool IsMaster { get => isMaster; set => isMaster = value; }

        public bool Catch(Pokemon pokemon)
        {
           
            int n = RNG.GetInstance().Next(0, max_RDN);
            int Catch_rate = pokemon.Catch_Rate * (int)this.rate;
            int m = RNG.GetInstance().Next(0, 255);
            int f = (pokemon.HP_MAX * 255 * 4) / (pokemon.HP * ball_value);
            //pokemon gets set as null when trying to catch it

            if (isMaster)
            {
                Message.PrintDarkYellow("You caught the pokemon!");
                return true;
            }
            else
            {
                if (pokemon.status == PokemonStatus.ASLEEP ||
                        pokemon.status == PokemonStatus.FROZEN &&
                        n < pokemon.Status_Threshold)
                {
                    Message.PrintDarkYellow("You caught the pokemon!");
                    return true;
                }
                else if (pokemon.status == PokemonStatus.PARALYZED ||
                         pokemon.status == PokemonStatus.BURNED ||
                         pokemon.status == PokemonStatus.POISONED &&
                         n < pokemon.Status_Threshold)
                {
                    Message.PrintDarkYellow("You caught the pokemon!");
                    return true;
                }
                else if (n - pokemon.Status_Threshold > Catch_rate)
                {
                    Message.PrintDarkYellow("The Pokemon broke free!");
                    return false;
                }
                else
                {
                    if (f >= m)
                    {
                        Message.PrintDarkYellow("You caught the pokemon!");
                        return true;
                    }
                    else
                    {
                        Message.PrintDarkYellow("The Pokemon broke free!");
                        return false;
                    }

                }
            }
           
        }
     }
}
