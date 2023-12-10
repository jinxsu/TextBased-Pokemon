using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Final_project_2030854.Classes
{
     public class GameManager
    {
        private static string data_file = "TrainersData.xml";
        public static List<Trainer> ListTrainers = new List<Trainer>();
        public static Trainer CurrentTrainer;
        public static bool quit = false;

        public static void StartGame(string name)
        {

            try
            {
                ListTrainers = DataXML.Load(data_file);

            }
            catch (IOException exception)
            {
                Message.PrintRed("Warning: " + exception.Message);
            }

            
            Trainer obj= FindTrainers(name);
            if(obj!=null)
            {
                CurrentTrainer = obj;
            }
            else
            {
                CurrentTrainer = new Trainer(name);
                ListTrainers.Add(CurrentTrainer);
            }
        }

        private static Trainer FindTrainers(string name)
        {
            foreach (Trainer obj in ListTrainers)
            {
                if (obj.Name.ToLower() == name.ToLower())
                {
                    return obj;
                    
                }

            }
            return null;
        }

        public static void SaveGame()
        {
            DataXML.Save(data_file, ListTrainers);
        }

        public static void Explore()
        {
            int random = RNG.GetInstance().Next(0, 10);
            switch(random)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    CurrentTrainer.PickPokemon();
                    Pokemon wild_pokemon = GameFactory.Get_Random_Pokemon();
                    wild_pokemon.Target = CurrentTrainer.CurrentFighter;
                    CurrentTrainer.CurrentFighter.Target = wild_pokemon;
                    Console.WriteLine("\n a wild "+wild_pokemon.Name+" is approaching, get ready to fight! ");
                    
                    Battle();
                    break;
                case 4:
                case 5:
                case 6:
                    int random_gp = RNG.GetInstance().Next(50, 500);
                    CurrentTrainer.Gp += random_gp;
                    Console.WriteLine("\nYou collected "+random_gp+" Gold Pieces! ");
                    break;
                case 7:
                    Console.WriteLine("\nYou are going to the Pokemon Nursery!");
                    CurrentTrainer.Pokemon_Nursery();
                    break;
                default:
                    Console.WriteLine("\n you are looking around for Gold Pieces");
                    break;

            }
        }

        public static void Battle()
        {
            Pokemon wild_pokemon = CurrentTrainer.CurrentFighter.Target;
            Pokemon current_pokemon = CurrentTrainer.CurrentFighter;
            do
            {
                Console.WriteLine("\nYou are trying to catch " + wild_pokemon.Name);
                Message.PrintDarkYellow("\nBattle Menu: A = Attack | B = Bag | R = Run | S = Switch Pokemon");
                ConsoleKeyInfo choice = Console.ReadKey();
                switch (choice.Key)
                {
                    case ConsoleKey.A:
                        Fight(wild_pokemon, current_pokemon);
                        break;
                    case ConsoleKey.B:
                        Message.PrintBlue("\nBall Collection: Master Ball: " + CurrentTrainer.countBall("Master Ball")+" Ultra Ball : "+CurrentTrainer.countBall("Ultra Ball")+" Great Ball : "+CurrentTrainer.countBall("Great Ball")+"Poke Ball : "+CurrentTrainer.countBall("Poke Ball"));
                        Message.PrintBlue("\nPotion Collection: Antidote:" +CurrentTrainer.countPotions("ANTIDOTE")+ " | 1 - Awakening:" +CurrentTrainer.countPotions("AWAKENING")+ " | 2 - Burn Heal: "+CurrentTrainer.countPotions("BURN HEAL") + " | 3 - Full Heal: "+CurrentTrainer.countPotions("FULL HEAL") + " | 4 - Full Restore: "+CurrentTrainer.countPotions("FULL RESTORE") + " | 5 - Ice Heal: " + CurrentTrainer.countPotions("ICE HEAL")+" | 6 - Max Potion: " + CurrentTrainer.countPotions("MAX POTION")+" | 7 - Paralyze Heal: "+CurrentTrainer.countPotions("PARALYZE HEAL") + " | 8 - Revive:" +CurrentTrainer.countPotions("REVIVE")+ " | 9 - PP Max: " + CurrentTrainer.countPotions("PP MAX")+" | 10 - PP Up: "+ CurrentTrainer.countPotions("PP UP")+ " | 11 - Courage Candy: "+CurrentTrainer.countPotions("COURAGE CANDY") + " | 12 - Mighty Candy: "+CurrentTrainer.countPotions("MIGHTY CANDY"));
                        break;
                    case ConsoleKey.R:
                        Message.PrintDarkGreen("\nYou Ran away !");
                        CurrentTrainer.CurrentFighter.Target = null;
                       
                        break;
                    case ConsoleKey.S: current_pokemon=CurrentTrainer.PickPokemon();
                        break;

                }
            } while (!(current_pokemon.Is_Fainted() || wild_pokemon.Is_Fainted()|| current_pokemon.Target==null));
        }

        private static Pokemon Fight(Pokemon wild_pokemon, Pokemon current_pokemon)
        {
            Message.PrintMagenta("\nInput your type of attack: \nS-Special Attack \n P- Physical Attack\n T- Status Attack ");
            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.S:
                    current_pokemon.Attack(wild_pokemon, AttackType.SPECIAL);
                    break;
                case ConsoleKey.P:
                    current_pokemon.Attack(wild_pokemon, AttackType.PHYSICAL);
                    break;
                case ConsoleKey.T:
                    current_pokemon.Attack(wild_pokemon, AttackType.STATUS);
                    break;
                default:
                    Message.PrintRed("\nWrong Command");
                    break;

                    
            }
            if (!wild_pokemon.Is_Fainted())
            {
                int random = RNG.GetInstance().Next(0, 3);
                switch (random)
                {
                    case 0:
                        wild_pokemon.Attack(current_pokemon, AttackType.PHYSICAL);
                        break;

                    case 1:

                        wild_pokemon.Attack(current_pokemon, AttackType.SPECIAL);
                        break;


                    default:
                        wild_pokemon.Attack(current_pokemon, AttackType.STATUS);
                        break;
                }
                if(wild_pokemon.HP<=wild_pokemon.HP_MAX)
                {
                    
                    Ball obj = GameManager.CurrentTrainer.PickBall();

                    if (obj != null)
                    {
                        bool caught = obj.Catch(GameManager.CurrentTrainer.CurrentFighter.Target);
                        if (caught)
                        {
                            GameManager.CurrentTrainer.CurrentFighter.Target.Full_Restore();
                            GameManager.CurrentTrainer.AddPokemon(GameManager.CurrentTrainer.CurrentFighter.Target);
                            GameManager.CurrentTrainer.CurrentFighter.Target = null;
                            GameManager.Explore();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't own this ball! ");
                    }
                }

            }
            if (wild_pokemon.Is_Fainted())
            {
                CurrentTrainer.Gp += wild_pokemon.Base_Exp;
               
            }
            else if (current_pokemon.Is_Fainted())
            {
                Message.PrintBlue("\nYour Pokemon is dead !");
                Message.PrintDarkGreen("\nDo you want to revive your Pokemon? \nY-yes\nN-no");
                string answer = Console.ReadLine();


                if (answer == "Y" || answer == "y")
                {
                    current_pokemon.ApplyPotion(PotionType.REVIVE);
                }
                else if (answer == "N" || answer == "n")
                {
                    current_pokemon = CurrentTrainer.PickPokemon();
                }

            }

            return current_pokemon;
        }




    }
       
    
}
