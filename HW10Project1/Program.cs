/// Homework No. 10 Project No. 1
/// File Name : Program.cs
/// @author : Joshua Um
/// Date : November 8 2021
/// 
/// Problem Statement : Create a class called Vehicle, which has an association with Person class. Then create a Truck class derrived from Vehicle class.
/// 
/// Plan:
/// 1. Create Person, Vehicle, and Truck objects.
/// 2. Test Vehicle ToString().
/// 3. Test Vehicle property setters.
/// 4. Test Vehicle Equals().
/// 5. Test Truck ToString().
/// 6. Test Truck property setters.
/// 7. Test Truck Equals().
/// 8. Test Person ToString().
/// 9. Test Person field setter and getter.
/// 10. Test Person Equals().
/// 
using System;

namespace HW10Project1
{
    public enum Manufracturer {CarMaker, CarMaker2, CarCreator, AssociationOfModernVehiclesAssemblyProduction};

    class Program
    {
        static void Main(string[] args)
        {
            Person bob = new Person("Bob");
            Person robert = new Person("Robert");

            Console.WriteLine(bob);
            
            Vehicle car1 = new Vehicle(Manufracturer.CarCreator, 10, bob);

            Console.WriteLine(car1);

            car1.Cylinders = 11;

            Console.WriteLine("--Changed Cylinders to 11--" + car1);

            car1.Make = Manufracturer.CarMaker2;

            Console.WriteLine("--Changed Make to CarMaker2--" + car1);

            car1.Owner = robert;

            Console.WriteLine("--Changed Owner to Robert--" + car1);


            Console.WriteLine("Equals() test to itself : " + car1.Equals(car1));

           
            Truck truck1 = new Truck(Manufracturer.AssociationOfModernVehiclesAssemblyProduction, 20, bob, 20, 10);

            Console.WriteLine();
            Console.WriteLine(truck1);


            truck1.Cylinders = 12;

            Console.WriteLine("--Changed Cylinders to 12--" + truck1);

            truck1.Make = Manufracturer.CarMaker;

            Console.WriteLine("--Changed Make to CarMaker--" + truck1);

            truck1.Owner = robert;

            Console.WriteLine("--Changed Owner to Robert--" + truck1);


            robert.setName("Davidson");

            Person davidson = robert;

            Console.WriteLine("--Robert changed to Davidson--" + davidson);

            Console.WriteLine("GetName() test  : " + davidson.getName());






        }
    }


    public class Person
    {
        private String name;  

        public Person()
        {
            this.name = "";
        }


        public Person(String name)
        {
            this.name = name;
        }

        public Person(Person obj)
        {
            this.name = obj.getName();
        }

        public String getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return "\nName : " + name + "\n"; 
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Person))
            {
                return false;
            }

            Person other = (Person)obj;

            return this.name.Equals(other.getName());
        }


    }


    public class Vehicle
    {
        public Manufracturer Make { get; set; }
        public int Cylinders { get; set; }

        public Person Owner { get; set; }

        public Vehicle()
        {
            Make = Manufracturer.CarMaker;
            Cylinders = 0;
            Owner = new Person(); 
        }

        public Vehicle(Manufracturer Make, int Cylinders, Person Owner)
        {
            this.Make = Make;
            this.Cylinders = Cylinders;
            this.Owner = Owner;
        }


        public override string ToString()
        {
            return "\nMake : " + Make + "\nCylinders : " + Cylinders + "\nOwner : " + Owner.getName() + "\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Vehicle))
            {
                return false;
            }

            Vehicle other = (Vehicle)obj;

            return Make == other.Make && Cylinders == other.Cylinders && Owner.Equals(other.Owner);
        }


    }

    public class Truck : Vehicle
    {
        public double LoadCapacity { get; set; }
        public int  TowCapacity { get; set; }


        public Truck() : base()
        {
            LoadCapacity = 0;
            TowCapacity = 0;

        }

        public Truck (Manufracturer Make, int Cylinders, Person Owner, double LoadCapacity, int TowCapacity) : base(Make, Cylinders, Owner)
        {
            this.LoadCapacity = LoadCapacity;
            this.TowCapacity = TowCapacity;
        }


        public override string ToString()
        {
            return  base.ToString() + "Load Capacity : "  + LoadCapacity + "\nTowCapacity : " + TowCapacity + "\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Truck))
            {
                return false;
            }

            Truck other = (Truck)obj;

            return base.Equals(obj) && TowCapacity == other.TowCapacity && LoadCapacity.Equals(other.LoadCapacity);
        }








    }






}
