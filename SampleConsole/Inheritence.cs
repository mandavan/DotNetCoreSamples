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

    interface ICar
    {
         int Seats { get; set; }
         void Drive();

    }

    abstract class Car: ICar
    {
        public int Seats { get; set;}
        public abstract void Drive();
    }

    class Benze : Car
    {
        public override void Drive()
        {
            
        }
    }
    class BenzeNew : Benze
    {
        public new void Drive()
        {

        }
    }

    class A
    {
        public int val = 0;
    }
    class B : A
    {
        public new string val = "";
    }
    class C
    {
        public C()
        {
            A a = new A();
            a.val = 1;
            B b = new B();
            b.val = "";
            a = b;
        }
    }
}
