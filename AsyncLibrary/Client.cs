using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLibrary
{
    public class Client
    {
        Random random;
        public readonly int Id;
        public int Type;
        public readonly int Time;

        public Client(int id)
        {
            random = new Random();
            Type = 1;
            Time = random.Next(1, 5) * 1000;
            Id = id;
        }
    }
}
