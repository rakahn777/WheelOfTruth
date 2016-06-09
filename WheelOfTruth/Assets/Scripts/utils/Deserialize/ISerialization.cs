using UnityEngine;
using System.Collections;

public interface ISerialization
{
	T Deserialize<T>(byte[] bytes);

    void Serialize(object value, string paths);
    string Serialize(object value);
}