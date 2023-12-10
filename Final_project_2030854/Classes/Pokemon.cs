using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_2030854.Classes
{
    public enum AttackType { PHYSICAL, SPECIAL, STATUS }
    public enum PokemonType { FIRE, WATER, ELECTRIC, GRASS, ICE, POISON }
    public enum PokemonStatus { ACTIVE, ASLEEP, FROZEN, PARALYZED, BURNED, POISONED }
    public class Pokemon
    {
       

      
            //FIRE, WATER, ELECTRIC, GRASS, ICE, POISON 
            static int[,] TypeChart = {/*FIRE*/ {50 , 50 , 100 , 200 , 200 , 100},
                                  /*WATER*/     {200, 50 , 100 , 50  , 50  , 100},
                               /*ELECTRIC*/     {100, 200, 50  , 50  , 100 , 100},
                                  /*GRASS*/     {50 , 200, 100 , 50  , 100 , 100},
                                    /*ICE*/     {50 , 50 , 100 , 200 , 50  , 50 },
                                 /*POISON*/     {100, 100, 100 , 200 , 100 , 100}};
            public string Name;
            private PokemonType type;    //FIRE, WATER, ELECTRIC, GRASS, ICE, POISON
            public PokemonStatus status; //Default value is ACTIVE, it changes after a Status Attack (Move) to ASLEEP, FROZEN, PARALYZED, BURNED, POISONED
            public Move myMove;          //Status Attack

            public int HP;      // Hit Points
            public int HP_MAX;  // Max Hit Points
            private int Atk;    //Physical Attack Power
            private int Atk_Max;//Max Physical Attack Power
            private int Def;    //Physical Defense
            private int Sp_Atk; //Special Attack Power
            private int Sp_Def; //Special Defense
            private int Speed;  //Speed
            private int Speed_Max;// Max_Speed

            public int Catch_Rate;          //Used by Ball to calculate the chance to catching the Pokemon
            public int Status_Threshold = 0;//Used by Ball to calculate the chance to catching the Pokemon
            private int Sleep_Duration = 0; //Used for ASLEEP Pokemon
            private int Extra_Damage = 0;   //USED for BURNED or POISONED Pokemon to give him extra damage

            private int base_Exp;  //Used to calculate the reward Point of the Trainer. You can use it for LevelUp also
            private int Level = 1; //Used to calculate the LevelUp
            private Pokemon target = null;

        public Pokemon Target { get => target; set => target = value; }
        public int Base_Exp { get => base_Exp; set => base_Exp = value; }
        public PokemonType Type { get => type; set => type = value; }
        public Pokemon() { }

        public Pokemon(string name, PokemonType type, int hp, int atk, int def, int sp_Atk, int sp_Def, int speed, int catch_Rate, int base_Exp)
            {
                this.Name = name;
                this.type = type;
                this.status = PokemonStatus.ACTIVE;
                this.HP = 3 * hp;    //Hits Points formulas =  3 * HP
                this.HP_MAX = 3 * hp;//Hits Points formulas =  3 * HP
                this.Atk = atk;
                this.Atk_Max = atk;
                this.Def = def/3;
                this.Sp_Atk = sp_Atk;
                this.Sp_Def = sp_Def/3;
                this.Speed = speed;
                this.Speed_Max = speed;
                this.Catch_Rate = catch_Rate;
                this.Base_Exp = base_Exp;
            }
       
        public Pokemon Clone()
            {
                Pokemon clone = new Pokemon(name: this.Name,
                                            type: this.type,
                                            hp: this.HP,
                                            atk: this.Atk,
                                            def: this.Def,
                                            sp_Atk: this.Sp_Atk,
                                            sp_Def: this.Sp_Def,
                                            speed: this.Speed,
                                            catch_Rate: this.Catch_Rate,
                                            base_Exp: this.Base_Exp);
                return clone;
            }

            public bool Is_Fainted()
            {
                return this.HP <= 0;
            }
            //-----------------------------------------------------------------------------------------------
            public void Burn()
            {
                if (this.type != PokemonType.FIRE)
                {
                    this.status = PokemonStatus.BURNED;
                    this.Atk = this.Atk / 2;   //Attack Power is decreased by 50%
                    this.Status_Threshold = 12;//It increases the chance of catching the Pokemon
                    this.Extra_Damage = this.HP_MAX / 8;//The pokemon will receive extra damage
                    Console.WriteLine("\n " + this.Name + " is BURNED !");
                }
            }
            public void Poison()
            {
                if (this.type != PokemonType.POISON)
                {
                    this.status = PokemonStatus.POISONED;
                    this.Status_Threshold = 12;       //It increases the chance of catching the Pokemon
                    this.Extra_Damage = this.HP_MAX / 8;//The pokemon will receive extra damage
                    Console.WriteLine("\n " + this.Name + " is POISONED !");
                }
            }
            public void Freeze()
            {
                if (this.type != PokemonType.ICE && this.type != PokemonType.FIRE)
                {
                    this.status = PokemonStatus.FROZEN;//FROZEN Pokemon is unable to use Special Attack
                    this.Status_Threshold = 25;        //It increases the chance of catching the Pokemon
                    Console.WriteLine("\n " + this.Name + " is FROZEN !");
                }
            }
            public void Paralysis()
            {
                if (this.type != PokemonType.ELECTRIC)
                {
                    this.status = PokemonStatus.PARALYZED;
                    this.Speed = this.Speed / 2; //Speed is decreased by 50%
                    this.Status_Threshold = 12;  //It increases the chance of catching the Pokemon
                    Console.WriteLine("\n "+this.Name + " is PARALYZED !");
                }
            }
            public void Sleep()
            {
                this.status = PokemonStatus.ASLEEP;
                this.Sleep_Duration = RNG.GetInstance().Next(1, 8);//Sleep lasts for a randomly chosen duration of 1 to 7 turns
                this.Status_Threshold = 25;                        //It increases the chance of catching the Pokemon
                Console.WriteLine("\n " + this.Name + " falls ASLEEP !");
            }
            public void Soak()
            {
                this.type = PokemonType.WATER;
                this.myMove = new Move("Soak", 100, 20);
                Console.WriteLine("\n " + this.Name + " is SOAKED and became a WATER Pokemon !");
            }
            //-----------------------------------------------------------------------------------------------
            private void Move_Attack(Pokemon target)
            {
              if (myMove.PP <= 0)
              {
                Console.WriteLine("You cannot perform this move ! PP = 0");
                return;//exit
              }
              else
              {
                //Calculate the chance of hitting the target
                int random = RNG.GetInstance().Next(0, 100);
                if (random < this.myMove.Accuracy)
                {
                    switch (this.type)
                    {
                        case PokemonType.ELECTRIC:
                            target.Paralysis();
                            myMove.PP--;
                            break;
                        case PokemonType.FIRE:
                            target.Burn();
                            myMove.PP--;
                            break;
                        case PokemonType.ICE:
                            target.Freeze();
                            myMove.PP--;
                            break;
                        case PokemonType.POISON:
                            target.Poison();
                            myMove.PP--;
                            break;
                        case PokemonType.GRASS:
                            target.Sleep();
                            myMove.PP--;
                            break;
                        case PokemonType.WATER:
                            target.Soak();
                            myMove.PP--;
                            break;
                        default:
                            Console.WriteLine("We cannot perform a Move of an Unknow Pokemon Type!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(target.Name + " avoided the Status Attack !");
                }
              }
            }
            //-----------------------------------------------------------------------------------------------
            public void ApplyPotion(PotionType type)
            {
                switch (type)
                {
                    case PotionType.ANTIDOTE:
                        Poison_Heal();
                        break;
                    case PotionType.AWAKENING:
                        Sleep_Heal();
                        break;
                    case PotionType.BURN_HEAL:
                        Burn_Heal();
                        break;
                    case PotionType.FULL_HEAL:
                        Full_Heal();
                        break;
                    case PotionType.FULL_RESTORE:
                        Full_Restore();
                        break;
                    case PotionType.ICE_HEAL:
                        Ice_Heal();
                        break;
                    case PotionType.MAX_POTION:
                        Max_Heal();
                        break;
                    case PotionType.PARALYZE_HEAL:
                        Paralyze_Heal();
                        break;
                    case PotionType.REVIVE:
                        Revive();
                        break;
                    case PotionType.PP_MAX:
                        this.myMove.Resest_PP();
                        break;
                    case PotionType.PP_UP:
                        this.myMove.Increase_PP_Max(10);
                        break;
                    case PotionType.COURAGE_CANDY:
                        this.Sp_Def += 10;
                        break;
                    case PotionType.MIGHTY_CANDY:
                        this.Atk += 10;
                        this.Atk_Max += 10;
                        break;
                }
            }
            //---------------------------------------------------------------------------------------
            public void Burn_Heal()
            {
            this.Atk = this.Atk_Max;
            this.status=PokemonStatus.ACTIVE;
            }

            public void Poison_Heal()
            {
            this.status = PokemonStatus.ACTIVE;
            }

            public void Ice_Heal()
            {
            this.status = PokemonStatus.ACTIVE;
            }

            public void Paralyze_Heal()
            {
            this.Speed = this.Speed_Max;
            this.status = PokemonStatus.ACTIVE;
            }

            public void Sleep_Heal()
            {
            this.status = PokemonStatus.ACTIVE;
            }

            public void Max_Heal()
            {
            this.HP = (HP_MAX*3);
            }

            public void Full_Heal()
            {
            this.Atk = this.Atk_Max;
            this.Speed = this.Speed_Max;
            this.status = PokemonStatus.ACTIVE;
            
            }

            public void Full_Restore()
            {
            this.HP = (HP_MAX*3);
            this.Speed = this.Speed_Max;
            this.Atk = this.Atk_Max;
            this.status = PokemonStatus.ACTIVE;
            }

            public void Revive()
            {
            this.HP = 20;
            this.status = PokemonStatus.ACTIVE;
            }

        public override string ToString()
        {
            string info = "Current Pokemon info: " + this.Name + " | " + this.HP + " | " + this.Speed + " | " + this.type.ToString() + " | " + this.status + " | " + this.Status_Threshold;
            return info;
        }
            public void Take_Damage(int damage, AttackType type)
            {
             if (type==AttackType.PHYSICAL&& damage>this.Def)
             {
                int shielded_damage = this.HP + this.Def;
                shielded_damage -= damage;
             }
             else if( type==AttackType.SPECIAL&&damage>this.Sp_Def)
             {
              
                if(status==PokemonStatus.BURNED||status==PokemonStatus.POISONED)
                {
                    this.HP -= Extra_Damage;
                }
                else
                {
                    int special_shielded_damage = this.HP + this.Sp_Def;
                    special_shielded_damage -= damage;
                }
             } 
            
            }

            public void Attack(Pokemon target, AttackType atk_type)
            {
            int row = (int)this.type;
            int column = (int)target.type;
              if(this.status==PokemonStatus.PARALYZED)
              {
                if(RNG.GetInstance().Next(0,100)<25)
                {
                    return;
                }
              }
              else if(status==PokemonStatus.ASLEEP)
              {
                if(Sleep_Duration>0)
                {
                    Sleep_Duration--;
                    return;
                }
              }
              else if(atk_type==(AttackType)status)
              {
                Move_Attack(target);
          
                    return;
              }
              else if(atk_type==AttackType.PHYSICAL)
              {
                int random_damage = RNG.GetInstance().Next(0, Atk);
                target.Take_Damage(random_damage, atk_type);
                Message.PrintMagenta("\nYour Pokemon dealt " + random_damage + " to" + target.Name);
                if(target.Is_Fainted())
                {
                    this.LevelUp();
                }
              }
              else if (atk_type == AttackType.SPECIAL&&status!=PokemonStatus.FROZEN)
              {
                int random_damage = RNG.GetInstance().Next(0, Sp_Atk);
                int final_damage = random_damage * TypeChart[row, column] / 100;
                target.Take_Damage(final_damage, atk_type);
                Message.PrintMagenta("\nYour Pokemon dealt" + final_damage + "to" + target.Name);

                if(target.Is_Fainted())
                {
                    this.LevelUp();
                }
              }

            }

        public void LevelUp()
        {
            int requiredXP = (int)Math.Floor(10 * Math.Pow(this.Level, 2));
            if(this.Base_Exp>requiredXP)
            {
                Level++;
                HP_MAX += 10;
                Atk_Max += 5;
            }
        }
        
    }
}
