using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System;

namespace Serialization_exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30,
                Weight = 70.5
            };

            string json = JsonSerializer.Serialize(person);
            Console.WriteLine("Serialized to JSON:");
            Console.WriteLine(json);
            Console.WriteLine();

            byte[] binaryData;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, person);
                binaryData = memoryStream.ToArray();
            }
            Console.WriteLine("Serialized to Binary:");

            Console.WriteLine(BitConverter.ToString(binaryData));
            Console.WriteLine();

            Person deserializedPerson;
            using (MemoryStream memoryStream = new MemoryStream(binaryData))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                deserializedPerson = (Person)formatter.Deserialize(memoryStream);
            }

            string jsonFromBinary = JsonSerializer.Serialize(deserializedPerson);
            Console.WriteLine("Deserialized from Binary to JSON:");
            Console.WriteLine(jsonFromBinary);
            Console.WriteLine();

            
            Person deserializedPersonFromJson = JsonSerializer.Deserialize<Person>(jsonFromBinary);
            Console.WriteLine("Deserialized from JSON to Person:");
            Console.WriteLine($"FirstName: {deserializedPersonFromJson.FirstName}");
            Console.WriteLine($"LastName: {deserializedPersonFromJson.LastName}");
            Console.WriteLine($"Age: {deserializedPersonFromJson.Age}");
            Console.WriteLine($"Weight: {deserializedPersonFromJson.Weight}");
        }
    }
}