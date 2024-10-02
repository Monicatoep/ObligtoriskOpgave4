using System.IO;
using System.Net;
using System.Net.Sockets;

Console.WriteLine("Calculator");

IPAddress ip = IPAddress.Parse("127.0.0.1");
TcpListener listener = new TcpListener(ip, 7);
listener.Start();

while (true)
{
    TcpClient socket = listener.AcceptTcpClient();
    Task.Run(() => HandleClient(socket));
}

void HandleClient(TcpClient socket)
{
    NetworkStream ns = socket.GetStream();
    StreamReader reader = new StreamReader(ns);
    StreamWriter writer = new StreamWriter(ns);

    writer.WriteLine("Choose between: Random: 1 Add: 2 Subtract: 3");
    writer.Flush();

    string message = reader.ReadLine().ToLower();

    while (message != "close")
    {
        Console.WriteLine("Client sent: " + message);

        if (message == "1")
        {
            writer.WriteLine("Input first number");
            writer.Flush();
            message = reader.ReadLine();
            int num1 = Int32.Parse(message);
            Console.WriteLine("Client sent: " + message);

            writer.WriteLine("Input second number");
            writer.Flush();
            message = reader.ReadLine();
            int num2 = Int32.Parse(message);
            Console.WriteLine("Client sent: " + message);

            Random rng = new Random();
            int result = rng.Next(num1, num2);

            writer.WriteLine(result);
            writer.Flush();

            writer.WriteLine("Choose between: Random: 1 Add: 2 Subtract: 3");
            writer.Flush();

            message = reader.ReadLine().ToLower();
        }

        else if (message == "2")
        {
            writer.WriteLine("Input first number");
            writer.Flush();
            message = reader.ReadLine();
            int num1 = Int32.Parse(message);
            writer.WriteLine("Input second number");
            writer.Flush();
            message = reader.ReadLine();
            int num2 = Int32.Parse(message);

            int result = num1 + num2;
            writer.WriteLine(result);
            writer.Flush();

            writer.WriteLine("Choose between: Random: 1 Add: 2 Subtract: 3");
            writer.Flush();

            message = reader.ReadLine().ToLower();
        }

        else if (message == "3")
        {
            writer.WriteLine("Input first number");
            writer.Flush();
            message = reader.ReadLine();
            int num1 = Int32.Parse(message);
            writer.WriteLine("Input second number");
            writer.Flush();
            message = reader.ReadLine();
            int num2 = Int32.Parse(message);

            int result = num1 - num2;
            writer.WriteLine(result);
            writer.Flush();

            writer.WriteLine("Choose between: Random: 1 Add: 2 Subtract: 3");
            writer.Flush();

            message = reader.ReadLine().ToLower();
        }
    }
    socket.Close();
}

