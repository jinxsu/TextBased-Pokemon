﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_2030854.Classes
{
     public class GameFactory
     {
        public static readonly List<Pokemon> PokemonInWorld = new List<Pokemon>();
        public static readonly List<Potions> PotionsInventory = new List<Potions>();
        public static readonly List<Ball> BallsInventory = new List<Ball>();

        static GameFactory()
        {
            Create_Wild_Pokemons();
        }
        public static Pokemon Get_Random_Pokemon()
        {
            int index = RNG.GetInstance().Next(0, PokemonInWorld.Count);
            return PokemonInWorld[index].Clone();//return a clone of a random obj
        }
        public static Pokemon CreatePartnerPikachu()
        {
            Pokemon partner = new Pokemon(name: "Partner Pikachu", type: PokemonType.ELECTRIC, hp: 45, atk: 80, def: 50, sp_Def: 75, sp_Atk: 60, speed: 120, catch_Rate: 190, base_Exp: 112);
            partner.myMove = new Move("Thunder Wave", 90, 20);
            return partner;
        }

        public static Ball CreatePokeBall()
        {
            return new Ball(name: "Poke Ball", price: 100, rate: 1, ball_value: 12, max_RDN: 255, false);
        }
        public static Ball CreateGreatBall()
        {
            return new Ball(name: "Great Ball", price: 300, rate: 1.5, ball_value: 8, max_RDN: 200, false);
        }
        public static Ball CreateUltraBall()
        {
            return new Ball(name: "Ultra Ball", price: 600, rate: 2, ball_value: 12, max_RDN: 150, false);
        }
        public static Ball CreateMasterBall()
        {
            return new Ball(name: "MASTER BALL", price: 1000000, rate: 0, ball_value: 0, max_RDN: 0, isMaster: true);
        }
        public static void Create_Balls()
        {
            BallsInventory.Add(new Ball(name: "Poke Ball", price: 100, rate: 1, ball_value: 12, max_RDN: 255, false));
            BallsInventory.Add(new Ball(name: "Great Ball", price: 300, rate: 1.5, ball_value: 8, max_RDN: 200, false));
            BallsInventory.Add(new Ball(name: "Ultra Ball", price: 600, rate: 2, ball_value: 12, max_RDN: 150, false));
        }
        public static Potions CreateAntidote()
        {
            return new Potions(name: "ANTIDOTE", price: 200, type: PotionType.ANTIDOTE);
        }
        public static Potions CreateAwakening()
        {
            return new Potions(name: "AWAKENING", price: 200, type: PotionType.AWAKENING);
        }
        public static Potions CreateBurnHeal()
        {
            return new Potions(name: "BURN HEAL", price: 200, type: PotionType.BURN_HEAL);
        }
        public static Potions CreateFullHeal()
        {
            return new Potions(name: "FULL HEAL", price: 450, type: PotionType.FULL_HEAL);
        }
        public static Potions CreateFullRestore()
        {
            return new Potions(name: "FULL RESTORE", price: 1250, type: PotionType.FULL_RESTORE);
        }
        public static Potions CreateIceHeal()
        {
            return new Potions(name: "ICE HEAL", price: 200, type: PotionType.ICE_HEAL);
        }
        public static Potions CreateMaxPotion()
        {
            return new Potions(name: "MAX POTION", price: 800, type: PotionType.MAX_POTION);
        }
        public static Potions CreateParalyzeHeal()
        {
            return new Potions(name: "PARALYZE HEAL", price: 200, type: PotionType.PARALYZE_HEAL);
        }
        public static Potions CreateRevive()
        {
            return new Potions(name: "REVIVE", price: 300, type: PotionType.REVIVE);
        }
        public static Potions CreatePpMax()
        {
            return new Potions(name: "PP MAX", price: 2500, type: PotionType.PP_MAX);
        }
        public static Potions CreatePpUp()
        {
            return new Potions(name: "PP MAX", price: 2500, type: PotionType.PP_MAX);
        }
        public static Potions CreateCourageCandy()
        {
            return new Potions(name: "COURAGE CANDY", price: 2000, type: PotionType.COURAGE_CANDY);
        }
        public static Potions CreateMightyCandy()
        {
            return new Potions(name: "MIGHTY CANDY", price: 2000, type: PotionType.MIGHTY_CANDY);
        }
        public static void Create_Items()
        {
            PotionsInventory.Add(new Potions(name: "ANTIDOTE", price: 200, type: PotionType.ANTIDOTE));
            PotionsInventory.Add(new Potions(name: "AWAKENING", price: 200, type: PotionType.AWAKENING));
            PotionsInventory.Add(new Potions(name: "BURN HEAL", price: 200, type: PotionType.BURN_HEAL));
            PotionsInventory.Add(new Potions(name: "FULL HEAL", price: 450, type: PotionType.FULL_HEAL));
            PotionsInventory.Add(new Potions(name: "FULL RESTORE", price: 1250, type: PotionType.FULL_RESTORE));
            PotionsInventory.Add(new Potions(name: "ICE HEAL", price: 200, type: PotionType.ICE_HEAL));
            PotionsInventory.Add(new Potions(name: "MAX POTION", price: 800, type: PotionType.MAX_POTION));
            PotionsInventory.Add(new Potions(name: "PARALYZE HEAL", price: 200, type: PotionType.PARALYZE_HEAL));
            PotionsInventory.Add(new Potions(name: "REVIVE", price: 300, type: PotionType.REVIVE));
            PotionsInventory.Add(new Potions(name: "PP MAX", price: 2500, type: PotionType.PP_MAX));
            PotionsInventory.Add(new Potions(name: "PP UP", price: 2500, type: PotionType.PP_UP));
            PotionsInventory.Add(new Potions(name: "COURAGE CANDY", price: 2000, type: PotionType.COURAGE_CANDY));
            PotionsInventory.Add(new Potions(name: "MIGHTY CANDY", price: 2000, type: PotionType.MIGHTY_CANDY));
        }

        //Data Source: https://pokemondb.net/pokedex/all

        private static void Create_Wild_Pokemons()
        {
            Pokemon wildPokemon = new Pokemon(name: "Pikachu", type: PokemonType.ELECTRIC, hp: 35, atk: 55, def: 40, sp_Def: 50, sp_Atk: 50, speed: 90, catch_Rate: 190, base_Exp: 112);
            wildPokemon.myMove = new Move("Thunder Wave", accuracy: 15, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Pichu", type: PokemonType.ELECTRIC, hp: 20, atk: 40, def: 15, sp_Atk: 35, sp_Def: 35, speed: 60, catch_Rate: 190, base_Exp: 41);
            wildPokemon.myMove = new Move("Thunder Wave", accuracy: 10, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Mareep", type: PokemonType.ELECTRIC, hp: 55, atk: 40, def: 40, sp_Atk: 65, sp_Def: 45, speed: 35, catch_Rate: 235, base_Exp: 56);
            wildPokemon.myMove = new Move("Thunder Wave", accuracy: 25, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Ampharos", type: PokemonType.ELECTRIC, hp: 90, atk: 75, def: 85, sp_Atk: 115, sp_Def: 90, speed: 55, catch_Rate: 45, base_Exp: 230);
            wildPokemon.myMove = new Move("Thunder Wave", accuracy: 45, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Blitzle", type: PokemonType.ELECTRIC, hp: 45, atk: 60, def: 32, sp_Atk: 50, sp_Def: 32, speed: 76, catch_Rate: 190, base_Exp: 59);
            wildPokemon.myMove = new Move("Thunder Wave", accuracy: 20, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Eelektrik", type: PokemonType.ELECTRIC, hp: 65, atk: 85, def: 70, sp_Atk: 75, sp_Def: 70, speed: 40, catch_Rate: 60, base_Exp: 142);
            wildPokemon.myMove = new Move("Thunder Wave", accuracy: 30, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Stunfisk", type: PokemonType.ELECTRIC, hp: 109, atk: 66, def: 84, sp_Atk: 81, sp_Def: 99, speed: 32, catch_Rate: 75, base_Exp: 165);
            wildPokemon.myMove = new Move("Thunder Wave", accuracy: 50, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Helioptile", type: PokemonType.ELECTRIC, hp: 44, atk: 38, def: 33, sp_Atk: 61, sp_Def: 43, speed: 70, catch_Rate: 190, base_Exp: 58);
            wildPokemon.myMove = new Move("Thunder Wave", accuracy: 20, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Voltorb", type: PokemonType.ELECTRIC, hp: 40, atk: 30, def: 50, sp_Atk: 55, sp_Def: 55, speed: 100, catch_Rate: 190, base_Exp: 66);
            wildPokemon.myMove = new Move("Thunder Wave", accuracy: 20, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Electrode", type: PokemonType.ELECTRIC, hp: 60, atk: 50, def: 70, sp_Atk: 80, sp_Def: 80, speed: 150, catch_Rate: 60, base_Exp: 172);
            wildPokemon.myMove = new Move("Thunder Wave", accuracy: 30, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            //10 FIRE-------------------------------------------------------------------------------------------------------------------------------------------------------
            wildPokemon = new Pokemon(name: "Charmander", type: PokemonType.FIRE, hp: 39, atk: 52, def: 43, sp_Def: 50, sp_Atk: 60, speed: 65, catch_Rate: 45, base_Exp: 62);
            wildPokemon.myMove = new Move("Flamethrower", accuracy: 15, pp: 15);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Slugma", type: PokemonType.FIRE, hp: 40, atk: 40, def: 40, sp_Atk: 70, sp_Def: 40, speed: 20, catch_Rate: 190, base_Exp: 50);
            wildPokemon.myMove = new Move("Flamethrower", accuracy: 20, pp: 15);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Magby", type: PokemonType.FIRE, hp: 45, atk: 75, def: 37, sp_Atk: 70, sp_Def: 55, speed: 83, catch_Rate: 45, base_Exp: 73);
            wildPokemon.myMove = new Move("Lava Plume", accuracy: 25, pp: 5);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Torchic", type: PokemonType.FIRE, hp: 45, atk: 60, def: 40, sp_Atk: 70, sp_Def: 50, speed: 45, catch_Rate: 45, base_Exp: 62);
            wildPokemon.myMove = new Move("Flare Blitz", accuracy: 20, pp: 15);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Flareon", type: PokemonType.FIRE, hp: 65, atk: 130, def: 60, sp_Atk: 95, sp_Def: 110, speed: 65, catch_Rate: 45, base_Exp: 184);
            wildPokemon.myMove = new Move("Fire Fang", accuracy: 30, pp: 15);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Cyndaquil", type: PokemonType.FIRE, hp: 39, atk: 52, def: 43, sp_Atk: 60, sp_Def: 50, speed: 65, catch_Rate: 45, base_Exp: 62);
            wildPokemon.myMove = new Move("Flame Wheel", accuracy: 15, pp: 25);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Camerupt", type: PokemonType.FIRE, hp: 70, atk: 100, def: 70, sp_Atk: 105, sp_Def: 75, speed: 40, catch_Rate: 150, base_Exp: 161);
            wildPokemon.myMove = new Move("Eruption ", accuracy: 35, pp: 5);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Torkoal", type: PokemonType.FIRE, hp: 70, atk: 85, def: 140, sp_Atk: 85, sp_Def: 70, speed: 20, catch_Rate: 90, base_Exp: 165);
            wildPokemon.myMove = new Move("Heat Wave ", accuracy: 35, pp: 10);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Chimchar", type: PokemonType.FIRE, hp: 44, atk: 58, def: 44, sp_Atk: 58, sp_Def: 44, speed: 61, catch_Rate: 45, base_Exp: 62);
            wildPokemon.myMove = new Move("Fire Spin", accuracy: 20, pp: 15);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Tepig", type: PokemonType.FIRE, hp: 65, atk: 63, def: 45, sp_Atk: 45, sp_Def: 45, speed: 45, catch_Rate: 45, base_Exp: 62);
            wildPokemon.myMove = new Move("Heat Crash", accuracy: 35, pp: 10);
            PokemonInWorld.Add(wildPokemon);

            //10 WATER-------------------------------------------------------------------------------------------------------------------------------------------------------
            wildPokemon = new Pokemon(name: "Squirtle", type: PokemonType.WATER, hp: 44, atk: 48, def: 65, sp_Atk: 50, sp_Def: 64, speed: 43, catch_Rate: 45, base_Exp: 63);
            wildPokemon.myMove = new Move("Water Gun", accuracy: 20, pp: 15);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Totodile", type: PokemonType.WATER, hp: 50, atk: 65, def: 64, sp_Atk: 44, sp_Def: 48, speed: 43, catch_Rate: 45, base_Exp: 63);
            wildPokemon.myMove = new Move("Hydro Pump", accuracy: 25, pp: 5);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Politoed", type: PokemonType.WATER, hp: 90, atk: 75, def: 75, sp_Atk: 90, sp_Def: 100, speed: 70, catch_Rate: 45, base_Exp: 225);
            wildPokemon.myMove = new Move("Rain Dance", accuracy: 50, pp: 5);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Remoraid", type: PokemonType.WATER, hp: 35, atk: 65, def: 35, sp_Atk: 65, sp_Def: 35, speed: 65, catch_Rate: 190, base_Exp: 60);
            wildPokemon.myMove = new Move("Rain Dance", accuracy: 50, pp: 5);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Magikarp", type: PokemonType.WATER, hp: 20, atk: 10, def: 55, sp_Atk: 15, sp_Def: 20, speed: 80, catch_Rate: 255, base_Exp: 40);
            wildPokemon.myMove = new Move("Whirlpool", accuracy: 10, pp: 15);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Wooper", type: PokemonType.WATER, hp: 55, atk: 45, def: 45, sp_Atk: 25, sp_Def: 25, speed: 15, catch_Rate: 255, base_Exp: 42);
            wildPokemon.myMove = new Move("Water Gun", accuracy: 40, pp: 25);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Wailmer", type: PokemonType.WATER, hp: 130, atk: 70, def: 35, sp_Atk: 70, sp_Def: 35, speed: 60, catch_Rate: 125, base_Exp: 80);
            wildPokemon.myMove = new Move("Muddy Water", accuracy: 70, pp: 10);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Surskit", type: PokemonType.WATER, hp: 40, atk: 30, def: 32, sp_Atk: 50, sp_Def: 52, speed: 65, catch_Rate: 200, base_Exp: 54);
            wildPokemon.myMove = new Move("Muddy Water", accuracy: 30, pp: 10);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Sharpedo", type: PokemonType.WATER, hp: 70, atk: 120, def: 40, sp_Atk: 95, sp_Def: 40, speed: 95, catch_Rate: 60, base_Exp: 161);
            wildPokemon.myMove = new Move("Waterfall", accuracy: 90, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Piplup", type: PokemonType.WATER, hp: 53, atk: 51, def: 53, sp_Atk: 61, sp_Def: 56, speed: 40, catch_Rate: 45, base_Exp: 63);
            wildPokemon.myMove = new Move("Hydro Pump", accuracy: 50, pp: 15);
            PokemonInWorld.Add(wildPokemon);

            //10 GRASS-------------------------------------------------------------------------------------------------------------------------------------------------------
            wildPokemon = new Pokemon(name: "Bulbasaur", type: PokemonType.GRASS, hp: 45, atk: 49, def: 49, sp_Def: 65, sp_Atk: 65, speed: 45, catch_Rate: 45, base_Exp: 64);
            wildPokemon.myMove = new Move("Sleep Powder", accuracy: 50, pp: 15);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Chikorita", type: PokemonType.GRASS, hp: 45, atk: 49, def: 65, sp_Atk: 49, sp_Def: 65, speed: 45, catch_Rate: 45, base_Exp: 64);
            wildPokemon.myMove = new Move("Grass Whistle", accuracy: 50, pp: 25);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Bellossom", type: PokemonType.GRASS, hp: 75, atk: 80, def: 95, sp_Atk: 90, sp_Def: 100, speed: 50, catch_Rate: 45, base_Exp: 221);
            wildPokemon.myMove = new Move("Stun Spore", accuracy: 80, pp: 30);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Sunkern", type: PokemonType.GRASS, hp: 30, atk: 30, def: 30, sp_Atk: 30, sp_Def: 30, speed: 30, catch_Rate: 235, base_Exp: 36);
            wildPokemon.myMove = new Move("Grass Whistle", accuracy: 30, pp: 25);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Sunflora", type: PokemonType.GRASS, hp: 75, atk: 75, def: 55, sp_Atk: 105, sp_Def: 85, speed: 30, catch_Rate: 120, base_Exp: 149);
            wildPokemon.myMove = new Move("Sleep Powder", accuracy: 75, pp: 10);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Treecko", type: PokemonType.GRASS, hp: 40, atk: 45, def: 35, sp_Atk: 65, sp_Def: 55, speed: 70, catch_Rate: 45, base_Exp: 62);
            wildPokemon.myMove = new Move("Leaf Storm", accuracy: 45, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Grovyle", type: PokemonType.GRASS, hp: 50, atk: 65, def: 45, sp_Atk: 85, sp_Def: 65, speed: 95, catch_Rate: 45, base_Exp: 142);
            wildPokemon.myMove = new Move("Grassy Terrain", accuracy: 65, pp: 25);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Tangela", type: PokemonType.GRASS, hp: 65, atk: 55, def: 115, sp_Atk: 100, sp_Def: 40, speed: 60, catch_Rate: 45, base_Exp: 87);
            wildPokemon.myMove = new Move("Stun Spore", accuracy: 55, pp: 30);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Snivy", type: PokemonType.GRASS, hp: 45, atk: 45, def: 55, sp_Atk: 45, sp_Def: 55, speed: 63, catch_Rate: 45, base_Exp: 62);
            wildPokemon.myMove = new Move("Magical Leaf", accuracy: 45, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Breloom", type: PokemonType.GRASS, hp: 60, atk: 130, def: 80, sp_Atk: 60, sp_Def: 60, speed: 70, catch_Rate: 90, base_Exp: 161);
            wildPokemon.myMove = new Move("Seed Bomb", accuracy: 85, pp: 5);
            PokemonInWorld.Add(wildPokemon);

            //10 POISON-------------------------------------------------------------------------------------------------------------------------------------------------------
            wildPokemon = new Pokemon(name: "Ekans", type: PokemonType.POISON, hp: 35, atk: 60, def: 44, sp_Atk: 40, sp_Def: 54, speed: 55, catch_Rate: 255, base_Exp: 58);
            wildPokemon.myMove = new Move("Poison Sting", accuracy: 60, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Crobat", type: PokemonType.POISON, hp: 85, atk: 90, def: 80, sp_Atk: 70, sp_Def: 80, speed: 130, catch_Rate: 90, base_Exp: 241);
            wildPokemon.myMove = new Move("Cross Poison", accuracy: 50, pp: 25);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Qwilfish", type: PokemonType.POISON, hp: 65, atk: 95, def: 85, sp_Atk: 55, sp_Def: 55, speed: 85, catch_Rate: 45, base_Exp: 88);
            wildPokemon.myMove = new Move("Toxic Spikes", accuracy: 70, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Koffing", type: PokemonType.POISON, hp: 40, atk: 65, def: 95, sp_Atk: 60, sp_Def: 45, speed: 35, catch_Rate: 190, base_Exp: 68);
            wildPokemon.myMove = new Move("Poison Gas", accuracy: 65, pp: 40);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Bellsprout", type: PokemonType.POISON, hp: 50, atk: 75, def: 35, sp_Atk: 70, sp_Def: 30, speed: 40, catch_Rate: 255, base_Exp: 60);
            wildPokemon.myMove = new Move("Poison Powder", accuracy: 75, pp: 35);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Weepinbell", type: PokemonType.POISON, hp: 65, atk: 90, def: 50, sp_Atk: 85, sp_Def: 45, speed: 55, catch_Rate: 120, base_Exp: 137);
            wildPokemon.myMove = new Move("Poison Powder", accuracy: 75, pp: 35);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Tentacool", type: PokemonType.POISON, hp: 40, atk: 40, def: 50, sp_Atk: 50, sp_Def: 100, speed: 70, catch_Rate: 190, base_Exp: 67);
            wildPokemon.myMove = new Move("Acid Armor", accuracy: 40, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Grimer", type: PokemonType.POISON, hp: 80, atk: 80, def: 50, sp_Atk: 40, sp_Def: 50, speed: 25, catch_Rate: 190, base_Exp: 65);
            wildPokemon.myMove = new Move("Toxic", accuracy: 80, pp: 10);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Spinarak", type: PokemonType.POISON, hp: 40, atk: 60, def: 40, sp_Atk: 40, sp_Def: 40, speed: 30, catch_Rate: 255, base_Exp: 50);
            wildPokemon.myMove = new Move("Toxic Thread", accuracy: 60, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Dustox", type: PokemonType.POISON, hp: 60, atk: 50, def: 70, sp_Atk: 50, sp_Def: 90, speed: 65, catch_Rate: 45, base_Exp: 173);
            wildPokemon.myMove = new Move("Poison Powder", accuracy: 50, pp: 35);
            PokemonInWorld.Add(wildPokemon);

            //10 ICE-------------------------------------------------------------------------------------------------------------------------------------------------------
            wildPokemon = new Pokemon(name: "Spheal", type: PokemonType.ICE, hp: 70, atk: 40, def: 50, sp_Atk: 55, sp_Def: 50, speed: 25, catch_Rate: 255, base_Exp: 58);
            wildPokemon.myMove = new Move("Powder Snow", accuracy: 10, pp: 25);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Sealeo", type: PokemonType.ICE, hp: 90, atk: 60, def: 70, sp_Atk: 75, sp_Def: 70, speed: 45, catch_Rate: 120, base_Exp: 144);
            wildPokemon.myMove = new Move("Ice Beam", accuracy: 60, pp: 10);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Delibird", type: PokemonType.ICE, hp: 45, atk: 55, def: 45, sp_Atk: 65, sp_Def: 45, speed: 75, catch_Rate: 45, base_Exp: 116);
            wildPokemon.myMove = new Move("Blizzard", accuracy: 75, pp: 5);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Dewgong", type: PokemonType.ICE, hp: 90, atk: 70, def: 80, sp_Atk: 70, sp_Def: 95, speed: 70, catch_Rate: 75, base_Exp: 166);
            wildPokemon.myMove = new Move("Aurora Beam", accuracy: 70, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Lapras", type: PokemonType.ICE, hp: 130, atk: 85, def: 80, sp_Atk: 85, sp_Def: 95, speed: 60, catch_Rate: 45, base_Exp: 187);
            wildPokemon.myMove = new Move("Ice Punch", accuracy: 85, pp: 15);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Sneasel", type: PokemonType.ICE, hp: 55, atk: 95, def: 55, sp_Atk: 35, sp_Def: 75, speed: 115, catch_Rate: 60, base_Exp: 86);
            wildPokemon.myMove = new Move("Mist", accuracy: 70, pp: 30);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Glalie", type: PokemonType.ICE, hp: 80, atk: 80, def: 80, sp_Atk: 80, sp_Def: 80, speed: 80, catch_Rate: 75, base_Exp: 168);
            wildPokemon.myMove = new Move("Ice Punch", accuracy: 85, pp: 15);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Snorunt", type: PokemonType.ICE, hp: 50, atk: 50, def: 50, sp_Atk: 50, sp_Def: 50, speed: 50, catch_Rate: 190, base_Exp: 60);
            wildPokemon.myMove = new Move("Aurora Beam", accuracy: 50, pp: 20);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Regice", type: PokemonType.ICE, hp: 80, atk: 50, def: 100, sp_Atk: 100, sp_Def: 200, speed: 50, catch_Rate: 3, base_Exp: 261);
            wildPokemon.myMove = new Move("Ice Beam", accuracy: 50, pp: 30);
            PokemonInWorld.Add(wildPokemon);

            wildPokemon = new Pokemon(name: "Cubchoo", type: PokemonType.ICE, hp: 55, atk: 70, def: 40, sp_Atk: 60, sp_Def: 40, speed: 40, catch_Rate: 120, base_Exp: 61);
            wildPokemon.myMove = new Move("Blizzard", accuracy: 70, pp: 20);
            PokemonInWorld.Add(wildPokemon);
        }
    }
}
