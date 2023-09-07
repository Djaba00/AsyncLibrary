using System;
using System.Data;

namespace AsyncLibrary
{
    class Program
    {
        public static void Main(string[] args)
        {
            object locker = new();
            
            int clientsCount = 0;
            do
            {
                Console.Write("Колличество клиентов: ");
                bool validValue = Int32.TryParse(Console.ReadLine(), out clientsCount);
            }
            while (clientsCount < 1);

            List<Client> clients = new List<Client>();

            for (int i = 0; i < clientsCount; i++)
            {
                clients.Add(new Client(i));
            }

            int counter = 0;
            while (true)
            {
                counter++;
                foreach (Client client in clients)
                {
                    if (counter % 20 == 0)
                    {
                        client.Type = 2;
                        Monitor.Enter(locker);
                        Task.Run(() => Server.Run(client)).Wait();
                        Monitor.Exit(locker);
                    }

                    if (counter % 20 != 0)
                    {
                        client.Type = 1;
                        Task.Run(() => Server.Run(client));
                    }
                }
            }
        }
    }
}