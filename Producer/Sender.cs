using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = "alejandro",
    Password = "5r0sc0Ra"
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare("AlejandroQueue", false, false, false, null);
    var message = "Bienvenido al curso de RabbitMQ y .Net";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish("", "AlejandroQueue", null, body);
    Console.WriteLine("El mensaje fue enviado {0}", message);
};

Console.WriteLine("Presiona enter para salir de la aplicacion");
Console.ReadLine();
