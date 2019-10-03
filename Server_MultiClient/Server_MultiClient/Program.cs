using System;
using System.Net.Sockets;
using System.Threading;
public class AsynchIOServer
{
    static TcpListener tcpListener = new TcpListener(9999);
    public static string kata;
    static void Listeners()
    {

        Socket socketForClient = tcpListener.AcceptSocket();
        if (socketForClient.Connected)
        {
            Console.WriteLine("Client:" + socketForClient.RemoteEndPoint + " now connected to server.");
            NetworkStream networkStream = new NetworkStream(socketForClient);
            System.IO.StreamWriter streamWriter =
            new System.IO.StreamWriter(networkStream);
            System.IO.StreamReader streamReader =
            new System.IO.StreamReader(networkStream);

            while (true)
            {
                string theString = streamReader.ReadLine();
                Console.WriteLine("Message recieved by client:" + theString);
                if (theString == "exit")
                    break;
                if (theString == kata)
                    Console.WriteLine("Menang");
            }
            streamReader.Close();
            networkStream.Close();
            streamWriter.Close();
            

        }

        socketForClient.Close();
        Console.WriteLine("Press any key to exit from server program");
        Console.ReadKey();
    }

    public static void Main()
    {
        Console.WriteLine("Server Mamasukkan Kata : ");
        kata = Console.ReadLine();

        tcpListener.Start();
        Console.WriteLine("Client Waiting");
        
        int numberOfClientsYouNeedToConnect = 3;

        for (int i = 0; i < numberOfClientsYouNeedToConnect; i++)
        {
            Thread newThread = new Thread(new ThreadStart(Listeners));
            newThread.Start();
        }
        
    }
}