﻿using System.Net.Sockets;
using System.Text;

namespace Homework_NP_2
{
    class Program
    {
        static void Main()
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 8888);
                NetworkStream stream = client.GetStream();


                Console.WriteLine("Enter two currencies to get the rate (for example: USD EURO): ");

                while (true)
                {
                    string input = Console.ReadLine();

                    if (input.ToLower() == "exit")
                    {
                        break;
                    }

                    byte[] data = Encoding.UTF8.GetBytes(input);
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Console.WriteLine($"Server response: {response}");
                }

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
