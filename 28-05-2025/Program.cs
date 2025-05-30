using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace _28_05_2025
{
    public class Person
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Ege")]
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:/Users/joyit/source/repos/28-05-2025/28-05-2025/bin/Debug/archivo.json";
            string jsonString = "";
            try
            {
                jsonString = File.ReadAllText(filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"El archivo'{filePath}' no se encontro.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return;
            }
            try
            {
                Person person = JsonSerializer.Deserialize<Person>(jsonString);
                // 3. Imprimir los valores del objeto 
                Console.WriteLine($"Nombre:{ person.FirstName}");
                Console.WriteLine($"Apellido: {person.LastName}");
                Console.WriteLine($"Edad: {person.Age}");
                Console.ReadKey();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error de deserializacion: {ex.Message}");
            }
        }
    }
}
