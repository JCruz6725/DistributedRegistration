using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace test {
    internal class Program {
        static void Main(string[] args) {
            

            string computerName = Dns.GetHostName();


            IPHostEntry ip = Dns.GetHostEntry(computerName, AddressFamily.InterNetwork);

            Console.WriteLine(computerName);
            Console.WriteLine(ip.AddressList[0].ToString());


            var p = NetworkInterface.GetAllNetworkInterfaces();



        }
    }
}
