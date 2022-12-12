using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Animals
{
    public enum eClassificationAnimal
    {
        Herbivores = 1,
        Carnivores = 2,
        Omnivores = 3
    }

    public enum eFavouriteFood
    {
        Meat = 1,
        Plants = 2,
        Everything = 3
    }

    public abstract class Animal
    {
        public string Country { get; set; } = "None";
        public bool HideFromOtherAnimals { get; set; } = false;
        public string Name { get; set; } = "None";
        public string WhatAnimal { get; set; }

        public Animal() { }

        public Animal( string _country, bool _hide, string _name )
        {
            Country = _country;
            HideFromOtherAnimals = _hide;
            Name = _name;
        }

        public void Deconstruct() { }

        public abstract Enum GetClassificationAnimal();

        public abstract Enum GetFavouriteFood();

        public abstract void SayHello();

        public void Print()
        {
            Console.WriteLine( "Name: " + Name );
            Console.WriteLine( "Classification: " + GetClassificationAnimal().ToString() );
            Console.WriteLine( "Favourite food: " + GetFavouriteFood().ToString() );
            Console.WriteLine( "Country: " + Country );
            Console.WriteLine( "Hide from other animals: " + HideFromOtherAnimals );
            Console.WriteLine( "What is this animal: " + WhatAnimal );

        }
    }

    public class Cow : Animal
    {
        public Cow() : base() { this.WhatAnimal = "Cow"; }

        public Cow( string _country, bool _hide, string _name ) : base( _country, _hide, _name ) { this.WhatAnimal = "Cow"; }

        public override Enum GetClassificationAnimal()
        {
            return (eClassificationAnimal)1;
        }

        public override Enum GetFavouriteFood()
        {
            return (eFavouriteFood)2;
        }

        public override void SayHello()
        {
            Console.WriteLine( "Hello! I am " + WhatAnimal + " " + Name + " from " + Country + "!" );
        }
    }

    public class Lion : Animal
    {
        public Lion() : base() { this.WhatAnimal = "Lion"; }

        public Lion( string _country, bool _hide, string _name ) : base( _country, _hide, _name ) { this.WhatAnimal = "Lion"; }

        public override Enum GetClassificationAnimal()
        {
            return (eClassificationAnimal)2;
        }

        public override Enum GetFavouriteFood()
        {
            return (eFavouriteFood)1;
        }

        public override void SayHello()
        {
            Console.WriteLine( "Hello! I am " + WhatAnimal + " " + Name + " from " + Country + "!" );
        }
    }

    public class Pig : Animal
    {
        public Pig() : base() { this.WhatAnimal = "Pig"; }

        public Pig( string _country, bool _hide, string _name ) : base( _country, _hide, _name ) { this.WhatAnimal = "Pig"; }

        public override Enum GetClassificationAnimal()
        {
            return (eClassificationAnimal)3;
        }

        public override Enum GetFavouriteFood()
        {
            return (eFavouriteFood)3;
        }

        public override void SayHello()
        {
            Console.WriteLine( "Hello! I am " + WhatAnimal + " " + Name + " from " + Country + "!" );
        }
    }

    public class UserAttribute
    {
        public string Name { get; set; }

        public string Comment { get; set; }

        UserAttribute( string _name, string _comment ) { Name = _name; Comment = _comment; }

        public static List<UserAttribute> MyList = new List<UserAttribute>();

        static UserAttribute()
        {
            MyList.Add( new UserAttribute( "eClassificationAnimal", "Classification class for animals" ) );
            MyList.Add( new UserAttribute( "eFavouriteFood", "Class for favourite animals food" ) );
            MyList.Add( new UserAttribute( "Animal", "Base abstract class" ) );
            MyList.Add( new UserAttribute( "Cow", "Cow, Derived class from Animal class" ) );
            MyList.Add( new UserAttribute( "Lion", "Lion, Derived class from Animal class" ) );
            MyList.Add( new UserAttribute( "Pig", "Pig, Derived class from Animal class" ) );
            MyList.Add( new UserAttribute( "UserAttribute", "Specifies classes' atributes" ) );
        }

        public static string getComment( string name )
        {
            foreach (var pos in MyList) if (pos.Name == name) return pos.Comment;
            return null;
        }
    }
}