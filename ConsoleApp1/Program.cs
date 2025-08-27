using ConsoleApp1Client;
using Grpc.Net.Client;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    internal class Program {
        static async Task Main(string[] args) {

            Console.WriteLine("Press any key after grpc service boots...");
            Console.ReadKey();


            string addr = "https://localhost:7158";


            using var channel = GrpcChannel.ForAddress(addr);
            var client = new Greeter.GreeterClient(channel);

            var t  = await client.SayHelloAsync(new(){ Name = "(from client)"});

            Console.WriteLine(t.Message);
            Console.ReadKey();




        }
    }
}
