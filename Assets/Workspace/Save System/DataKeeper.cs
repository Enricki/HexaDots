using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataKeeper : ScriptableObject
{
    public void SetParametr<T>(T parametr, out T _element)
    {
        _element = parametr;
    }
}

public enum TTypes
{
    int_type,
    float_type,
    string_type,
    bool_type
}

[Serializable]
public struct DataElement<T>
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private T _value;

    public string Name { get => _name; }
    public T Value { get => _value; }

    public DataElement(string name, T value)
    {
        _name = name;
        _value = value;
    }

    public void SetValue(T newValue)
    {
        _value = newValue;
    }
}