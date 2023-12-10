using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_2030854.Classes
{
   public class Items
    {
        private string name;
        private int price;
        public Items() { }
        public Items(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }

        public override string ToString()
        {
            return this.Name + " : " + this.Price;
        }
    }
}
