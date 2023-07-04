using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Dummy
{
    /// <summary>
    /// This is a dummy class.
    /// </summary>
    public class Ally
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Attack { get; set; }
        public int Speed { get; set; }
        public List<string> Skills { get; set; }
        public Ally(string name, int maxHealt, int attack, int speed, List<String> Skills)
        {
            this.Name = name;
            this.MaxHealth = maxHealt;
            this.Attack = attack;
            this.Speed = speed;
            this.Skills = Skills;
        }
    }
}
