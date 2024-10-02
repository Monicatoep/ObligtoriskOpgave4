using System.Net.Sockets;
using System.Net;


TcpClient clientSocket = new TcpClient("127.0.0.1", 7);
Console.WriteLine("client is ready");

Stream ns = clientSocket.GetStream();
StreamReader sr = new StreamReader(ns);
StreamWriter sw = new StreamWriter(ns);
sw.AutoFlush = true;

while (true)
{
    string serverAnswer = sr.ReadLine();

    Console.WriteLine(serverAnswer);

    Console.WriteLine("Choose your service here: ");

    string message = Console.ReadLine();
    sw.WriteLine(message);

    serverAnswer = sr.ReadLine();

    Console.WriteLine(serverAnswer);


    Console.WriteLine("Write your first number here: ");
    string message1 = Console.ReadLine();
    sw.WriteLine(message1);

    serverAnswer = sr.ReadLine();

    Console.WriteLine(serverAnswer);

    Console.WriteLine("Write your second number here: ");
    string message2 = Console.ReadLine();
    sw.WriteLine(message2);

    serverAnswer = sr.ReadLine();

    Console.WriteLine("Your answer is: " + serverAnswer);
}


