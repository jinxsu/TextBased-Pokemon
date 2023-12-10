using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_2030854.Classes
{
    public class RNG:Random
    {
        public static RNG instance = null;

        private RNG() : base() { }

        public static RNG GetInstance()
        {
            if (instance == null)
            {
                instance = new RNG();
            }
            return instance;
        }
    }
}
