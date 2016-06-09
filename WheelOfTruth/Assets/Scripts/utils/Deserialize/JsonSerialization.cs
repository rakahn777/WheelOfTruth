using System.IO;
using LitJson;
using UnityEngine;
using System.Collections;

public class JsonSerialization : ISerialization
{
	public T Deserialize<T>(byte[] bytes)
	{
		string s = System.Text.Encoding.ASCII.GetString(bytes);
		return JsonMapper.ToObject<T>(s);
	}

    public void Serialize(object value,string paths)
    {
        string s = JsonMapper.ToJson(value);
        FileStream stream = new FileStream(paths,FileMode.OpenOrCreate);
        StreamWriter writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
    }

    public string Serialize(object value)
    {
        return JsonMapper.ToJson(value);
    }
}
