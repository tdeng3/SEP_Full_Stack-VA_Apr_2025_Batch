namespace _04Generics;

public class MyStack<T>
{
    private List<T> myStack = new List<T>();
    public void Push(T item)
    {
        myStack.Add(item);
        Console.WriteLine($"{item} has been added to the stack.");
    }
    public T Pop()
    {   
        T popedItem = myStack[myStack.Count - 1];
        if (myStack.Count == 0)
        {
            Console.WriteLine("Stack is empty.");
        }
        T item = myStack[myStack.Count - 1];
        myStack.RemoveAt(myStack.Count - 1);
        Console.WriteLine($"{popedItem} is popped ");
        return item;
    }
    public int Count()
    {
        Console.WriteLine($"Totle is {myStack.Count()}");
        return myStack.Count;
    }
}