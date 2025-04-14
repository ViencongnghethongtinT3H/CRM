﻿using Jil;
using System.Text;

namespace FDS.CRM.CrossCuttingConcerns.Cache.RedisCache;

public class JilSerializer : ISerializer
{
    public static readonly Jil.Options JilOptions = new Jil.Options(dateFormat: DateTimeFormat.ISO8601, includeInherited: true);
    // TODO: May make this configurable in the future.
    /// <summary>
    /// Encoding to use to convert string to byte[] and the other way around.
    /// </summary>
    /// <remarks>
    /// StackExchange.Redis uses Encoding.UTF8 to convert strings to bytes,
    /// hence we do same here.
    /// </remarks>
    private static readonly Encoding encoding = Encoding.UTF8;

    public byte[] Serialize(object item)
    {
        var jsonString = JSON.Serialize(item, JilOptions);
        return encoding.GetBytes(jsonString);
    }

    public Task<byte[]> SerializeAsync(object item)
    {
        return Task.Factory.StartNew(() => Serialize(item));
    }

    public object Deserialize(byte[] serializedObject)
    {
        var jsonString = encoding.GetString(serializedObject);
        return JSON.Deserialize(jsonString, typeof(object), JilOptions);
    }

    public Task<object> DeserializeAsync(byte[] serializedObject)
    {
        return Task.Factory.StartNew(() => Deserialize(serializedObject));
    }

    public T Deserialize<T>(byte[] serializedObject) where T : class
    {
        var jsonString = encoding.GetString(serializedObject);
        return JSON.Deserialize<T>(jsonString, JilOptions);
    }

    public Task<T> DeserializeAsync<T>(byte[] serializedObject) where T : class
    {
        return Task.Factory.StartNew(() => Deserialize<T>(serializedObject));
    }
}
