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

            //shop.Print();
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
        //print


    }
    public class Fruit : Product
    {
        private int count;
        public int Count { get => count; set => count = value; }

        public Fruit(string name, int count) : base(name)
        {
            Name = name;
            Count = count;
        }
        //print
    }
    public class Meat : Product
    {
        private double weight;
        public double Weight { get => weight; set => weight = value; }

        public Meat(string name, double weight) : base(name)
        {
            Name = name;
            Weight = weight;
        }
        //print
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

        //print

    }

    public class Buyer : Person
    {
        protected List<Product> tasks = new List<Product>();
        public Buyer(string name, int age) : base(name, age)
        {
            Name = name;
            Age = age;

        }

        public void AddProduct(Product product)
        {
            tasks.Add(product);
        }
        public void RemoveProduct(int index)
        {
            tasks.RemoveAt(index); 
        }
    }

    public class Seller:Person
    {
        public Seller(string name, int age):base(name,age)
        {
            Name = name;
            Age = age;
        }
        //print
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
        //print
    }
}
