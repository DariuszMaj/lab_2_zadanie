using System;
using System.Collections.Generic;
namespace Lab_003
{
    class Program
    {
        static void Main(string[] args)
        {
            Seller treacher = new Seller("Jan Kowalski", 50);

            Buyer buyer1 = new Buyer("Jaś Fasola 1", 25);
            Buyer buyer2 = new Buyer("Jaś Fasola 2", 21);
            Buyer buyer3 = new Buyer("Jaś Fasola 3", 23);

            buyer1.AddProduct(new Fruit("Apple", 6));
            buyer1.AddProduct(new Meat("Fish", 0.5));

            Person[] persons = { treacher, buyer1, buyer2, buyer3 };

            Product[] products = {
                new Fruit("Apple", 1000),
                new Fruit("Banana", 700),
                new Fruit("Orange", 500),
                new Meat("Fish", 100.0),
                new Meat("Beef", 75.0)
            };
            Shop shop = new Shop("Super Market", persons, products);
            shop.Print();
        }
    }
    public interface IThing
    {
       public string Name { get; set; }
    }
    public class Product : IThing
    {
        private string name;
        public string Name { get => name; set => name = value; }
        public Product(string name)
        {
            Name = name;
        }
        public virtual string Print()
        {
            return $" {Environment.NewLine}){Environment.NewLine}";       
        }
    }
    public class Fruit : Product
    {
        private int count;
        public int Count { get => count; set => count = value; }

        public Fruit(string name, int count) : base(name)
        {
            this.count = count;
        }
        public override string Print() => $"{Name} ({count} fruits){Environment.NewLine}";
    }
    public class Meat : Product
    {
        private double weight;
        public double Weight { get => weight; set => weight = value; }

        public Meat(string name, double weight) : base(name)
        {  
            this.Weight = weight;
        }
        public override string Print() => $"{Name} ({weight} kg){Environment.NewLine}";
    }
    public class Person : IThing
    {
        private string name;
        private int age;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public virtual string Print() => $" {Name}, ({Age} y.o.){Environment.NewLine}";
    }
    public class Buyer : Person
    {
        protected List<Product> tasks = new List<Product>();
        public Buyer(string name, int age) : base(name, age) { }
        public void AddProduct(Product product)
        {
            this.tasks.Add(product);
        }
        public void RemoveProduct(int index)
        {
            this.tasks.RemoveAt(index);
        }
        public override string Print()
        {
            if (tasks.Count == 0)
            {
                return $"Buyer: {Name} ({Age} y.o){Environment.NewLine}";
            }
            else
            {
                string print = $" {Environment.NewLine}Buyer: {Name} ({Age} y.o){Environment.NewLine}{Environment.NewLine}-- Products: -- {Environment.NewLine}";

                foreach (var a in tasks)
                {
                    print += a.Print();
                }

                return print + Environment.NewLine;


            }

        }
    }
    public class Seller : Person
    {
    public Seller(string name, int age) : base(name, age) { }
    public override string Print() => $"Seller: {Name} ({Age} y.o)";
    }
    public class Shop : IThing
        {
            private string name;
            private Person[] people;
            private Product[] products;
            public string Name { get => name; set => name = value; }

            public Shop(string name, Person[] people, Product[] products)
            {
                Name = name;
                this.people = people;
                this.products = products;
            }

    public void Print()
    {
        Console.WriteLine($"Shop: {name}");
        string result = $"{Environment.NewLine}  ---People---{Environment.NewLine}";

        foreach (var person in people)
        {
            result += person.Print();
        }

        result += $"{Environment.NewLine}-- Products: -- {Environment.NewLine}";

        foreach (var product in products)
        {
            result += product.Print();
        }

        Console.WriteLine(result);
    }

}
}