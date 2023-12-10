using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_2030854.Classes
{
    public class Move
    {
        private string name;
        private int accuracy;
        private int pp;    //max value is 56
        private int pp_Max;//max value is 56

        public string Name { get => name; set => name = value; }
        public int Accuracy { get => accuracy; set => accuracy = value; }
        public int PP { get => pp; set => pp = (value > 56) ? 56 : value; }
        public int PP_Max { get => pp_Max; set => pp_Max = (value > 56) ? 56 : value; }
        public Move() { }
        public Move(string name, int accuracy, int pp)
        {
            this.name = name;
            this.accuracy = accuracy;
            this.PP = pp;
            this.PP_Max = pp;
        }
        public void Increase_PP_Max(int max)
        {
            this.PP_Max += max;//Max Value is 56 ( the validation is done in the Set=> ) 
        }
        public void Resest_PP()
        {
            this.PP = this.PP_Max;
        }

    }
}
