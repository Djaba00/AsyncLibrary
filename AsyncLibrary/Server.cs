using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLibrary
{
    public static class Server
    {
        public static int Count;
        public static bool IsBusy;

        public static async Task Run(Client client)
        {
            switch(client.Type)
            {
                case 1:
                    if(IsBusy == false)
                    {
                        GetCount(client);
                    }
                    break;
                case 2:
                    if(IsBusy == false)
                    {
                        var rnd = new Random();
                        AddToCount(client, rnd.Next(1, 1000));
                    }
                    break;
            }
        }
        
        public static async Task GetCount(Client client)
        {
            Console.WriteLine($"Клиент {client.Id} читает, значение {Count}");
            Thread.Sleep(client.Time);
            Console.WriteLine($"Клиент {client.Id} выходит, значение {Count}");
        }

        public static async Task AddToCount(Client client, int value)
        {
            IsBusy = true;
            Count += value;
            Console.WriteLine($"Писатель {client.Id} пишет, новое значение {Count}");
            Thread.Sleep(client.Time);
            Console.WriteLine($"Писатель {client.Id} выходит, новое значение {Count}");
            IsBusy = false;
        }
    }
}
