using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    class Student
    {
        public string Name { get; }
        public int Age { get; }
        public Team Team { get; }

        public Student(string name, int age, Team team)
        {
            Name = name;
            Age = age;
            Team = team;
        }
    }

}
