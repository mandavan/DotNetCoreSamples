using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Animal
    {
        public string Name = "";
        public int noOfLegs = 0;
        public void Walk()
        {
            Console.WriteLine("{0} Walks with {1} legs", Name, noOfLegs);
        }
       
    }

    class Dog : Animal
    {
        public Dog(string name)
        {
            Walk();
            Name = name;
            noOfLegs = 4;
            
        }
        
    }

    class Kangaroo : Animal
    {
        public Kangaroo(string name)
        {
            Name = name;
            noOfLegs = 2;
            Walk();
        }
        
    }
}
