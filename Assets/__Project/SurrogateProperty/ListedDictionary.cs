using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ListedDictionary<TKey, TValue>
{
    private List<TKey> _keys;
    private List<TValue> _values;

    public List<TKey> keys { get { return ListedKeys(); } }
    public List<TValue> values { get { return ListedValues(); } }

    private Dictionary<TKey, TValue> _dictionary;

    public ListedDictionary(Dictionary<TKey, TValue> dictionary)
    {
        _dictionary = dictionary;

        _keys = new List<TKey>();
        _values = new List<TValue>();
    }

    private List<TKey> ListedKeys()
    {
        _keys.Clear();
        foreach (KeyValuePair<TKey, TValue> kvp in _dictionary)
        {
            _keys.Add(kvp.Key);
        }
        return _keys;
    }

    private List<TValue> ListedValues()
    {
        _values.Clear();
        foreach (KeyValuePair<TKey, TValue> kvp in _dictionary)
        {
            _values.Add(kvp.Value);
        }
        return _values;
    }
}
