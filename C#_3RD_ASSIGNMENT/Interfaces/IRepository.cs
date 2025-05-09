namespace _04Generics;

public interface IRepository<T> where T : class, IEntity
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
    void DisplayAll();
}