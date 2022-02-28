using UnityEngine;
using System;
using System.Collections.Generic;

public class SerializationCallbackScript : MonoBehaviour, ISerializationCallbackReceiver
{
    public Dictionary<int, string> _myDictionary = new Dictionary<int, string>();

    [SerializeField] private List<int> _keys;
    [SerializeField] private List<string> _values;

    private ListedDictionary<int, string> _listedDictionary;
    private ListedDictionary<int, string> listedDictionary
    { 
        get 
        {
            if (_listedDictionary == null)
            {
                _listedDictionary = new ListedDictionary<int, string>(_myDictionary);
            }
            return _listedDictionary;
        }
    }


    private void Start()
    {
        //For Example
        _myDictionary.Add(1, "The first element");
        _myDictionary.Add(2, "The second element");
        _myDictionary.Add(3, "The third element");
    }

    public void OnBeforeSerialize()
    {
        _keys = listedDictionary.keys;
        _values = listedDictionary.values;
    }

    public void OnAfterDeserialize()
    {
        _myDictionary.Clear();

        int minCount = Math.Min(_keys.Count, _values.Count);

        for (int i = 0; i < minCount; i++)
            _myDictionary.Add(_keys[i], _values[i]);
    }
}