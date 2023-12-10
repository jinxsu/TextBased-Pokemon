using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_2030854.Classes
{
   public class Trainer
    {
        
        Pokemon target;
        Pokemon currentFighter;
        string name;
        int gp;
        private List<Pokemon> pokemonsCollection;
        private List<Potions> potionsCollection;
        private List<Ball> ballsCollection;
        public Trainer() { }
        public Trainer(string name)
        {
            this.target = null;
            this.currentFighter = null;
            this.name = name;
            this.Gp = 0;
            this.pokemonsCollection = new List<Pokemon>();
            this.potionsCollection = new List<Potions>();
            this.ballsCollection = new List<Ball>();


            //Add items in the collection to be able to start
            Pokemon partner_pikachu = GameFactory.CreatePartnerPikachu();
            PokemonsCollection.Add(partner_pikachu);
            Ball pokeball1 = GameFactory.CreatePokeBall();
            BallsCollection.Add(pokeball1);
            Ball pokeball2 = GameFactory.CreatePokeBall();
            BallsCollection.Add(pokeball2);
            Ball pokeball3 = GameFactory.CreatePokeBall();
            BallsCollection.Add(pokeball3);
            Ball great_ball = GameFactory.CreateGreatBall();
            BallsCollection.Add(great_ball);
            Ball ultra_ball = GameFactory.CreateUltraBall();
            BallsCollection.Add(ultra_ball);
            Ball master_ball = GameFactory.CreateMasterBall();
            BallsCollection.Add(master_ball);
        }


        public List<Pokemon> PokemonsCollection { get => pokemonsCollection; set => pokemonsCollection = value; }
        public List<Potions> PotionsCollection { get => potionsCollection; set => potionsCollection = value; }
        public List<Ball> BallsCollection { get => ballsCollection; set => ballsCollection = value; }
        public Pokemon CurrentFighter { get => currentFighter; set => currentFighter = value; }
        public string Name { get => name; set => name = value; }
        public Pokemon Target { get => target; set => target = value; }
        public int Gp { get => gp; set => gp = value; }

        public override string ToString()
        {
            
            return "\n Trainer's GP: "+this.Gp;
        }

        public void AddPokemon(Pokemon pokemon)
        {
            this.PokemonsCollection.Add(pokemon);
        }
        
        
        public void Reward_GP(int xp)
        {
            Gp += xp;
        }
        public void Buy_Items(Items items)
        {
            if(this.Gp<=items.Price)
            {
                this.Gp -= items.Price;
                if(items is Potions)
                {
                    this.PotionsCollection.Add((Potions)items);
                }
                else if(items is Ball)
                {
                    this.BallsCollection.Add((Ball)items);
                }
            }
            else
            {
                Message.PrintRed("\nYou Don't have enough Gold Point! ");
            }
        }
        public void Pokemon_Nursery()
        {
            foreach (Pokemon element in PokemonsCollection)
            {
                element.Full_Restore();
            }
         
        }


        public Pokemon PickPokemon()
        {
            string menu = "";
            for(int i=0; i<PokemonsCollection.Count;i++)
            {
                menu += "\n "+i + ":" + PokemonsCollection[i].Name + " , " + PokemonsCollection[i].Type + " , " + pokemonsCollection[i].HP;
            }
            Message.PrintBlue("\nlist of Pokemon: ");
            Message.PrintBlue(menu);
            Console.Write("\nEnter your choice: ");
            string input = Console.ReadLine();
            int index = Convert.ToInt32(input);
            Pokemon obj = PokemonsCollection[index];

            Console.WriteLine("\nYou picked: "+obj.Name+" , "+obj.Type+" , "+obj.HP);
            this.currentFighter = obj;
            return currentFighter; 

        }
        public Ball PickBall()
        {
            
            Message.PrintBlue("\nM: Master Ball, count= " +countBall("Master Ball")+ " | U: Ultra Ball, count= "+countBall("Ultra Ball")+" | G: Great Ball, count= "+countBall("Great Ball")+" | P: Poke Ball, count= "+countBall("Poke Ball"));
            Console.Write("\nEnter your choice: ");
            ConsoleKeyInfo input = Console.ReadKey();
            Ball obj=null;
            switch(input.Key)
            {
                case ConsoleKey.M: obj = GetBall("Master Ball");
                    break;
                case ConsoleKey.U: obj = GetBall("Ultra Ball");
                    break;
                case ConsoleKey.G: obj = GetBall("Great Ball");
                    break;
                case ConsoleKey.P: obj = GetBall("Poke Ball");
                    break;
            }
           
            return obj;
        }



        public int countBall(string name)
        {
            int counter = 0;
            foreach(Ball obj in BallsCollection)
            {
                if(string.Compare(obj.Name, name, true)==0)
                {
                    counter++;
                }
            }
            return counter;
        }



        public Ball GetBall(string name)
        {
            
            foreach (Ball obj in BallsCollection)
            {
                if (string.Compare(obj.Name, name, true) == 0)
                {
                    return obj;
                }
            }
            return null;
        }

        public Potions PickPotions(string name)
        {
            Message.PrintBlue("\n 0- Antidote:" +countPotions("ANTIDOTE")+ " | 1-Awakening:" +countPotions("AWAKENING")+ " | 2-Burn Heal:"+countPotions("BURN HEAL") + " | 3-Full Heal:"+countPotions("FULL HEAL") + " | 4-Full Restore:"+countPotions("FULL RESTORE") + " | 5-Ice Heal:" + countPotions("ICE HEAL")+" | 6-Max Potion:" + countPotions("MAX POTION")+" | 7-Paralyze Heal:"+countPotions("PARALYZE HEAL") + " | 8-Revive:" +countPotions("REVIVE")+ " | 9-PP Max:" + countPotions("PP MAX")+" | 10-PP Up:"+ countPotions("PP UP")+ " | 11- Courage Candy:"+countPotions("COURAGE CANDY") + " | 12- Mighty Candy:"+countPotions("MIGHTY CANDY"));
            string input = Console.ReadLine();
            int answer = Convert.ToInt32(input);
            Potions obj = null;
            switch (answer)
            {
                case 0: obj = GetPotions("ANTIDOTE") ;
                    break;
                case 1: obj = GetPotions("AWAKENING");
                    break;
                case 2: obj = GetPotions("BURN HEAL");
                    break;
                case 3: obj = GetPotions("FULL HEAL");
                    break;
                case 4: obj = GetPotions("FULL RESTORE");
                    break;
                case 5: obj = GetPotions("ICE HEAL");
                    break;
                case 6: obj = GetPotions("MAX POTION");
                    break;
                case 7: obj = GetPotions("PARALYZE HEAL");
                    break;
                case 8: obj = GetPotions("REVIVE");
                    break;
                case 9:obj = GetPotions("PP MAX");
                    break;
                case 10:obj = GetPotions("PP UP");
                    break;
                case 11:obj = GetPotions("COURAGE CANDY");
                    break;
                case 12: obj = GetPotions("MIGHTY CANDY");
                    break;
            }
            return obj;
        }

            public int countPotions(string name)
            {
                int counter = 0;
                foreach (Potions obj in PotionsCollection)
                {
                    if (string.Compare(obj.Name, name, true) == 0)
                    {
                        counter++;
                    }
                }
                return counter;
            }
            public Potions GetPotions(string name)
            {

                foreach (Potions obj in PotionsCollection)
                {
                    if (string.Compare(obj.Name, name, true) == 0)
                    {
                        return obj;
                    }
                }
                return null;
            }

            public static Pokemon TrainPokemons(List<Pokemon> pokemons)
            {
            // Get random pokemon
            Pokemon winner_pokemon = null;

                int index1 = RNG.GetInstance().Next(0, pokemons.Count);
                Pokemon pokemon1 = pokemons[index1];
                int index2 = RNG.GetInstance().Next(0, pokemons.Count);
                Pokemon pokemon2 = pokemons[index2];

                while(pokemon1==pokemon2)
                {
                    index2 = RNG.GetInstance().Next(0, pokemons.Count);
                    pokemon2 = pokemons[index2];
                }


                do 
                {
                int random = RNG.GetInstance().Next(0, 3);
                switch(random)
                {
                    case 0:pokemon1.Attack(pokemon2, AttackType.PHYSICAL);
                        break;
                    case 1:pokemon1.Attack(pokemon2, AttackType.SPECIAL);
                        break;
                    default:pokemon1.Attack(pokemon2, AttackType.STATUS);
                        break;
                }
                if(!pokemon2.Is_Fainted())
                {
                    switch (random)
                    {
                        case 0:
                            pokemon1.Attack(pokemon2, AttackType.PHYSICAL);
                            break;
                        case 1:
                            pokemon1.Attack(pokemon2, AttackType.SPECIAL);
                            break;
                        default:
                            pokemon1.Attack(pokemon2, AttackType.STATUS);
                            break;
                    }

                }
                
                } while (!pokemon1.Is_Fainted()&&!pokemon2.Is_Fainted());

             if (pokemon1.Is_Fainted())
             {
                pokemon2.LevelUp();
                pokemon1.Full_Restore();
                pokemon1.Full_Restore();
                winner_pokemon = pokemon2;

             }
             else
             {
                pokemon1.LevelUp();
                pokemon1.Full_Restore();
                pokemon1.Full_Restore();
                winner_pokemon = pokemon1;
             }
            return winner_pokemon;
            }
           // heal both pokemon for the future fight

        
            

   }
}
