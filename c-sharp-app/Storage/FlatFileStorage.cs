using System.Text.Json;

namespace c_sharp_app.Storage;

internal class FlatFileStorage<T> : IStorage<T>
{
    private List<T> _items;

    private string _pathToFile;

    public FlatFileStorage(string pathToFile)
    {
        _pathToFile = pathToFile;

        _items = Load();
    }

    public void Add(T item)
    {
        _items.Add(item);
    }

    public IReadOnlyList<T> GetAll()
    {
        return _items.AsReadOnly();
    }

    public void Persist()
    {
        var jsonObj = JsonSerializer.Serialize(_items);
        File.WriteAllText(_pathToFile, jsonObj);
    }

    private List<T> Load()
    {
        if (!File.Exists(_pathToFile))
            return new List<T>();

        var json = File.ReadAllText(_pathToFile);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }
}