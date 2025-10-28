using System;

namespace Laboratorio21
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();


            client.FirstName = "Bivian";
            client.LastName = "Paris";
            client.Age = 37;
            client.Id = 8;


            Console.WriteLine(client.GetFullName());
        }
    }


    public class Client
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ushort Age { get; set; }

        public string GetFullName()
        {

            return FirstName + " " + LastName + " Edad " + Age + " ID = " + Id;
        }
    }
}