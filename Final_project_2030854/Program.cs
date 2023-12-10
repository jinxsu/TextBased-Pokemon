using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Final_project_2030854.Classes;

namespace Final_project_2030854
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input your name: ");
            string name = Console.ReadLine();

            GameManager.StartGame(name);
            ConsoleKeyInfo input;
            
            do
            {
                Message.PrintDarkGreen(GameManager.CurrentTrainer.ToString() + "\n");
                Message.PrintDarkGreen("Main Menu: E = Explore | S= Store | Q = Quit");
                string menu = "";
                for (int i = 0; i < GameManager.CurrentTrainer.PokemonsCollection.Count; i++)
                {
                    menu += " \n"+ i + ":" + GameManager.CurrentTrainer.PokemonsCollection[i].Name + " , " + GameManager.CurrentTrainer.PokemonsCollection[i].Type + " , " + GameManager.CurrentTrainer.PokemonsCollection[i].HP;
                }
                Message.PrintBlue("\nlist of Pokemon: ");
                Message.PrintBlue(menu);

                input = Console.ReadKey();
                Execute_Command(input.Key);

            } while (!GameManager.quit);
            

            GameManager.SaveGame();

            Console.ReadKey();
        }

        static void Execute_Command(ConsoleKey Key)
        {
            switch(Key)
            {

                case ConsoleKey.E:
                    GameManager.Explore();
                    break;
                case ConsoleKey.S:
                    BuyItems();
                    break;
                
                case ConsoleKey.Q: Quit();
                    break;
                default: Message.PrintRed("\n Wrong command! ");
                    break;
                    
            }
        }

        private static void Quit()
        {
            GameManager.quit = true;
            if(GameManager.CurrentTrainer.CurrentFighter.Target == null)
            {
                Message.PrintRed("\n You quit the game, Goodbye");
                return;
            }
            else
            {
                Message.PrintRed("\n You cannot quit the game while in battle! ");
            }
        }

        private static void BuyItems()
        {
            Console.WriteLine("What do you want to buy? \n1- potions\n2- ball");
            string input = Console.ReadLine();
            int answer = Convert.ToInt32(input);
            switch(answer)
            {
                case 1: BuyPotion();
                    break;
                case 2: BuyBall();
                    break;
                default: Console.WriteLine("\n Wrong Command!");
                    break;
            }
        }

        private static void BuyPotion()
        {
            Potions antidote = GameFactory.CreateAntidote();
            Potions awakening = GameFactory.CreateAwakening();
            Potions burnheal = GameFactory.CreateBurnHeal();
            Potions fullheal = GameFactory.CreateFullHeal();
            Potions fullrestore = GameFactory.CreateFullRestore();
            Potions iceheal = GameFactory.CreateIceHeal();
            Potions maxpotion = GameFactory.CreateMaxPotion();
            Potions paralyzeheal = GameFactory.CreateParalyzeHeal();
            Potions revive = GameFactory.CreateRevive();
            Potions ppup = GameFactory.CreatePpUp();
            Potions ppmax= GameFactory.CreatePpMax();
            Potions couragecandy = GameFactory.CreateCourageCandy();
            Potions mightycandy = GameFactory.CreateMightyCandy();
            Message.PrintBlue("\n Buy Potions : 0-" + antidote.ToString() + " | 1-" + awakening.ToString() + " | 2-" 
                + burnheal.ToString() + " | 3-" + fullheal.ToString() + " | 4-" + fullrestore.ToString() + " | 5-" 
                + iceheal.ToString() + " | 6-" + maxpotion.ToString() + " | 7-" + paralyzeheal.ToString() + " | 8-" 
                + revive.ToString() + " | 9-" + ppmax.ToString() + " | 10-" + ppup.ToString() + " | 11-" + couragecandy.ToString() + " | 12-" + mightycandy.ToString());
            
            Console.WriteLine(" Enter your choice: ");
            string input = Console.ReadLine();
            int answer = Convert.ToInt32(input);
            switch(answer)
            {
                case 0:GameManager.CurrentTrainer.Buy_Items(antidote);
                    break;
                case 1:GameManager.CurrentTrainer.Buy_Items(awakening);
                    break;
                case 2:GameManager.CurrentTrainer.Buy_Items(burnheal);
                    break;
                case 3:GameManager.CurrentTrainer.Buy_Items(fullheal);
                    break;
                case 4:GameManager.CurrentTrainer.Buy_Items(fullrestore);
                    break;
                case 5:GameManager.CurrentTrainer.Buy_Items(iceheal);
                    break;
                case 6:GameManager.CurrentTrainer.Buy_Items(maxpotion);
                    break;
                case 7:GameManager.CurrentTrainer.Buy_Items(paralyzeheal);
                    break;
                case 8:GameManager.CurrentTrainer.Buy_Items(revive);
                    break;
                case 9:GameManager.CurrentTrainer.Buy_Items(ppmax);
                    break;
                case 10:GameManager.CurrentTrainer.Buy_Items(ppup);
                    break;
                case 11:GameManager.CurrentTrainer.Buy_Items(couragecandy);
                    break;
                case 12:GameManager.CurrentTrainer.Buy_Items(mightycandy);
                    break;
                default:
                    Message.PrintRed("\n Wrong Command!");
                    break;
            }
        }

        private static void BuyBall()
        {
            Ball pokeball = GameFactory.CreatePokeBall();
            Ball greatball = GameFactory.CreateGreatBall();
            Ball ultraball = GameFactory.CreateUltraBall();
            Message.PrintBlue("\n Buy Ball : P = " + pokeball.ToString() + " | G = " + greatball.ToString() + " | U = " + ultraball.ToString());
            Console.WriteLine(" Enter your choice: ");
            ConsoleKeyInfo input = Console.ReadKey();
            switch(input.Key)
            {
                case ConsoleKey.P:GameManager.CurrentTrainer.Buy_Items(pokeball);
                    break;
                case ConsoleKey.G:GameManager.CurrentTrainer.Buy_Items(greatball);
                    break;
                case ConsoleKey.U:GameManager.CurrentTrainer.Buy_Items(ultraball);
                    break;
                default: Message.PrintRed("\n Wrong Command!");
                    break;
            }
        }
    }
}
