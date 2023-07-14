using System.Collections;
using Smarty.Net.Core.Shared.Exceptions;

namespace Smarty.Net.Core.Shared;

public class Batch<T> : ICollection<T>
    where T : class, ILookup
{

    private readonly int _maxSize;
    private readonly IDictionary<string, T> _namedItems;
    private readonly List<T> _allItems;

    internal Batch(int maxSize)
    {
        _maxSize = maxSize;
        _namedItems = new Dictionary<string, T>();
        _allItems = new List<T>();
    }

    public int Count => _allItems.Count;

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        if (_allItems.Count >= _maxSize)
        {
            throw new BatchFullException($"Batch size cannot exceed {_maxSize} items");
        }

        _allItems.Add(item);

        var key = item.InputId;
        if (string.IsNullOrWhiteSpace(key))
        {
            return;
        }

        _namedItems[key] = item;
    }

    public void Clear()
    {
        _allItems.Clear();
        _namedItems.Clear();
    }

    public bool Contains(T item)
    {
        return _allItems.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _allItems.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _allItems.GetEnumerator();
    }

    public bool Remove(T item)
    {
        if (!string.IsNullOrWhiteSpace(item.InputId))
            _namedItems.Remove(item.InputId);

        return _allItems.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
