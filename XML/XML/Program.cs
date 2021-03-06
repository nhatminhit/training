using System;
using System.IO;
using System.Xml.Serialization;
namespace XML
{

    public class Student
    {
        public int Id { get; set; } = 1;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student
            {
                Id = 1,
                FirstName = "Hoang Nhat",
                LastName = "Minh",
                DateOfBirth = new DateTime(2001, 05, 11)
            };
            Console.WriteLine("Original object:");
            Print(student);
            Save(student);
            var nva = Load();
            Console.WriteLine("Deserialized object:");
            Print(nva);
            Console.ReadKey();
        }
        static void Print(Student student)
        {
            Console.WriteLine($"Id: {student.Id}\r\nFirst Name: {student.FirstName}\r\nLast Name: {student.LastName}\r\nDate of birth: {student.DateOfBirth.ToShortDateString()}");
        }
        static void Save(Student student)
        {
            using (var stream = File.OpenWrite("data.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Student));
                serializer.Serialize(stream, student);
            }
        }
        static Student Load()
        {
            Student student;
            using (var stream = File.OpenRead("data.xml"))
            {
                var serializer = new XmlSerializer(typeof(Student));
                student = serializer.Deserialize(stream) as Student;
            }
            return student;
        }
    }
}
