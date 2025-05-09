namespace _04Generics;

public class MyList<T>
{
    private List<T> myList = new List<T>();
    public void Add(T element)
    {
        myList.Add(element);
        Console.WriteLine($"{element} is added");
    }
    public T Remove(int index)
    {
        T removed = myList[index];
        myList.RemoveAt(index);
        Console.WriteLine($"{removed} is removed");
        return removed;
    }
    public bool Contains(T element)
    {
        return myList.Contains(element);
    }
    public void Clear()
    {
        Console.WriteLine($"MyList is clear.");
        myList.Clear();
    }
    public void InsertAt(T element, int index)
    {
        myList.Insert(index, element);
        Console.WriteLine($"{element} is inserted at index {index}");
    }
    public void DeleteAt(int index)
    {
        myList.RemoveAt(index);
        Console.WriteLine($"{myList[index]} is removed at index {index}");
    }
    public T Find(int index)
    {
        return myList[index];
    }
}