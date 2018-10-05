using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    class Program
    {
        private static TcpClient _clientSocket = null;
        private static Stream stream = null;
        private static StreamWriter Writer = null;
        private static StreamReader Reader = null;
        static void Main(string[] args)
        {
            try
            {
                //TCP establish connection via its socket through request to server
                using (_clientSocket=new TcpClient("127.0.0.1", 7))
                {
                    using (stream = _clientSocket.GetStream())
                    {
                        while(true)
                        {
                            // Data will be flushed from the buffer to the stream after each write operation
                            Writer = new StreamWriter(stream) {AutoFlush = true};
                            Console.WriteLine("Client ready to send request to server...");
                            Console.WriteLine("Write your request here ");
                            string clientMsg = Console.ReadLine();
                            // client is ready to send data which has collected through user input
                            Writer.WriteLine(clientMsg);
                        }

                        }
                    }
        
            }
            

           
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }

    }

}