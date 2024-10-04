using System.Net.Sockets;
using System.Net;

//RUN WITH SERVERVERSION2

TcpClient clientSocket = new TcpClient("127.0.0.1", 7);
Console.WriteLine("client is ready");

Stream ns = clientSocket.GetStream();
StreamReader sr = new StreamReader(ns);
StreamWriter sw = new StreamWriter(ns);
sw.AutoFlush = true;

while (true)
{
    string serverAnswer = sr.ReadLine();

    //Choose service
    Console.WriteLine(serverAnswer);

    string message = Console.ReadLine();
    sw.WriteLine(message);

    serverAnswer = sr.ReadLine();

    //Write your two numbers
    Console.WriteLine(serverAnswer);

    string message1 = Console.ReadLine();
    sw.WriteLine(message1);

    serverAnswer = sr.ReadLine();
    Console.WriteLine("Your answer is: " + serverAnswer);
}