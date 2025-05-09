namespace _04Generics.Repository;

public class GenericRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly List<T> myGenericList = new List<T>();

    public void Add(T item)
    {
        myGenericList.Add(item);
        Console.WriteLine($"{item.Id} has been added");
    }

    public void Remove(T item)
    {
        myGenericList.Remove(item);
        Console.WriteLine($"{item.Id} has been removed");
    }

    public void Save()
    {
        Console.WriteLine("Changes saved.");
    }

    public IEnumerable<T> GetAll()
    {
        Console.WriteLine($"{typeof(T).Name} has been loaded");
        return myGenericList;
    }

    public T GetById(int id)
    {
        Console.WriteLine($"{typeof(T).Name} has been loaded");
        return myGenericList.FirstOrDefault(x => x.Id == id);
    }

    public void DisplayAll()
    {
        Console.WriteLine("All Products: ");
        foreach (var p in myGenericList)
        {
            Console.WriteLine(p.ToString());
        }
    }
}