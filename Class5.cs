using System;

public abstract class Animal
{
    public string Type { get; protected set; } // Protected set allows derived classes to set it

    public Animal(string type)
    {
        Type = type;
    }

    public abstract string MakeSound();
    public abstract string GetInformation();
}

public class Dog : Animal
{
    public string Name { get; set; }
    public string Breed { get; set; }

    public Dog(string name, string breed) : base("Mammal")
    {
        Name = name;
        Breed = breed;
    }

    public override string MakeSound()
    {
        return "Woof!";
    }

    public override string GetInformation()
    {
        return $"Dog: Name = {Name}, Breed = {Breed}, Type = {Type}";
    }
}

public class Cat : Animal
{
    public string Name { get; set; }

    public Cat(string name) : base("Mammal")
    {
        Name = name;
    }

    public override string MakeSound()
    {
        return "Meow!";
    }

    public override string GetInformation()
    {
        return $"Cat: Name = {Name}, Type = {Type}";
    }

    public void Climb(string thing)
    {
        Console.WriteLine($"{Name} is climbing a {thing}.");
    }
}

public class Duck : Animal
{
    public string Name { get; set; }

    public Duck(string name) : base("Bird")
    {
        Name = name;
    }

    public override string MakeSound()
    {
        return "Quack!";
    }

    public override string GetInformation()
    {
        return $"Duck: Name = {Name}, Type = {Type}";
    }

    public void Swim(string thing)
    {
        Console.WriteLine($"{Name} is swimming in a {thing}.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Dog dog = new Dog("Buddy", "Spaniel");
        Cat cat = new Cat("Whiskers");
        Duck duck = new Duck("Daffy");

        Console.WriteLine(dog.GetInformation());
        Console.WriteLine($"Sound: {dog.MakeSound()}");

        Console.WriteLine(cat.GetInformation());
        Console.WriteLine($"Sound: {cat.MakeSound()}");
        cat.Climb("tree");

        Console.WriteLine(duck.GetInformation());
        Console.WriteLine($"Sound: {duck.MakeSound()}");
        duck.Swim("pond");


        //Demonstrating polymorphism
        Animal myPet;

        myPet = dog;
        Console.WriteLine(myPet.MakeSound()); //Output: Woof!
        Console.WriteLine(myPet.GetInformation());

        myPet = cat;
        Console.WriteLine(myPet.MakeSound()); //Output: Meow!
        Console.WriteLine(myPet.GetInformation());

        myPet = duck;
        Console.WriteLine(myPet.MakeSound()); //Output: Quack!
        Console.WriteLine(myPet.GetInformation());

    }
}