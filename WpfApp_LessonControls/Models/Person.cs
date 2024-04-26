using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_LessonControls.Models
{
    public class Person
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Gender { get; set; }

        public string? City { get; set; }

        bool isStep { get; set; }

        public Person(string name, string surname, string gender, string city, bool isStep)
        {
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            this.City = city;
            this.isStep = isStep;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} -- {Gender} -- {City} --{isStep} \n";
        }
    }
}
