using System;
using System.Net.Sockets;
using System.Threading;
public class Client
{
    static public void Main(string[] Args)
    {
        TcpClient socketForServer;
        try
        {
            socketForServer = new TcpClient("192.168.1.102", 9999);
        }
        catch
        {
            Console.WriteLine(
            "Failed to connect to server at {0}:999", "localhost");
            return;
        }

        NetworkStream networkStream = socketForServer.GetStream();
        System.IO.StreamReader streamReader =
        new System.IO.StreamReader(networkStream);
        System.IO.StreamWriter streamWriter =
        new System.IO.StreamWriter(networkStream);

        try
        {
            string outputString;
            {
                Console.WriteLine("Tulis Pesan :");
                string str = Console.ReadLine();
                while (str != "exit")
                {
                    streamWriter.WriteLine(str);
                    streamWriter.Flush();
                    Console.WriteLine("Tulis Pesan :");
                    str = Console.ReadLine();
                }
                if (str == "exit")
                {
                    streamWriter.WriteLine(str);
                    streamWriter.Flush();

                }

            }
        }
        catch
        {
            Console.WriteLine("Exception reading from Server");
        }

        networkStream.Close();
        Console.WriteLine("Press any key to exit from client program");
        Console.ReadKey();
    }

    private static string GetData()
    {
        return "ack";
    }
}