namespace c_sharp_app;

internal interface IStorage<T>
{
    void Add(T item);
    IReadOnlyList<T> GetAll();
    void Persist();
}