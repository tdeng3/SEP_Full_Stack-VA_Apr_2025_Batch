// See https://aka.ms/new-console-template for more information

using _04Generics;
using _04Generics.DataModels;
using _04Generics.Repository;

Console.WriteLine("Hello, World!");
MyStack<int> myStack = new MyStack<int>();
myStack.Push(1);
myStack.Push(2);
myStack.Count();
myStack.Pop();
myStack.Count();

MyList<string> names = new MyList<string>();
names.Add("Alice");
names.Add("Bob");
names.InsertAt("Charlie", 1);
Console.WriteLine(names.Find(1));     
Console.WriteLine(names.Contains("Bob")); 
names.DeleteAt(0);
Console.WriteLine(names.Remove(0));  
names.Clear();


IRepository<Product> repo = new GenericRepository<Product>();

repo.Add(new Product { Id = 1, Name = "Keyboard" });
repo.Add(new Product { Id = 2, Name = "Mouse" });

repo.DisplayAll();
var p = repo.GetById(2);
repo.Remove(p);
repo.Save();
repo.DisplayAll();
